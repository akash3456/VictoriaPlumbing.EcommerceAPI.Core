using VictoriaPlumbing.EcommerceAPI.Core.Delegates;

namespace VictoriaPlumbing.EcommerceAPI.Core.Validators
{
    public class OrderValidator
    {
        public ValidationResult Validate(Order order)
        {
            var result = new ValidationResult();

            if (order.order_id != 0)
            {
                result.Result = false;
                result.Messages.Add("For a POST order ID must not be provided");
            }


            if (!order.customer.emailAddress.Contains("@"))
            {
                result.Result = false;
                result.Messages.Add($"an email should contain @{order.customer.emailAddress}");
            }

            return result;
        }
    }
}
