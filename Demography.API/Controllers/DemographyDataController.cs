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
public class DemographyDataController : ControllerBase
{
    private readonly Context _context;

    private readonly DemographyDataRepository _demographyDataRepository;

    public DemographyDataController(Context context)
    {
        _context = context;
        _demographyDataRepository = new DemographyDataRepository(_context);
    }

    // GET: api/DemographyData
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DemographyDataDto>>> GetDemographyDatum()
    {
        var demographyDatum = await _demographyDataRepository.GetAllAsync();
        if (demographyDatum == null)
        {
            return NotFound();
        }
        return demographyDatum.Select(dd => DemographyDataDtoMapper.ToDTO(dd)).ToList();
    }

    // POST: api/DemographyData
    [HttpPost]
    public async Task<ActionResult<DemographyDataDto>> PostDemographyData(DemographyDataDto incomingDemographyDataDto)
    {
        var demographyDataEntity = DemographyDataDtoMapper.ToEntity(incomingDemographyDataDto);
        var addedDemographyDataEntity = await _demographyDataRepository.AddAsync(demographyDataEntity);
        var addedDemographyDataDto = DemographyDataDtoMapper.ToDTO(addedDemographyDataEntity);
        return addedDemographyDataDto;
    }

    // GET: api/DemographyData/<int>
    [HttpGet("{id}")]
    public async Task<ActionResult<DemographyDataDto?>> GetDemographyDataID(Guid id)
    {
        var demographyData = await _demographyDataRepository.GetAsyncById(id);
        if (demographyData == null)
        {
            return NotFound();
        }
        return DemographyDataDtoMapper.ToDTO(demographyData);
    }

    // PUT: api/DemographyData
    [HttpPut("{id}")]
    public async Task<ActionResult<DemographyDataDto>> PutDemographyData(Guid id, DemographyDataDto demographyDataDto)
    {
        if (id != demographyDataDto.Id)
        {
            return BadRequest();
        }

        var demographyData = DemographyDataDtoMapper.ToEntity(demographyDataDto);

        var updatedDemographyData = await _demographyDataRepository.UpdateAsync(demographyData);

        return DemographyDataDtoMapper.ToDTO(updatedDemographyData);
    }
    
}