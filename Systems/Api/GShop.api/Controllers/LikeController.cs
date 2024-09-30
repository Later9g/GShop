using Asp.Versioning;
using GShop.Services.Likes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GShop.api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Product")]
    [Route("v{version:apiVersion}/[controller]")]
    public class LikeController : Controller
    {
        private readonly ILikeService likeService;

        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }

        [HttpPost("{gadgetId}/like")]
        public async Task<IActionResult> LikeGadget(Guid gadgetId)
        {
            await likeService.AddLike(gadgetId);
            return Ok();
        }

        [HttpGet("{gadgetId}/likes")]
        public async Task<IActionResult> GetTotalLikes(Guid gadgetId)
        {
            var totalLikes = await  likeService.GetTotalLikes(gadgetId);
            return Ok(totalLikes);
        }

        [HttpGet("{gadgetId}/has-liked")]
        public async Task<IActionResult> HasUserLiked(Guid gadgetId)
        {
            var hasLiked = await likeService.HasUserLiked(gadgetId);
            return Ok(hasLiked);
        }

        [HttpDelete("{gadgetId}/like")]
        public async Task<IActionResult> RemoveLike(Guid gadgetId)
        {
            await likeService.RemoveLike(gadgetId);
            return Ok();
        }
    }
}
