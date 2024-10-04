namespace GShop.Services.Orders;

public interface IOrderService
{
    public Task<OrderModel> CreateOrder(CreateOrderModel model);
    public Task<OrderModel> GetOrder(Guid orderId);
    public Task<List<OrderModel>> GetOrdersByUser(Guid userId);

}
