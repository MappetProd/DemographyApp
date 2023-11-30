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
    public async Task<ActionResult<IEnumerable<EthnosDto>>> GetPersons()
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
    public async Task<ActionResult<EthnosDto>> PostEthnos(EthnosDto ethnosDto)
    {
        var ethnos = EthnosDtoMapper.ToEntity(ethnosDto);
        var result = await _ethnosRepository.AddAsync(ethnos);
        var resultDto = EthnosDtoMapper.ToDTO(result);
        return resultDto;
    }
}