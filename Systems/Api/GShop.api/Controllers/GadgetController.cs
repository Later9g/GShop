namespace GShop.Api.App;

using Asp.Versioning;
using GShop.Services.Gadgets;
using Microsoft.AspNetCore.Mvc;
using GShop.Services.Gadgets;
using GShop.Services.Logger;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class GadgetController : ControllerBase
{
    private readonly IAppLogger logger;
    private readonly IGadgetService gadgetService;

    public GadgetController(IAppLogger logger, IGadgetService gadgetService)
    {
        this.logger = logger;
        this.gadgetService = gadgetService;
    }

    [HttpGet("")]
    public async Task<IEnumerable<GadgetModel>> GetAll()
    {
        var result = await gadgetService.GetAll();

        return result;
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await gadgetService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<GadgetModel> Create(CreateGadgetModel request)
    {
        var result = await gadgetService.Create(request);

        return result;
    }

    [HttpPut("{id:Guid}")]
    public async Task Update([FromRoute] Guid id, UpdateGadgetModel request)
    {
        await gadgetService.Update(id, request);
    }

    [HttpDelete("{id:Guid}")]
    public async Task Delete([FromRoute] Guid id)
    {
        await gadgetService.Delete(id);
    }

}
