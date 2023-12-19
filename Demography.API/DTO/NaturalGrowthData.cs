namespace Demography.API.Dto;

public class NaturalGrowthDto
{
    public Guid Id { get; set; }

    public int BithRate { get; set; }

    public int MortalityRate { get; set; }

    public Guid DemographyDataId {get; set; }
}