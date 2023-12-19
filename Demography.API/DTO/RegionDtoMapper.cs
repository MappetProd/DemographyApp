using Demography.Domain;

namespace Demography.API.Dto;

public static class RegionDtoMapper
{
    public static RegionDto ToDTO(Region region){
        var regionDto = new RegionDto
        {
            Id = region.Id,
            Name = region.Name,
            DemographyDatumDtos = new List<DemographyDataDto>()
        };

        if (region.DemographyDatum != null)
        {
            foreach(var demographyData in region.DemographyDatum)
            {
                regionDto.DemographyDatumDtos.Add(DemographyDataDtoMapper.ToDTO(demographyData));
            }
        }

        return regionDto;
    }

    public static Region ToEntity(RegionDto regionDto){        
        var region = new Region
        {
            Id = regionDto.Id,
            Name = regionDto.Name,
            DemographyDatum = new List<DemographyData>()
        };

        if (regionDto.DemographyDatumDtos != null)
        {
            foreach(var demographyDataDto in regionDto.DemographyDatumDtos)
            {
                region.DemographyDatum.Add(DemographyDataDtoMapper.ToEntity(demographyDataDto));
            } 
        }

        return region;
    }
}