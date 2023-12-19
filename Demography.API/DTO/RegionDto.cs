namespace Demography.API.Dto;

public class RegionDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public List<DemographyDataDto> DemographyDatumDtos { get; set; } = null!;
}