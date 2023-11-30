using System.ComponentModel.DataAnnotations.Schema;

namespace Demography.Domain;

[Table("ethnos")]
public class Ethnos 
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("men_quantity")]
    public int MenQuantity { get; set; }

    [Column("women_quantity")]
    public int WomenQuantity { get; set; }

    public DemographyData? DemographyData {get; set; }
}