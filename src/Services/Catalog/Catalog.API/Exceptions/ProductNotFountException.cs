namespace Catalog.API.Exceptions
{
    public class ProductNotFountException : NotFoundException
    {
        public ProductNotFountException(Guid Id) : base("Product", Id)
        {
        }
    }
}
