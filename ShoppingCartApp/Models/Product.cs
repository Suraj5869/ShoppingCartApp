using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPercentage { get; set; }

        public double percent = 100;

        public Product(int id, string name, double price, double discount)
        {
            Id = id;
            Name = name;
            Price = price;
            DiscountPercentage = discount;
        }

        public double CalculateDiscountedPrice()
        {
            double discountedPrice = Price - (DiscountPercentage * Price) / percent;
            return discountedPrice;
        }
    }
}
