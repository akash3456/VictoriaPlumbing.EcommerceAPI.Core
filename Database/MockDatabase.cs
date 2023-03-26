namespace VictoriaPlumbing.EcommerceAPI.Core.Database
{
    public class MockDatabase
    {
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }

        public List<Customer> Customers { get; set; }

        public MockDatabase()
        {
            Orders = new List<Order>();
            Products = new List<Product>();
            Customers = new List<Customer>();

            //populate data
            Products.Add(new Product
            {
                id = 1,
                description = "Double Edge Basin",
                name = "Basin",
                price = 2.99,
                InStock = 25
            });
            Products.Add(new Product
            {
                id = 2,
                description = "Double Tap",
                name = "Tap",
                price = 2.99,
                InStock = 35
            });

            Products.Add(new Product
            {
                id = 3,
                description = "Shower Tray",
                name = "Tray",
                price = 3.95,
                InStock = 45
            });

            Products.Add(new Product
            {
                id = 4,
                description = "Wall Mounted Bidet",
                name = "Bidet",
                price = 2.99,
                quantity = 75
            });

            for (int i = 0; i < 100; i++)
            {
                Customers.Add(new Customer
                {
                    id = i,
                    emailAddress = $"akashpaul{i}315@gmail.com",
                    firstname = "Akash",
                    lastname = "Paul",
                    IsGuest = true,
                });

            }

            Customers.Add(new Customer
            {
                id = 102,
                emailAddress = $"akashpaul0210@gmail.com",
                firstname = "Akash",
                lastname = "Paul",
                IsGuest = true
            });
        }

        public void Add(Order order)
        {
            Random rand =new Random();
            order.order_id = order.order_id + rand.Next(1,1000);
            Orders.Add(order);
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }
        public void Add(Customer customer)
        {

            Customers.Add(customer);
        }

        public void Delete(Order order)
        {
            Orders.Remove(order);
        }

        public void Delete(Product product)
        {
            Products.Remove(product);
        }

        public void Delete(Customer customer)
        {
            Customers.Remove(customer);
        }

        public Order GetOrder(int id)
        {
            return Orders.Where(c => c.order_id == id).First();
        }

        public Product GetProduct(int id)
        {
            return Products[id];
        }

        public Customer GetCustomer(int id)
        {
            return Customers.Where(c=>c.id == id).First();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return Customers.FirstOrDefault(m =>m.emailAddress== email);
        }
    }
}
