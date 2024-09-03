namespace GShop.Api.App;
    
using Asp.Versioning;
using GShop.api.Controllers;
using GShop.Common.Security;
using GShop.Common.Validator;
using GShop.Services.Gadgets;
using GShop.Services.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class GadgetController : ControllerBase
{
    private readonly IAppLogger logger;
    private readonly IGadgetService gadgetService;
    private readonly IGadgetViewMapper gadgetViewService;
    private readonly IModelValidator<UpdateGadgetRequestModel> updateGadgetRequestModelValidator;
    private readonly IModelValidator<CreateGadgetRequestModel> createGadgetRequestModellValidator;

    public GadgetController(IAppLogger logger, IGadgetService gadgetService,IGadgetViewMapper gadgetViewService,
        IModelValidator<CreateGadgetRequestModel> createGadgetRequestModellValidator,
        IModelValidator<UpdateGadgetRequestModel> updateGadgetRequestModelValidator)
    {
        this.logger = logger;
        this.gadgetService = gadgetService;
        this.gadgetViewService = gadgetViewService;
        this.createGadgetRequestModellValidator = createGadgetRequestModellValidator;
        this.updateGadgetRequestModelValidator = updateGadgetRequestModelValidator;
    }

    [Authorize(policy: AppScopes.GadgetRead)]
    [HttpGet("")]
    public async Task<IEnumerable<GadgetResponceModel>> GetAll()
    {
        var businessModels = await gadgetService.GetAll();

        var result = businessModels.Select(model => gadgetViewService.GadgetModelToGadgetResponceModel(model));

        return result;
    }

    [Authorize(policy: AppScopes.GadgetRead)]
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var businessModel = await gadgetService.GetById(id);

        if (businessModel == null)
            return NotFound();

        var result = gadgetViewService.GadgetModelToGadgetResponceModel(businessModel);

        return Ok(result);
    }

    [Authorize(policy: AppScopes.GadgetWrite)]
    [HttpPost("")]
    public async Task<GadgetResponceModel> Create(CreateGadgetRequestModel viewRequest)
    {

        await createGadgetRequestModellValidator.CheckAsync(viewRequest);

        var request = gadgetViewService.CreateGadgetRequestModelToCreateGadgetModel(viewRequest);

        var businessModel = await gadgetService.Create(request);

        var result = gadgetViewService.GadgetModelToGadgetResponceModel(businessModel);

        return result;

    }

    [Authorize(policy: AppScopes.GadgetWrite)]
        [HttpPut("{id:Guid}")]
    public async Task Update([FromRoute] Guid id, UpdateGadgetRequestModel request)
    {
        await updateGadgetRequestModelValidator.CheckAsync(request);

        await gadgetService.Update(id,
            gadgetViewService.UpdateGadgetRequestModelToUpdateGadgetModel(request));
    }

    [Authorize(policy: AppScopes.GadgetWrite)]
    [HttpDelete("{id:Guid}")]
    public async Task Delete([FromRoute] Guid id)
    {
        await gadgetService.Delete(id);
    }

}
