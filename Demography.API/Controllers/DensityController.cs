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
public class DensityController : ControllerBase
{
    private readonly Context _context;

    private readonly DensityRepository _densityRepository;

    public DensityController(Context context)
    {
        _context = context;
        _densityRepository = new DensityRepository(_context);
    }

    // GET: api/Density
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DensityDto>>> GetDensities()
    {
        var densityes = await _densityRepository.GetAllAsync();
        if (densityes == null)
        {
            return NotFound();
        }
        return DensityDtoMapper.ToDTO(densityes);
    }

    // POST: api/Density
    [HttpPost]
    public async Task<ActionResult<DensityDto>> PostDensity(DensityDto incomingDensityDto)
    {
        var densityEntity = DensityDtoMapper.ToEntity(incomingDensityDto);
        var addedDensityEntity = await _densityRepository.AddAsync(densityEntity);
        var addedDensityDto = DensityDtoMapper.ToDTO(addedDensityEntity);
        return addedDensityDto;
    }

    // PUT: api/Density
    [HttpPut("{id}")]
    public async Task<ActionResult<DensityDto>> PutDensity(Guid id, DensityDto densityDto)
    {
        if (id != densityDto.Id)
        {
            return BadRequest();
        }

        var density = DensityDtoMapper.ToEntity(densityDto);

        var updatedDensity = await _densityRepository.UpdateAsync(density);

        return DensityDtoMapper.ToDTO(updatedDensity);
    }
}