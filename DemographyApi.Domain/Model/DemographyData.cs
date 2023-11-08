using System.ComponentModel.DataAnnotations.Schema;

namespace DemographyApi.Domain;

[Table("demography_data")]
public class DemographyData
{
    [Column("demography_data_id")]
    public Guid DemographyDataId { get; set; }

    [Column("ethnos_id")]
    public List<Ethnos> EthnicGroups { get; set; } = new List<Ethnos>();

    [Column("year")]
    public int Year { get; set; }
    

}