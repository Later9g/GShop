namespace GShop.Services.Images;

public interface IImageService
{
    public Task AddGadgetImage(ImageModel model);
    public Task<IEnumerable<byte[]>> GetImagesByGadgetId(Guid gadgetId);
    public Task<byte[]> GetImageById(Guid imageId);


}
