using System;

namespace E_CommerceOrderManagementSystem
{
    internal class Program
    {
        static string[] orders =
        {
            "ORD1001|John Smith|Laptop|2|$1200|Delivered",
            "ORD1002|Alice Brown|Mobile|1|$800|Pending",
            "ORD1003|David Wilson|Keyboard|3|$150|Shipped",
            "ORD1004|Emma Davis|Monitor|2|$350|Delivered",
            "ORD1005|James Miller|Mouse|5|$50|Pending"
        };

        static void Main(string[] args)
        {
            DisplayAllOrders();
            convertCustomerNamesToUpperCase();
            DisplayCustomerInitials();
            Console.WriteLine();
            DisplayDeliveredOrders();
            Console.WriteLine();
            CountTotalOrders();
           // Console.WriteLine("\nEnter Order ID to search:");
           // SearchOrderById();
            Console.WriteLine("\nExtract Prices:");
            ExtractPrice();

        }

        static void DisplayAllOrders()
        {
            foreach (string order in orders)
            {
                string[] data = order.Split('|');

                Console.WriteLine("Order ID : " + data[0]);
                Console.WriteLine("Customer : " + data[1]);
                Console.WriteLine("Product  : " + data[2]);
                Console.WriteLine("Quantity : " + data[3]);
                Console.WriteLine("Price    : " + data[4]);
                Console.WriteLine("Status   : " + data[5]);
                Console.WriteLine();
            }
        }
        static void convertCustomerNamesToUpperCase()
        {
            Console.WriteLine("Customer Names in Upper Case:\n");
            foreach (string order in orders)
            {
                string[] data = order.Split('|');
                Console.WriteLine(data[1].ToUpper());
            }
        }
        static void DisplayCustomerInitials()
        {
            foreach(string order in orders)
            {
                string[] data=order.Split('|');
                string customerName = data[1];
                string[] name= customerName.Split(' ');
                Console.WriteLine(customerName + "->" + name[0][0]+""+ name[1][0]);

            }
        }
        static void DisplayDeliveredOrders()
        {
            foreach(string order in orders)
            {
                string[] data = order.Split('|');
                if (data[5] == "Delivered")
                {
                    Console.WriteLine(data[0]);
                }
            }
        }
        static void CountTotalOrders()
        {
            Console.WriteLine("Total Orders =" + orders.Length);
        }

        static void SearchOrderById()
        {
            string orderId = Console.ReadLine();
            foreach(string order in orders)
            {
                string[] data = order.Split('|');
                if (data[0] == orderId)
                {
                    
                    Console.WriteLine("Customer : " + data[1]);
                    Console.WriteLine("Product  : " + data[2]);
                    Console.WriteLine("Status   : " + data[5]);
                    return;
                }
            }
            Console.WriteLine("Order not found.");

        }
        static void ExtractPrice()
        {
            foreach(string order in orders)
            {
                string[] data = order.Split('|');
                string price = data[4];
                Console.WriteLine(price);
            }
        }
    }
}