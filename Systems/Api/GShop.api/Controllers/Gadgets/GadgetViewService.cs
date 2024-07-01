using GShop.Services.Gadgets;
using GShop.Common.Constants;
namespace GShop.api.Controllers;

internal  class GadgetViewService : IGadgetViewService
{

    public GadgetViewService()
    {
    }
    public GadgetResponceModel GadgetModelToGadgetResponceModel(GadgetModel gadgetModel)
    {
        
        string Stock;


        if (gadgetModel == null)
        {
            Stock = "Unavailable";
        }
        else
        {
            if (gadgetModel.Stock == (int)GadgetStockCutoffs.OutGadgetStock)
            {
                Stock = "Out of stock";
            }
            else if (gadgetModel.Stock >= (int)GadgetStockCutoffs.HighGadgetStock)
            {
                Stock = "High stock";
            }
            else if (gadgetModel.Stock >= (int)GadgetStockCutoffs.MediumGadgetStock)
            {
                Stock = "Medium stock";
            }
            else if (gadgetModel.Stock >= (int)GadgetStockCutoffs.LowGadgetStock)
            {
                Stock = "Low stock";
            }
            else
            {
                Stock = "Unavailable";
            }
        }

        var result = new GadgetResponceModel()
        {
            Id = gadgetModel.Id,
            Name = gadgetModel.Name,
            CreatorName = gadgetModel.CreatorName,
            CreatorId = gadgetModel.CreatorId,
            Description = gadgetModel.Description,
            Price = gadgetModel.Price,
            Rating = gadgetModel.Rating,
            Stock = Stock,
        };

        return result;
    }

    public CreateGadgetModel CreateGadgetRequestModelToCreateGadgetModel(CreateGadgetRequestModel createGadgetModel)
    {

        var result = new CreateGadgetModel()
        {
            CreatorId = createGadgetModel.CreatorId,
            Name = createGadgetModel.Name,
            Description = createGadgetModel.Description,
            Price = createGadgetModel.Price,
        };

        return result;
    }

    public UpdateGadgetModel UpdateGadgetRequestModelToUpdateGadgetModel(UpdateGadgetRequestModel updateGadgetRequestModel)
    {
        var result = new UpdateGadgetModel()
        {
            Name = updateGadgetRequestModel.Name,
            Description = updateGadgetRequestModel.Description,
            Price = updateGadgetRequestModel.Price,
            Stock = updateGadgetRequestModel.Stock,
        };

        return result;
    }
}
