using System.ComponentModel.DataAnnotations.Schema;

namespace DemographyApi.Domain;

[Table("density")]
public class Density
{
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Column("area_size")]
    public double AreaSize { get; set; }

    [Column("population_size")]
    public int PopulationSize { get; set; }

    [Column("population_density")]
    public double PopulationDensity { get; set; }

}