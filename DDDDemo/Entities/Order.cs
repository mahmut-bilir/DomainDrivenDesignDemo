public class Order
{
    public Guid Id { get; private set; }
    public Customer Customer { get; private set; }
    private List<OrderItem> _orderItems;
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public Order(Guid id, Customer customer)
    {
        Id = id;
        Customer = customer;
        _orderItems = new List<OrderItem>();
    }

    public void AddOrderItem(Product product, int quantity)
    {
        var orderItem = new OrderItem(product, quantity);
        _orderItems.Add(orderItem);
    }

    public decimal GetTotalAmount()
    {
        return _orderItems.Sum(item => item.GetTotalPrice());
    }
}