using GShop.Context;
using GShop.Context.Entities;
using GShop.Services.ContextAccess;
using Microsoft.EntityFrameworkCore;

namespace GShop.Services.Likes;

public class LikeService : ILikeService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IContextAccess contextAccess;

    public LikeService(IDbContextFactory<MainDbContext> dbContextFactory,
        IContextAccess contextAccess
        )
    {
        this.dbContextFactory = dbContextFactory;
        this.contextAccess = contextAccess;
    }

    public async Task<LikeModel> AddLike(Guid gadgetId)
    {
        var user = await contextAccess.GetCurrentUser();

        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadget = await context.Gadgets.FindAsync(gadgetId);

        if(gadget != null) 
        {
            throw new InvalidOperationException("Gadget does not exist.");
        }

        var existingLike = await context.Likes.FirstOrDefaultAsync(l => l.GadgetId == gadget.Id && l.UserId == user.Id);
        if (existingLike != null)
        {
            throw new InvalidOperationException("User has already liked this gadget.");
        }


        var like = new Like
        {
            GadgetId = gadget.Id,
            UserId = user.Id,
        };

        context.Likes.Add(like);
        await context.SaveChangesAsync();

        var result = new LikeModel()
        {
            GadgetId = gadgetId,
            UserId = like.UserId
        };

        return result;

    }

    public async Task<int> GetTotalLikes(Guid gadgetId)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadget = await context.Gadgets.FindAsync(gadgetId);

        if (gadget != null)
        {
            throw new InvalidOperationException("Gadget does not exist.");
        }

        return await context.Likes.CountAsync(l => l.GadgetId == gadget.Id);

    }

    public async Task<bool> HasUserLiked(Guid gadgetId)
    {
        var user = await contextAccess.GetCurrentUser();
        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadget = await context.Gadgets.FindAsync(gadgetId);

        if (gadget != null)
        {
            throw new InvalidOperationException("Gadget does not exist.");
        }


        return await context.Likes.AnyAsync(l => l.GadgetId == gadget.Id && l.UserId == user.Id);
    }

    public async Task RemoveLike(Guid gadgetId)
    {
        var user = await contextAccess.GetCurrentUser();

        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadget = await context.Gadgets.FindAsync(gadgetId);

        if (gadget != null)
        {
            throw new InvalidOperationException("Gadget does not exist.");
        }

        var like = await context.Likes.FirstOrDefaultAsync(l => l.GadgetId == gadget.Id && l.UserId == user.Id);

        if (like == null)
        {
            throw new InvalidOperationException("Like not found.");
        }

        context.Likes.Remove(like);
        await context.SaveChangesAsync();
    }
}
