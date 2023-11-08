using System.ComponentModel.DataAnnotations.Schema;

namespace DemographyApi.Domain;

[Table("ethnos")]
public class Ethnos {
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("men_quantity")]
    public int MenQuantity { get; set; }

    [Column("women_quantity")]
    public int WomenQuantity { get; set; }
}