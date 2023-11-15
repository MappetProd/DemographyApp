using System.ComponentModel.DataAnnotations.Schema;

namespace Demography.Domain;

[Table("migration")]
public class Migration
{
    [Column("Id")]
    public Guid Id { get; set; }

    [Column("migrants_count")]
    public int MigrantsCount { get; set; }

    [Column("emigrants_count")]
    public int EmigrantsCount { get; set; }

    [Column("migration_ratio")]
    public int MigrationRatio { get; set; }
}