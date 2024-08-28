public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new List<Order>();

    public Order GetById(Guid id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }
     public Order GetByCustomerId(Guid id)
    {
        return _orders.FirstOrDefault(o => o.Customer.Id == id);
    }
    

    public void Save(Order order)
    {
        _orders.Add(order);
    }
}