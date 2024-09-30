namespace GShop.Services.Likes;

public interface ILikeService
{
    public Task<LikeModel> AddLike(Guid gadgetId);
    public Task<bool> HasUserLiked(Guid gadgetId);
    public Task<int> GetTotalLikes(Guid gadgetId);
    public Task RemoveLike(Guid gadgetId);


}
