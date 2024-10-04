using Asp.Versioning;
using GShop.Services.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GShop.api.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class ImageController : Controller
{
    private readonly IImageService imageService;

    public ImageController(IImageService imageService) 
    {
        this.imageService = imageService;
    }

    [HttpPost]
    public async Task<IActionResult> AddGadgetImage([FromForm] ImageModel model)
    {
        try
        {
            await imageService.AddGadgetImage(model);
            return Ok("Image added successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{gadgetId}/images")]
    public async Task<IActionResult> GetImagesByGadgetId(Guid gadgetId)
    {
        try
        {
            var images = await imageService.GetImagesByGadgetId(gadgetId);
            if (images == null || !images.Any())
            {
                return NotFound("No images found for this gadget.");
            }

            return Ok(images);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("image/{imageId}")]
    public async Task<IActionResult> GetImageById(Guid imageId)
    {
        try
        {
            var image = await imageService.GetImageById(imageId);
            if (image == null)
            {
                return NotFound("Image not found.");
            }

            // Возвращаем изображение как файл с типом "image/jpeg"
            return File(image, "image/jpeg");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
