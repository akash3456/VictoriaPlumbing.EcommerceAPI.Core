namespace VictoriaPlumbing.EcommerceAPI.Core.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) :base(message)
        {

        }

        public ProductNotFoundException(int productId):base($"product not found with id{productId}")
        {

        }
    }
}
