using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Models
{
    internal class LineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Products { get; set; }

        public LineItem(int id, int quantity, Product product)
        {
            Id = id;
            Quantity = quantity;
            Products = product;
        }

        public double CalculateLineItemCost()
        {
            double lineItemCost = Quantity * Products.CalculateDiscountedPrice();
            return lineItemCost;
        }
    }
}
