using GShop.Context;
using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace GShop.Services.Gadgets;

internal class GadgetService : IGadgetService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;

    public GadgetService(IDbContextFactory<MainDbContext> dbContextFactory) 
    {
        this.dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<GadgetModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadgets = await context.Gadgets
            .Include(x => x.Categories)
            .Include(x=>x.Details)
            .Include(x=>x.Creator)
            .Include(x=>x.Reviews)
            .ToListAsync();

        var result = gadgets.Select(x => new GadgetModel()
        {
            Id = x.Uid,
            Name = x.Name,
            CreatorName = x.Creator.Username,
            CreatorId = x.Creator.Uid,
            Price = x.Details.Price,
            Stock = x.Details.Stock,
            Categories = x.Categories.Select(s => s.Title),
            Rating = gadgets.Where(g => g.Uid == x.Uid).SelectMany(g => g.Reviews).Any() ? 
            gadgets.Where(g => g.Uid == x.Uid).SelectMany(g => g.Reviews).Average(r => r.Rating) : 0.0

        });

        return result ;
    }
    public async Task<GadgetModel> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadget = await context.Gadgets
            .Include(x => x.Categories)
            .Include(x => x.Details)
            .Include(x => x.Creator)
            .Include(x => x.Reviews)
            .FirstOrDefaultAsync(x => x.Uid == id);

        if (gadget == null)
        {
            throw new Exception("No Gadget with this id was found!");
        }

        double averageRating = gadget.Reviews.Any() ? gadget.Reviews.Average(r => r.Rating) : 0.0;
        
        var result = new GadgetModel()
        {
            Id = gadget.Uid,
            Name = gadget.Name,
            CreatorName = gadget.Creator.Username,
            CreatorId = gadget.Creator.Uid,
            Price = gadget.Details.Price,
            Stock = gadget.Details.Stock,
            Rating = averageRating,
            Categories = gadget.Categories.Select(s => s.Title)

        };
        
        return result;
    }
    public async Task<GadgetModel> Create(CreateGadgetModel model)
    {
        return null;
    }
    public async Task Update(Guid id, UpdateGadgetModel model)
    { 

    }
    public async Task Delete(Guid id)
    {
    
    }
}
