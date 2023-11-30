using System.ComponentModel.DataAnnotations.Schema;

namespace Demography.Domain;

[Table("demography_data")]
public class DemographyData
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("ethnos_id")]
    public List<Ethnos> EthnicGroups { get; set; } = new List<Ethnos>();

    [Column("age_id")]
    public List<Age> AgeGroups { get; set; } = new List<Age>();

    [Column("natural_growth_id")]
    public List<NaturalGrowth> NaturalGrowthGroups { get; set; } = new List<NaturalGrowth>();

    [Column("density_id")]
    public List<Density> DensityGroups { get; set; } = new List<Density>();

    [Column("year")]
    public int Year { get; set; }
}