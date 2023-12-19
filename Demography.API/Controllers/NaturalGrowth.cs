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
public class NaturalGrowthController : ControllerBase
{
    private readonly Context _context;

    private readonly NaturalGrowthRepository _naturalGrowthRepository;

    public NaturalGrowthController(Context context)
    {
        _context = context;
        _naturalGrowthRepository = new NaturalGrowthRepository(_context);
    }

    // GET: api/NaturalGrowth
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NaturalGrowthDto>>> GetNaturalGrowthGroups()
    {
        var naturalGrowthGroups = await _naturalGrowthRepository.GetAllAsync();
        if (naturalGrowthGroups == null)
        {
            return NotFound();
        }
        return NaturalGrowthDtoMapper.ToDTO(naturalGrowthGroups);
    }

    // POST: api/NaturalGrowth
    [HttpPost]
    public async Task<ActionResult<NaturalGrowthDto>> PostNaturalGrowth(NaturalGrowthDto incomingNaturalGrowthDto)
    {
        var naturalGrowthEntity = NaturalGrowthDtoMapper.ToEntity(incomingNaturalGrowthDto);
        var addedNaturalGrowthEntity = await _naturalGrowthRepository.AddAsync(naturalGrowthEntity);
        var addedNaturalGrowthDto = NaturalGrowthDtoMapper.ToDTO(addedNaturalGrowthEntity);
        return addedNaturalGrowthDto;
    }

    // PUT: api/NaturalGrowth/<int>
    [HttpPut("{id}")]
    public async Task<ActionResult<NaturalGrowthDto>> PutNaturalGrowth(Guid id, NaturalGrowthDto naturalGrowthDto)
    {
        if (id != naturalGrowthDto.Id)
        {
            return BadRequest();
        }

        var naturalGrowth = NaturalGrowthDtoMapper.ToEntity(naturalGrowthDto);

        var updatedNaturalGrowth = await _naturalGrowthRepository.UpdateAsync(naturalGrowth);

        return NaturalGrowthDtoMapper.ToDTO(updatedNaturalGrowth);
    }
}