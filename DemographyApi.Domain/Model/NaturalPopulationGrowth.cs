using System.ComponentModel.DataAnnotations.Schema;

namespace DemographyApi.Domain;

[Table("NaturalPopulationGrowth")]
public class Ethnos {
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("bith_rate")]
    public int BithRate { get; set; }

    [Column("mortality_rate")]
    public int MortalityRate { get; set; }

}