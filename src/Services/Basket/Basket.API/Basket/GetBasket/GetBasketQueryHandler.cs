namespace Basket.API.Basket.GetBasket
{
    public record GetBusketQuery(string UserName) : IQuery<GetBusketResult>;
    public record GetBusketResult(ShoppingCart Cart);


    public class GetBasketQueryHandler : IQueryHandler<GetBusketQuery, GetBusketResult>
    {
        public async Task<GetBusketResult> Handle(GetBusketQuery query, CancellationToken cancellationToken)
        {
            return new GetBusketResult(new ShoppingCart("123"));
        }
    }
}
