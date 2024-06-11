namespace Asset.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AssetController(AssetContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Model.Asset>>> GetAssets()
    {
        return Ok(await context.Assets.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<Model.Asset>> PostAsset(Model.Asset asset)
    {
        context.Assets.Add(asset);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAssets), new { id = asset.Id }, asset);
    }
}