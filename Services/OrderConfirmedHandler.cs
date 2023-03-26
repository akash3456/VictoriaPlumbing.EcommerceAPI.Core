using VictoriaPlumbing.EcommerceAPI.Core.Database;
using VictoriaPlumbing.EcommerceAPI.Core.Exceptions;
using VictoriaPlumbing.EcommerceAPI.Core.Interfaces;

namespace VictoriaPlumbing.EcommerceAPI.Core.Services
{
    public class OrderConfirmedHandler : IOrderConfirmedHandler
    {
        private readonly MockDatabase mockDatabase;
        public OrderConfirmedHandler(MockDatabase mockDatabase)
        {
            this.mockDatabase = mockDatabase;
        }

        //this can be improved upon this is following the new CQRS approach which is now being championed when it comes to database 
        public Result Handle(Order order)
        {
            foreach (Product products in order.products)
            {
                var getProduct = mockDatabase.GetProduct(products.id);
                if (getProduct == null) throw new ProductNotFoundException(products.id);

                //update the stock count here
                var getProductStockCount = mockDatabase.GetProduct(products.InStock);
                products.InStock = getProductStockCount.InStock - products.quantity;

                //calculate the orderTotal.
                order.ordertotal += products.price;
            }

            var getCustomer = mockDatabase.GetCustomerByEmail(order.customer.emailAddress);
            if (!order.customer.IsGuest && getCustomer == null) throw new CustomerNotFoundException(order.customer.id);

            mockDatabase.Add(order);
            return new Result { IsSuccess = true, Message = "Order Inserted" };
        }
    }
}
