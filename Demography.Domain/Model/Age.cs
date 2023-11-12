using System.ComponentModel.DataAnnotations.Schema;

namespace Demography.Domain;

[Table("age")]
public class Age
{
    [Column("Id")]
    public Guid Id { get; set; }

    [Column("men_quantity")]
    public int MenQuantity { get; set; }

    [Column("women_quantity")]
    public int WomenQuantity { get; set; }

    [Column("age_from")]
    public int AgeFrom { get; set; }

    [Column("age_to")]
    public int AgeTo { get; set; }
}