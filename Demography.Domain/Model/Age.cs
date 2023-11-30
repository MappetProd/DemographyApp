using System.ComponentModel.DataAnnotations.Schema;

namespace Demography.Domain;

[Table("age")]
public class Age
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("men_quantity")]
    public int MenQuantity { get; set; }

    [Column("women_quantity")]
    public int WomenQuantity { get; set; }

    [Column("age_value")]
    public int AgeValue { get; set; }

    public DemographyData? DemographyData {get; set; }
}