using System.ComponentModel.DataAnnotations.Schema;


namespace DemographyApi.Domain;

[Table("region")]
public class Region
{
  [Column("uuid")]
  public Guid Uuid { get; set; }

  [Column("name")]
  public required string Name { get; set; }

  [Column("data")]
  public List<DemographyData> DemographyDatum { get; set; } = new List<DemographyData>();

}