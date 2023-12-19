namespace Demography.API.Dto;

public class AgeDto
{
    public Guid Id { get; set; }

    public int MenQuantity { get; set; }

    public int WomenQuantity { get; set; }

    public int AgeValue { get; set; }

    public Guid DemographyDataId {get; set; }
}