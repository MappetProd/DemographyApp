using System.ComponentModel.DataAnnotations.Schema;

namespace Demography.Domain;

[Table("demography_data")]
public class DemographyData
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("region_id")]
    public Guid RegionId {get; set; }
    public Region Region {get; set; } = null!;

    [Column("year")]
    public int Year { get; set; }

    public List<Ethnos> EthnicGroups { get; set; } = new ();

    public List<Age> AgeGroups { get; set; } = new ();

    public List<NaturalGrowth> NaturalGrowthGroups { get; set; } = new ();

    public List<Density> DensityGroups { get; set; } = new ();

    public List<Migration> Migrations {get; set; } = new ();
}