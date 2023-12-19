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
public class MigrationController : ControllerBase
{
    private readonly Context _context;

    private readonly MigrationRepository _migrationRepository;

    public MigrationController(Context context)
    {
        _context = context;
        _migrationRepository = new MigrationRepository(_context);
    }

    // GET: api/Migration
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MigrationDto>>> GetMigrations()
    {
        var migrations = await _migrationRepository.GetAllAsync();
        if (migrations == null)
        {
            return NotFound();
        }
        return MigrationDtoMapper.ToDTO(migrations);
    }

    // POST: api/Migration
    [HttpPost]
    public async Task<ActionResult<MigrationDto>> PostMigration(MigrationDto incomingMigrationDto)
    {
        var migrationEntity = MigrationDtoMapper.ToEntity(incomingMigrationDto);
        var addedMigrationEntity = await _migrationRepository.AddAsync(migrationEntity);
        var addedMigrationDto = MigrationDtoMapper.ToDTO(addedMigrationEntity);
        return addedMigrationDto;
    }

    // PUT: api/Migration
    [HttpPut("{id}")]
    public async Task<ActionResult<MigrationDto>> PutMigration(Guid id, MigrationDto migrationDto)
    {
        if (id != migrationDto.Id)
        {
            return BadRequest();
        }

        var migration = MigrationDtoMapper.ToEntity(migrationDto);

        var updatedMigration = await _migrationRepository.UpdateAsync(migration);

        return MigrationDtoMapper.ToDTO(updatedMigration);
    }
}