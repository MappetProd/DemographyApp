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
public class RegionController : ControllerBase
{
    private readonly Context _context;

    private readonly RegionRepository _regionRepository;

    public RegionController(Context context)
    {
        _context = context;
        _regionRepository = new RegionRepository(_context);
    }

    // GET: api/Region
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegionDto?>>> GetRegions(string? name)
    {
        var regions = await _regionRepository.GetAllAsync(name);
        if (regions == null)
        {
            return NotFound();
        }
        return regions.Select(a => RegionDtoMapper.ToDTO(a)).ToList();
    }
    
    // GET: api/Region/<int>
    [HttpGet("{id}")]
    public async Task<ActionResult<RegionDto?>> GetRegionByID(Guid id)
    {
        var region = await _regionRepository.GetAsyncById(id);
        if (region == null)
        {
            return NotFound();
        }
        return RegionDtoMapper.ToDTO(region);
    }

    // POST: api/Region
    [HttpPost]
    public async Task<ActionResult<RegionDto>> PostRegion(RegionDto incomingRegionDto)
    {   
        if (incomingRegionDto == null){
            return BadRequest("Invalid or missing data in the request.");
        }
        var regionEntity = RegionDtoMapper.ToEntity(incomingRegionDto);
        var addedRegionEntity = await _regionRepository.AddAsync(regionEntity);
        var addedRegionDto = RegionDtoMapper.ToDTO(addedRegionEntity);
        return addedRegionDto;
    }
}