using System.ComponentModel.DataAnnotations.Schema;

namespace Demography.Domain;

[Table("natural_growth")]
public class NaturalGrowth 
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("bith_rate")]
    public int BithRate { get; set; }

    [Column("mortality_rate")]
    public int MortalityRate { get; set; }

    public DemographyData? DemographyData {get; set; }
}