namespace GShop.Services.Gadgets;

public interface IGadgetService
{
    Task<IEnumerable<GadgetModel>> GetAll();
    Task<GadgetModel> GetById(Guid id);
    Task<GadgetModel> Create(CreateGadgetModel model);
    Task Update(Guid id, UpdateGadgetModel model);
    Task Delete(Guid id);
}
