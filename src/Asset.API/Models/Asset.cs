namespace Asset.API.Model;

[Table("ASSET")]
public class Asset
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NAME")]
    public string? Name { get; set; }

    [Column("IP_ADDRESS")]
    public string? IpAddress { get; set; }
}