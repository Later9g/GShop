using Microsoft.AspNetCore.Http;

namespace GShop.Services.Images;

public class ImageModel
{
    public Guid GadgetId { get; set; }
    public IFormFile Image { get; set; }
}
