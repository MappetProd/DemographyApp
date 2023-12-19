using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demography.Infrastructure;
using Demography.Domain;
using Demography.API.Dto;
using DemographyApp.Infrastructure;

namespace Demography.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AgeController : ControllerBase
{
    private readonly Context _context;

    private readonly AgeRepository _ageRepository;

    public AgeController(Context context)
    {
        _context = context;
        _ageRepository = new AgeRepository(_context);
    }

    // GET: api/Age
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AgeDto>>> GetAge()
    {
        var ageGroups = await _ageRepository.GetAllAsync();
        if (ageGroups == null)
        {
            return NotFound();
        }
        return AgeDtoMapper.ToDTO(ageGroups);
    }

    // POST: api/Age
    [HttpPost]
    public async Task<ActionResult<AgeDto>> PostAge(AgeDto incomingAgeDto)
    {
        var ageEntity = AgeDtoMapper.ToEntity(incomingAgeDto);
        var addedAgeEntity = await _ageRepository.AddAsync(ageEntity);
        var addedAgeDto = AgeDtoMapper.ToDTO(addedAgeEntity);
        return addedAgeDto;
    }

    // PUT: api/Age
    [HttpPut("{id}")]
    public async Task<ActionResult<AgeDto>> PutAge(Guid id, AgeDto ageDto)
    {
        if (id != ageDto.Id)
        {
            return BadRequest();
        }

        var age = AgeDtoMapper.ToEntity(ageDto);

        var updatedAge = await _ageRepository.UpdateAsync(age);

        return AgeDtoMapper.ToDTO(updatedAge);
    }
}