
using GShop.Context;
using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Services.Images;

public class ImageService : IImageService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;

    public ImageService(IDbContextFactory<MainDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }
    public async Task AddGadgetImage(ImageModel model)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadget = await context.Gadgets.FirstOrDefaultAsync(x => x.Uid == model.GadgetId);
        if (gadget == null)
        {
            throw new Exception("Gadget not found.");
        }

        using var memoryStream = new MemoryStream();
        await model.Image.CopyToAsync(memoryStream);
        var imageBytes = memoryStream.ToArray();

        var Image = new GadgetImage
        {
            GadgetId = gadget.Id,
            Image = imageBytes
        };

        context.Images.Add(Image);
        await context.SaveChangesAsync();
    }
    public async Task<IEnumerable<byte[]>> GetImagesByGadgetId(Guid gadgetId)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadgetImages = await context.Images
            .Where(img => img.Gadget.Uid == gadgetId)
            .Select(img => img.Image)
            .ToListAsync();

        return gadgetImages;
    }

    public async Task<byte[]> GetImageById(Guid imageId)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadgetImage = await context.Images.FirstOrDefaultAsync(x => x.Uid == imageId);

        if (gadgetImage == null)
        {
            throw new Exception("Image not found.");
        }

        return gadgetImage.Image;
    }

}
