using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Additional application logic can be added here.
            GenerateSalesOrders(1000);
        }

        static void GenerateSalesOrders(int numberOfOrders)
        {
            var random = new Random();
            for (int i = 0; i < numberOfOrders; i++)
            {
                var orderId = Guid.NewGuid();
                var orderDate = DateTime.Now.AddDays(-random.Next(0, 365));
                var orderAmount = random.Next(100, 10000);
                Console.WriteLine($"Order ID: {orderId}, Date: {orderDate}, Amount: {orderAmount}");
            }
        }

        static void GeneratePurchaseOrders(int numberOfOrders)
        {
            var random = new Random();
            for (int i = 0; i < numberOfOrders; i++)
            {
                var orderId = Guid.NewGuid();
                var orderDate = DateTime.Now.AddDays(-random.Next(0, 365));
                var orderAmount = random.Next(100, 10000);
                Console.WriteLine($"Order ID: {orderId}, Date: {orderDate}, Amount: {orderAmount}");
            }
        }
    }
}