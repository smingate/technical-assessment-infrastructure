namespace Asset.API.Data;

public class AssetContext(DbContextOptions<AssetContext> options) : DbContext(options)
{
    public DbSet<Model.Asset> Assets { get; set; }
}