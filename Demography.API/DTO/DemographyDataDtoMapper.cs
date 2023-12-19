using Demography.Domain;

namespace Demography.API.Dto;

public static class DemographyDataDtoMapper
{
    public static DemographyDataDto ToDTO(DemographyData demographyData)
    {
        var demographyDataDto = new DemographyDataDto{
            Id = demographyData.Id,
            RegionId = demographyData.RegionId,
            Year = demographyData.Year,
        };

        if (demographyData.EthnicGroups != null)
        {
            demographyDataDto.EthnicGroups = EthnosDtoMapper.ToDTO(demographyData.EthnicGroups);
        }

        if (demographyData.AgeGroups != null)
        {
            demographyDataDto.AgeGroups = AgeDtoMapper.ToDTO(demographyData.AgeGroups);
        }

        if (demographyData.NaturalGrowthGroups != null)
        {
            demographyDataDto.NaturalGrowthGroups = NaturalGrowthDtoMapper.ToDTO(demographyData.NaturalGrowthGroups);
        }

        if (demographyData.DensityGroups != null)
        {
            demographyDataDto.DensityGroups = DensityDtoMapper.ToDTO(demographyData.DensityGroups);
        }

        if (demographyData.Migrations != null)
        {
            demographyDataDto.Migrations = MigrationDtoMapper.ToDTO(demographyData.Migrations);
        }

        return demographyDataDto;
    }

    public static List<DemographyDataDto> ToDTO(List<DemographyData> demographyDatum){
        var demographyDataDtos = new List<DemographyDataDto>();
        foreach(var demographyData in demographyDatum)
        {
            demographyDataDtos.Add(ToDTO(demographyData));
        }
        return demographyDataDtos;
    }

    public static DemographyData ToEntity(DemographyDataDto demographyDataDto)
    {
        var demographyData = new DemographyData{
            Id = demographyDataDto.Id,
            RegionId = demographyDataDto.RegionId,
            Year = demographyDataDto.Year,
        };

        if (demographyDataDto.EthnicGroups != null)
        {
            demographyData.EthnicGroups = EthnosDtoMapper.ToEntity(demographyDataDto.EthnicGroups);
        }

        if (demographyDataDto.AgeGroups != null)
        {
            demographyData.AgeGroups = AgeDtoMapper.ToEntity(demographyDataDto.AgeGroups);
        }

        if (demographyDataDto.NaturalGrowthGroups != null)
        {
            demographyData.NaturalGrowthGroups = NaturalGrowthDtoMapper.ToEntity(demographyDataDto.NaturalGrowthGroups);
        }

        if (demographyDataDto.DensityGroups != null)
        {
            demographyData.DensityGroups = DensityDtoMapper.ToEntity(demographyDataDto.DensityGroups);
        }

        if (demographyDataDto.Migrations != null)
        {
            demographyData.Migrations = MigrationDtoMapper.ToEntity(demographyDataDto.Migrations);
        }

        return demographyData;
    }
}
