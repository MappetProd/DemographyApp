using Demography.Domain;

namespace Demography.API.Dto;

public static class NaturalGrowthDtoMapper
{
    public static NaturalGrowthDto ToDTO(NaturalGrowth naturalGrowth) =>
        new NaturalGrowthDto
        {
            Id = naturalGrowth.Id,
            BithRate = naturalGrowth.BithRate,
            MortalityRate = naturalGrowth.MortalityRate,
            DemographyDataId = naturalGrowth.DemographyDataId
        };

    public static List<NaturalGrowthDto> ToDTO(List<NaturalGrowth> naturalGrowths){
        var naturalGrowthDtos = new List<NaturalGrowthDto>();
        foreach(var naturalGrowth in naturalGrowths)
        {
            naturalGrowthDtos.Add(ToDTO(naturalGrowth));
        }
        return naturalGrowthDtos;
    }

    public static NaturalGrowth ToEntity(NaturalGrowthDto naturalGrowthDto){
        var naturalGrowth = new NaturalGrowth
        {
            Id = naturalGrowthDto.Id,
            BithRate = naturalGrowthDto.BithRate,
            MortalityRate = naturalGrowthDto.MortalityRate,
            DemographyDataId = naturalGrowthDto.DemographyDataId
        };
        return naturalGrowth;
    }

    public static List<NaturalGrowth> ToEntity(List<NaturalGrowthDto> naturalGrowthDtos){
        var naturalGrowths = new List<NaturalGrowth>();
        foreach(var naturalGrowthDto in naturalGrowthDtos)
        {
            naturalGrowths.Add(ToEntity(naturalGrowthDto));
        }
        return naturalGrowths;
    }
}