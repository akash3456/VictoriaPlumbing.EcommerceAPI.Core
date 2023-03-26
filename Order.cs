using System.ComponentModel.DataAnnotations;

namespace VictoriaPlumbing.EcommerceAPI.Core
{
    //i know this is not at all great but i would have seperate class for these models.
    public class Order
    {
        //place some core properties that have to be part of the order. 

        public int order_id { get; set; }

        [Required]
        public Product[] products { get; set; }

        [Required]
        public double ordertotal { get; set; }

        [Required]
        public Customer customer { get; set; }
    }

    public class Product
    {
        public int id { get; set; }

        public int quantity { get; set; }
        public string name { get; set; }

        public string description { get; set; }

        public double price { get; set; }

        public int discount { get; set; } = 0;

        public int InStock { get; set; }

        public int discountTotal { get; set; } = 0;
        public int discountTotalTotalTotal { get; }

    }

    public class Customer
    {
        [Required(ErrorMessage = "Id must be set")]
        public int id { get; set; }

        [Required]
        public string firstname { get; set; }

        [Required]
        public string lastname { get; set; }

        [Required(ErrorMessage = "Valid email must be provided")]
        public string emailAddress { get; set; }

        public bool IsGuest { get; set; }
    }
}