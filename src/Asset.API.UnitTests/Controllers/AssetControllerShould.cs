namespace Asset.API.UnitTests.Controllers;

public class AssetControllerTests
{
    private DbContextOptions<AssetContext> CreateNewContextOptions()
    {
        return new DbContextOptionsBuilder<AssetContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    [Fact]
    public async Task GetAssets_ReturnsAllAssets()
    {
        var options = CreateNewContextOptions();

        // Arrange
        await using (var context = new AssetContext(options))
        {
            context.Assets.AddRange(new List<Model.Asset>
            {
                new Model.Asset { Id = 1, Name = "Asset1", IpAddress = "192.168.1.1" },
                new Model.Asset { Id = 2, Name = "Asset2", IpAddress = "192.168.1.2" }
            });
            await context.SaveChangesAsync();
        }

        await using (var context = new AssetContext(options))
        {
            var controller = new AssetController(context);

            // Act
            var result = await controller.GetAssets();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Model.Asset>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<List<Model.Asset>>(okResult.Value);

            Assert.Equal(2, returnValue.Count);
        }
    }

    [Fact]
    public async Task PostAsset_AddsAssetToDatabase()
    {
        var options = CreateNewContextOptions();
        var newAsset = new Model.Asset { Id = 3, Name = "Asset3", IpAddress = "192.168.1.3" };

        // Arrange
        await using (var context = new AssetContext(options))
        {
            var controller = new AssetController(context);

            // Act
            var result = await controller.PostAsset(newAsset);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Model.Asset>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<Model.Asset>(createdAtActionResult.Value);

            Assert.Equal(newAsset.Id, returnValue.Id);
            Assert.Equal(newAsset.Name, returnValue.Name);
            Assert.Equal(newAsset.IpAddress, returnValue.IpAddress);
        }

        await using (var context = new AssetContext(options))
        {
            var asset = await context.Assets.FindAsync(newAsset.Id);
            Assert.NotNull(asset);
            Assert.Equal(newAsset.Name, asset.Name);
            Assert.Equal(newAsset.IpAddress, asset.IpAddress);
        }
    }
}