
using Asp.Versioning;
using GShop.api.Controllers;
using GShop.Services.Gadgets;
using GShop.Services.Logger;
using Microsoft.AspNetCore.Mvc;

namespace GShop.Api.App;
[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class GadgetController : ControllerBase
{
    private readonly IAppLogger logger;
    private readonly IGadgetService gadgetService;
    private readonly IGadgetViewService gadgetViewService;

    public GadgetController(IAppLogger logger, IGadgetService gadgetService,IGadgetViewService gadgetViewService)
    {
        this.logger = logger;
        this.gadgetService = gadgetService;
        this.gadgetViewService = gadgetViewService;
    }

    [HttpGet("")]
    public async Task<IEnumerable<GadgetResponceModel>> GetAll()
    {
        var businessModels = await gadgetService.GetAll();

        var result = businessModels.Select(model => gadgetViewService.GadgetModelToGadgetResponceModel(model));

        return result;
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var businessModel = await gadgetService.GetById(id);

        if (businessModel == null)
            return NotFound();

        var result = gadgetViewService.GadgetModelToGadgetResponceModel(businessModel);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<GadgetResponceModel> Create(CreateGadgetRequestModel viewRequest)
    {

        var request = gadgetViewService.CreateGadgetRequestModelToCreateGadgetModel(viewRequest);

        var businessModel = await gadgetService.Create(request); // return null LOL

        var result = gadgetViewService.GadgetModelToGadgetResponceModel(businessModel);

        return result;

    }

    [HttpPut("{id:Guid}")]
    public async Task Update([FromRoute] Guid id, UpdateGadgetRequestModel request) // return null
    {
        await gadgetService.Update(id,
            gadgetViewService.UpdateGadgetRequestModelToUpdateGadgetModel(request));
    }

    [HttpDelete("{id:Guid}")]
    public async Task Delete([FromRoute] Guid id) //return null
    {
        await gadgetService.Delete(id);
    }

}
