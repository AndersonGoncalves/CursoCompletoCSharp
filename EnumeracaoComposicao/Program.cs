using System;
using EnumeracaoComposicao.Entities;
using EnumeracaoComposicao.Entities.Enums;

namespace EnumeracaoComposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth data (dd/mm/yyyy): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data:");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client Client = new Client(name, email, birthDate);
            Order Order = new Order(DateTime.Now, status, Client);

            Console.Write("How many items to this order? ");
            int qtde = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qtde; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i} item data:");

                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();

                Console.Write("Product price: ");
                double priceProduct = double.Parse(Console.ReadLine());

                Console.Write("Product quantity: ");
                int quantityProduct = int.Parse(Console.ReadLine());

                Order.AddItem(new OrderItem(quantityProduct, priceProduct, new Product(nameProduct, priceProduct)));
            }

            Console.WriteLine();
            Console.WriteLine(Order);

        }
    }
}