using System.ComponentModel.DataAnnotations.Schema;

namespace Demography.Domain;

[Table("density")]
public class Density
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("area_size")]
    public double AreaSize { get; set; }

    [Column("population_size")]
    public int PopulationSize { get; set; }

    [Column("population_density")]
    public double PopulationDensity { get; set; }

    public DemographyData? DemographyData {get; set; }
}