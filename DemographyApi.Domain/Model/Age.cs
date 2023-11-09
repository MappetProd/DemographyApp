using System.ComponentModel.DataAnnotations.Schema;

namespace DemographyApi.Domain;

[Table("age")]
public class Age
{
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("men_quantity")]
    public int MenQuantity { get; set; }

    [Column("women_quantity")]
    public int WomenQuantity { get; set; }

    [Column("age_range")]
    public Tuple<int, int> AgeRange { get; set; }
}