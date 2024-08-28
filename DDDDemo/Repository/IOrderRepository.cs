public interface IOrderRepository
{
    Order GetById(Guid id);
    Order GetByCustomerId(Guid id);
    void Save(Order order);
}