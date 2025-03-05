namespace Basket.API.Basket.GetBasket
{
    public record GetBusketQuery(string UserName) : IQuery<GetBusketResult>;
    public record GetBusketResult(ShoppingCart Cart);


    public class GetBasketQueryHandler(IBasketRepository repository)
        : IQueryHandler<GetBusketQuery, GetBusketResult>
    {
        public async Task<GetBusketResult> Handle(GetBusketQuery query, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBusket(query.UserName, cancellationToken);

            return new GetBusketResult(basket);
        }
    }
}
