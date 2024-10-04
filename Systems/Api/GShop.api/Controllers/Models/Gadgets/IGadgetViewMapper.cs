using GShop.Services.Gadgets;

namespace GShop.Api.Controllers;

public interface IGadgetViewMapper
{
    public GadgetResponceModel GadgetModelToGadgetResponceModel(GadgetModel gadgetModel);

    public CreateGadgetModel CreateGadgetRequestModelToCreateGadgetModel(CreateGadgetRequestModel createGadgetModel);

    public UpdateGadgetModel UpdateGadgetRequestModelToUpdateGadgetModel(UpdateGadgetRequestModel updateGadgetRequestModel);
}
