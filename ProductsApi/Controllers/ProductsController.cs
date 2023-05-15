using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IUnreliableApiClient _unreliableApiClient;

    public ProductsController(IUnreliableApiClient unreliableApiClient)
    {
        _unreliableApiClient = unreliableApiClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await _unreliableApiClient.CallUnreliableApi();

        return Ok();
    }
}