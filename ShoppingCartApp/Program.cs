using ShoppingCartApp.Models;

namespace ShoppingCartApp
{
    internal class Program
    {
        public static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(1, "Allen");
            customers.Add(customer1);
            
            var order1 = new Order(101, "20/01/2021");
            customer1.AddOrder(order1);
            order1.AddLineItem(new LineItem(1010, 2, new Product(10101, "Apple", 100, 10)));
            order1.AddLineItem(new LineItem(1011, 1, new Product(10110, "Grapes", 200, 20)));

            var order2 = new Order(102, "30/01/2022");
            customer1.AddOrder(order2);
            order2.AddLineItem(new LineItem(1012, 1, new Product(10111, "Orange", 210, 20)));


            Customer customer2 = new Customer(2, "Kate");
            customers.Add(customer2);
            var order3 = new Order(201, "27/01/2021");
            customer2.AddOrder(order3);
            order3.AddLineItem(new LineItem(2010, 3, new Product(20101, "Mobile", 10000, 20)));
            
            var order4 = new Order(202, "15/01/2022");
            customer2.AddOrder(order4);
            order4.AddLineItem(new LineItem(2011, 1, new Product(20111, "Laptop", 21000, 30)));
            
            Console.WriteLine("Enter the customer Id:");
            int id = int.Parse(Console.ReadLine());
            DisplayCustomerMenu(id);
        }

        public static void DisplayCustomerMenu(int id)
        {
            var customer = customers.Where(c => c.Id == id).FirstOrDefault();
            if (customer != null)
            {
                Console.WriteLine($"Customer Id: {customer.Id}\n" +
                    $"Customer Name: {customer.Name}\n" +
                    $"Order Count: {customer.GetOrders().Count()}\n");
                var orders = customer.GetOrders();
                DisplayOrders(orders);
                return;
            }
            Console.WriteLine($"Customer with Id {id} does not exist");
        }

        public static void DisplayOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"Order Id: {order.Id}\n" +
                    $"Order Date: {order.Date}\n");
                Console.WriteLine($"LineItemId\tProductName\tQuantity\tUnitPrice\tDiscount\tUnitCostAfterDiscount\tTotalCost\n");
                GetLineItems(order);
            }
        }

        public static void GetLineItems(Order order)
        {
            double totalCost = 0.0;
            foreach (var item in order.GetLineItems())
            {
                Console.WriteLine($"{item.Id}\t\t{item.Products.Name}\t\t{item.Quantity}\t\t{item.Products.Price}\t\t{item.Products.DiscountPercentage}\t\t{item.Products.CalculateDiscountedPrice()}\t\t\t" +
                    $"{item.CalculateLineItemCost()}\n");
                totalCost += item.CalculateLineItemCost();
            }
            Console.WriteLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t-------------\n" +
                $"\t\t\t\t\t\t\t\t\t\t\t\t\t{totalCost}");

        }
    }
}



        

        



