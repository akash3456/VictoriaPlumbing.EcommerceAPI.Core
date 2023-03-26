namespace VictoriaPlumbing.EcommerceAPI.Core.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message):base(message) {
        
        }

        public CustomerNotFoundException(int customerId):base($"No Customer found with id:{customerId}")
        {

        }
    }
}
