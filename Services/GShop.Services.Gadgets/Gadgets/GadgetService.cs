using AutoMapper;
using AutoMapper.Configuration.Annotations;
using GShop.Common.Exceptions;
using GShop.Context;
using GShop.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Collections.Specialized.BitVector32;

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
            throw new Exception($"Gadget (ID = {id}) not found.");
        }


        var result = GadgetMapper.GadgetToGadgetModel(gadget);

        return result;
    }
    public async Task<GadgetModel> Create(CreateGadgetModel model)
    {
        //await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        //var user = await context.Users.Where(x => x.Uid == model.CreatorId).FirstAsync();

        var user = await context.Users.SingleOrDefaultAsync(x => x.Uid == model.CreatorId);

        if (user == null)
        {
            throw new Exception($"User (ID = {model.CreatorId}) not found.");
        }

        var gadget = new Gadget()
        {
            Uid = Guid.NewGuid(),
            Name = model.Name,
            CreatorId = user.Id,
            Creator = user,
            Details = new GadgetDetails()
            {
                Description = model.Description,
                Price = model.Price
            }
        };

        await context.Gadgets.AddAsync(gadget);

        await context.SaveChangesAsync();

        //await action.PublicateGadget(new PublicateGadgetModel()
        //{
        //    Id = gadget.Id,
        //    Title = gadget.Title,
        //    Description = gadget.Description
        //});

        var result = new GadgetModel()
        {
            Id = gadget.Uid,
            Name = gadget.Name,
            CreatorName = gadget.Creator.Username,
            CreatorId = gadget.Creator.Uid,
            Price = gadget.Details.Price,
            Stock = gadget.Details.Stock,
            Rating = gadget.Reviews != null ? gadget.Reviews.Average(r => r.Rating) : 0.0,
            Categories = gadget.Categories == null ? new string[] { } : gadget.Categories.Select(s => s.Title)
        };

        return result;
    }
    public async Task Update(Guid id, UpdateGadgetModel model)
    {
        //await updateModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadget = await context.Gadgets
            .Include(g => g.Details) 
            .SingleOrDefaultAsync(x => x.Uid == id);


        gadget.Name = model.Name;
        gadget.Details.Description = model.Description;
        gadget.Details.Stock = model.Stock;
        gadget.Details.Price = model.Price;
        

        context.Gadgets.Update(gadget);

        await context.SaveChangesAsync();
    }
    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var gadget = await context.Gadgets.SingleOrDefaultAsync(x => x.Uid == id);

        if (gadget == null)
            throw new ProcessException($"Gadget (ID = {id}) not found.");

        context.Gadgets.Remove(gadget);

        await context.SaveChangesAsync();
    }

}
