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
            WomenQuantity = ethnos.WomenQuantity
        };

    public static List<EthnosDto> ToDTO(List<Ethnos> ethnicGroups){
        var ethnicGroupsDto = new List<EthnosDto>();
        foreach(var ethnos in ethnicGroups)
        {
            ethnicGroupsDto.Add(ToDTO(ethnos));
        }

        return ethnicGroupsDto;
    }

    public static Ethnos ToEntity(EthnosDto ethnosDto){
        var ethnos = new Ethnos
        {
            Id = ethnosDto.Id,
            Name = ethnosDto.Name,
            MenQuantity = ethnosDto.MenQuantity,
            WomenQuantity = ethnosDto.WomenQuantity
        };
        return ethnos;
    }
}

