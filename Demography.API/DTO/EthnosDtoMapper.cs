using Demography.Domain;

namespace Demography.API.Dto;

public static class EthnosDtoMapper
{
    public static EthnosDto ToDTO(Ethnos ethnos) =>
        new EthnosDto
        {
            Id = ethnos.Id,
            Name = ethnos.Name,
            MenQuantity = ethnos.MenQuantity,
            WomenQuantity = ethnos.WomenQuantity,
            DemographyDataId = ethnos.DemographyDataId
        };

    public static List<EthnosDto> ToDTO(List<Ethnos> ethnicGroups){
        var ethnosDtos = new List<EthnosDto>();
        foreach(var ethnos in ethnicGroups)
        {
            ethnosDtos.Add(ToDTO(ethnos));
        }
        return ethnosDtos;
    }

    public static Ethnos ToEntity(EthnosDto ethnosDto){
        var ethnos = new Ethnos
        {
            Id = ethnosDto.Id,
            Name = ethnosDto.Name,
            MenQuantity = ethnosDto.MenQuantity,
            WomenQuantity = ethnosDto.WomenQuantity,
            DemographyDataId = ethnosDto.DemographyDataId
        };
        return ethnos;
    }

    public static List<Ethnos> ToEntity(List<EthnosDto> ethnosDtos){
        var ethnicGroups = new List<Ethnos>();
        foreach(var ethnosDto in ethnosDtos)
        {
            ethnicGroups.Add(ToEntity(ethnosDto));
        }
        return ethnicGroups;
    }
}

