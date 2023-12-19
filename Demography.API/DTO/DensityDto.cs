namespace Demography.API.Dto;

public class DensityDto
{
    public Guid Id { get; set; }

    public double AreaSize { get; set; }

    public int PopulationSize { get; set; }

    public double PopulationDensity { get; set; }

    public Guid DemographyDataId {get; set; }
}