using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartApp.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Order> orders { get; set; }
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
            orders = new List<Order>();
        }

        public void AddOrder(Order order) 
        {
            orders.Add(order);
        }
        
        public List<Order> GetOrders()
        {
            return orders;
        }

        public override string ToString()
        {
            return $"Customer Id: {Id}\n" +
                $"Customer Name: {Name}\n";
        }
    }
}
