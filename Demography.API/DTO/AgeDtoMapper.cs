using Demography.Domain;

namespace Demography.API.Dto;

public static class AgeDtoMapper
{
    public static AgeDto ToDTO(Age age) =>
        new AgeDto
        {
            Id = age.Id,
            MenQuantity = age.MenQuantity,
            WomenQuantity = age.WomenQuantity,
            AgeValue = age.AgeValue,
            DemographyDataId = age.DemographyDataId
        };

    public static List<AgeDto> ToDTO(List<Age> ages){
        var ageDtos = new List<AgeDto>();
        foreach(var age in ages)
        {
            ageDtos.Add(ToDTO(age));
        }
        return ageDtos;
    }

    public static Age ToEntity(AgeDto ageDto){
        var age = new Age
        {
            Id = ageDto.Id,
            MenQuantity = ageDto.MenQuantity,
            WomenQuantity = ageDto.WomenQuantity,
            AgeValue = ageDto.AgeValue,
            DemographyDataId = ageDto.DemographyDataId
        };
        return age;
    }

    public static List<Age> ToEntity(List<AgeDto> ageDtos){
        var ages = new List<Age>();
        foreach(var ageDto in ageDtos)
        {
            ages.Add(ToEntity(ageDto));
        }
        return ages;
    }
}
