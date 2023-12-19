using Demography.Domain;

namespace Demography.API.Dto;

public static class MigrationDtoMapper
{
    public static MigrationDto ToDTO(Migration migration) =>
        new MigrationDto
        {
            Id = migration.Id,
            MigrantsCount = migration.MigrantsCount,
            EmigrantsCount = migration.EmigrantsCount,
            MigrationRatio = migration.MigrationRatio,
            DemographyDataId = migration.DemographyDataId
        };

    public static List<MigrationDto> ToDTO(List<Migration> migrations){
        var migrationDtos = new List<MigrationDto>();
        foreach(var migration in migrations)
        {
            migrationDtos.Add(ToDTO(migration));
        }
        return migrationDtos;
    }

    public static Migration ToEntity(MigrationDto migrationDto){
        var migration = new Migration
        {
            Id = migrationDto.Id,
            MigrantsCount = migrationDto.MigrantsCount,
            EmigrantsCount = migrationDto.EmigrantsCount,
            MigrationRatio = migrationDto.MigrationRatio,
            DemographyDataId = migrationDto.DemographyDataId
        };
        return migration;
    }

    public static List<Migration> ToEntity(List<MigrationDto> migrationDtos){
        var migrations = new List<Migration>();
        foreach(var migrationDto in migrationDtos)
        {
            migrations.Add(ToEntity(migrationDto));
        }
        return migrations;
    }
}