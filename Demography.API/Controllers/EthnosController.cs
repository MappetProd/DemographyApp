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
public class EthnosController : ControllerBase
{
    private readonly Context _context;

    private readonly EthnosRepository _ethnosRepository;

    public EthnosController(Context context)
    {
        _context = context;
        _ethnosRepository = new EthnosRepository(_context);
    }

    // GET: api/Ethnos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EthnosDto>>> GetEthnicGroups()
    {
        var ethnoses = await _ethnosRepository.GetAllAsync();
        if (ethnoses == null)
        {
            return NotFound();
        }
        return EthnosDtoMapper.ToDTO(ethnoses);
    }

    // POST: api/Ethnos
    [HttpPost]
    public async Task<ActionResult<EthnosDto>> PostEthnos(EthnosDto incomingEthnosDto)
    {
        var ethnosEntity = EthnosDtoMapper.ToEntity(incomingEthnosDto);
        var addedEthnosEntity = await _ethnosRepository.AddAsync(ethnosEntity);
        var addedEthnosDto = EthnosDtoMapper.ToDTO(addedEthnosEntity);
        await _ethnosRepository.AddDemographyDatumAsync(incomingEthnosDto.Id, incomingEthnosDto.DemographyDataId);
        return addedEthnosDto;
    }

    // PUT: api/Ethnos
    [HttpPut("{id}")]
    public async Task<ActionResult<EthnosDto>> PutEthnos(Guid id, EthnosDto ethnosDto)
    {
        if (id != ethnosDto.Id)
        {
            return BadRequest();
        }

        var ethnos = EthnosDtoMapper.ToEntity(ethnosDto);

        var updatedEthnos = await _ethnosRepository.UpdateAsync(ethnos);

        return EthnosDtoMapper.ToDTO(updatedEthnos);
    }
}