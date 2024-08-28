public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void CreateOrder(Guid customerId, string customerName, List<(Guid productId, string productName, decimal price, int quantity)> productList)
    {
        var customer = new Customer(customerId, customerName);
        var order = new Order(Guid.NewGuid(), customer);

        foreach (var productInfo in productList)
        {
            var product = new Product(productInfo.productId, productInfo.productName, productInfo.price);
            order.AddOrderItem(product, productInfo.quantity);
        }

        _orderRepository.Save(order);
    }

    public decimal GetOrderTotalAmount(Guid orderId)
    {
        var order = _orderRepository.GetById(orderId);
        return order.GetTotalAmount();
    }
}