namespace Demography.API.Dto;

public class EthnosDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; } = String.Empty;
    public int MenQuantity { get; set; } = 0;
    public int WomenQuantity { get; set; } = 0;
}