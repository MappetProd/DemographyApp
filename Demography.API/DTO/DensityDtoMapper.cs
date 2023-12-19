using Demography.Domain;

namespace Demography.API.Dto;

public static class DensityDtoMapper
{
    public static DensityDto ToDTO(Density density) =>
        new DensityDto
        {
            Id = density.Id,
            AreaSize = density.AreaSize,
            PopulationSize = density.PopulationSize,
            PopulationDensity = density.PopulationDensity,
            DemographyDataId = density.DemographyDataId
        };

    public static List<DensityDto> ToDTO(List<Density> densities){
        var densityDtos = new List<DensityDto>();
        foreach(var density in densities)
        {
            densityDtos.Add(ToDTO(density));
        }
        return densityDtos;
    }

    public static Density ToEntity(DensityDto densityDto){
        var density = new Density
        {
            Id = densityDto.Id,
            AreaSize = densityDto.AreaSize,
            PopulationSize = densityDto.PopulationSize,
            PopulationDensity = densityDto.PopulationDensity,
            DemographyDataId = densityDto.DemographyDataId
        };
        return density;
    }

    public static List<Density> ToEntity(List<DensityDto> densityDtos){
        var densities = new List<Density>();
        foreach(var densityDto in densityDtos)
        {
            densities.Add(ToEntity(densityDto));
        }
        return densities;
    }
}