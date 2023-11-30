using System.ComponentModel.DataAnnotations.Schema;


namespace Demography.Domain;

[Table("region")]
public class Region
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    public DemographyData? DemographyData {get; set; }
}