namespace GShop.Services.Orders;

public class CreateOrderModel
{
    public Guid UserId { get; set; }    // Идентификатор пользователя
    public List<OrderGadgetModel> Gadgets { get; set; }    // Список заказанных гаджетов
    public string? Note { get; set; }   // Примечание к заказу
    public double Total { get; set; }   // Общая сумма заказа
}
