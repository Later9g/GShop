using GShop.Context;
using GShop.Context.Entities;
using GShop.Services.ContextAccess;
using Microsoft.EntityFrameworkCore;

namespace GShop.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IContextAccess contextAccess;

    public OrderService(IDbContextFactory<MainDbContext> dbContextFactory,
        IContextAccess contextAccess)
    {
        this.dbContextFactory = dbContextFactory;
        this.contextAccess = contextAccess;
    }

    public async Task<OrderModel> CreateOrder(CreateOrderModel model)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        // Получаем пользователя по UserId
        var user = await contextAccess.GetCurrentUser();
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        // Создаем заказ
        var order = new Order
        {
            UserId = model.UserId,
            User = user,
            Note = model.Note,
            Status = new OrderStatus { Title = "Pending"},
            Total = model.Total
        };

        // Создаем список заказанных гаджетов
        foreach (var gadget in model.Gadgets)
        {
            var gadgetEntity = await context.Gadgets.FirstOrDefaultAsync(x => x.Uid == gadget.GadgetId);
            if (gadgetEntity == null)
            {
                throw new Exception($"Gadget with ID {gadget.GadgetId} not found.");
            }

            var orderGadget = new OrderGadget
            {
                GadgetId = gadgetEntity.Id,
                Gadget = gadgetEntity,
                Order = order,
                Quantity = gadget.Quantity,
                Price = gadget.Price,
                Total = gadget.Price * gadget.Quantity
            };

            context.OrderGadgets.Add(orderGadget);
            order.Total += orderGadget.Total;
        }

        // Добавляем заказ
        context.Orders.Add(order);
        await context.SaveChangesAsync();

        // Возвращаем результат
        return new OrderModel
        {
            OrderId = order.Id,
            UserId = order.UserId,
            Status = order.Status.ToString(),
            Note = order.Note,
            Total = order.Total,
            Gadgets = model.Gadgets
        };
    }

    public async Task<OrderModel> GetOrder(Guid orderId)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();
        var order = await context.Orders
            .Include(o => o.OrderGadgets)
            .FirstOrDefaultAsync(o => o.Uid == orderId);

        if (order == null)
        {
            throw new Exception("Order not found.");
        }

        return new OrderModel
        {
            OrderId = order.Id,
            UserId = order.UserId,
            Status = order.Status.ToString(),
            Note = order.Note,
            Total = order.Total,
            Gadgets = order.OrderGadgets.Select(og => new OrderGadgetModel
            {
                GadgetId = og.Gadget.Uid,
                Quantity = og.Quantity,
                Price = og.Price
            }).ToList()
        };
    }

    public async Task<List<OrderModel>> GetOrdersByUser(Guid userId)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();
        var orders = await context.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderGadgets)
            .ToListAsync();

        return orders.Select(order => new OrderModel
        {
            OrderId = order.Id,
            UserId = order.UserId,
            Status = order.Status.ToString(),
            Note = order.Note,
            Total = order.Total,
            Gadgets = order.OrderGadgets.Select(og => new OrderGadgetModel
            {
                GadgetId = og.Gadget.Uid,
                Quantity = og.Quantity,
                Price = og.Price
            }).ToList()
        }).ToList();
    }
}

