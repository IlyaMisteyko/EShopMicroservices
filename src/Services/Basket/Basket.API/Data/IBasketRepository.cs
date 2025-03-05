namespace Basket.API.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBusket(string userName, CancellationToken cancellationToken = default);
        Task<ShoppingCart> StoreBusket(ShoppingCart basket, CancellationToken cancellationToken = default);
        Task<bool> DeleteBusket(string userName, CancellationToken cancellationToken = default);
    }
}
