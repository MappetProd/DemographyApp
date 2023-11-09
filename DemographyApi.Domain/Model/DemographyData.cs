using System.ComponentModel.DataAnnotations.Schema;

namespace DemographyApi.Domain;

[Table("demography_data")]
public class DemographyData
{
    [Column("demography_data_id")]
    public Guid DemographyDataId { get; set; };

    [Column("ethnos_id")]
    public List<Ethnos> EthnicGroups { get; set; } = new List<Ethnos>();

    [Column("age_id")]
    public List<Age> AgeGroups { get; set; } = new List<Age>();

    [Column("natural_growth_id")]
    public List<NaturalGrowth> NaturalGrowthGroups { get; set; } = new List<NaturalGrowth>();

    [Column("density_id")]
    public List<Density> DensityGroups { get; set; } = new List<Density>();

    [Column("year")]
    public int Year { get; set; };
    
}