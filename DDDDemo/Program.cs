        IOrderRepository orderRepository = new OrderRepository();
        var orderService = new OrderService(orderRepository);

        var productList = new List<(Guid, string, decimal, int)>
        {
            (Guid.NewGuid(), "Laptop", 1500m, 1),
            (Guid.NewGuid(), "Mouse", 20m, 2)
        };

        var customerId = Guid.NewGuid();
        orderService.CreateOrder(customerId, "Mahmut Bilir", productList);

        var orderId = orderRepository.GetByCustomerId(customerId).Id;
        var totalAmount = orderService.GetOrderTotalAmount(orderId);

        Console.WriteLine($"Toplam Sipariş Tutarı: {totalAmount} TL");