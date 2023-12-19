namespace Demography.API.Dto;

public class DemographyDataDto
{
    public Guid Id {get; set; }
    public Guid RegionId {get; set; }
    public int Year { get; set; }
    public List<EthnosDto> EthnicGroups { get; set; } = null!;
    public List<AgeDto> AgeGroups { get; set; } = null!;
    public List<NaturalGrowthDto> NaturalGrowthGroups { get; set; } = null!;
    public List<DensityDto> DensityGroups { get; set; } = null!;
    public List<MigrationDto> Migrations { get; set; } = null!;
}