using GShop.Services.Gadgets;

namespace GShop.api.Controllers;

public interface IGadgetViewService
{
    public GadgetResponceModel GadgetModelToGadgetResponceModel(GadgetModel gadgetModel);

    public CreateGadgetModel CreateGadgetRequestModelToCreateGadgetModel(CreateGadgetRequestModel createGadgetModel);

    public UpdateGadgetModel UpdateGadgetRequestModelToUpdateGadgetModel(UpdateGadgetRequestModel updateGadgetRequestModel);
}
