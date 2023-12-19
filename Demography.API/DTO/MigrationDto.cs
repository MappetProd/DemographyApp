namespace Demography.API.Dto;

public class MigrationDto
{
    public Guid Id { get; set; }

    public int MigrantsCount { get; set; }

    public int EmigrantsCount { get; set; }

    public int MigrationRatio { get; set; }

    public Guid DemographyDataId {get; set; }
}