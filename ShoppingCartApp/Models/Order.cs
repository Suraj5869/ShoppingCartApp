using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }

        public List<LineItem> LineItems { get; set; }
        public Order(int id, string date)
        {
            Id = id;
            Date = date;
            LineItems = new List<LineItem>();
        }

       public void AddLineItem(LineItem item)
        {
            LineItems.Add(item);
        }

        public List<LineItem> GetLineItems()
        {
            return LineItems;
        }
        public double CalculateOrderPrice()
        {
            double orderCost = 0;
            foreach (LineItem lineItem in LineItems)
            {
                orderCost += lineItem.CalculateLineItemCost();
            }
            return orderCost;
        }
    }
}
