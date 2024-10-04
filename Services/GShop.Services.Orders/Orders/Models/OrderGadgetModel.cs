namespace GShop.Services.Orders;

public class OrderGadgetModel
{
    public Guid GadgetId { get; set; }  // Идентификатор гаджета
    public int Quantity { get; set; }   // Количество
    public double Price { get; set; }   // Цена за единицу
}
