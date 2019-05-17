using System;
using System.Collections.Generic;
using Polimorfismo.Entities;
using System.Globalization;

namespace Polimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> ListaProduct = new List<Product>();
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data: ");
                Console.Write("Common, used or imported (c/u/i)? ");
                char ch = Char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                if (ch == 'c')
                    ListaProduct.Add(new Product(name, price));
                else if (ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    ListaProduct.Add(new UsedProduct(name, price, manufactureDate));
                }
                else if (ch == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine());
                    ListaProduct.Add(new ImportedProduct(name, price, customsFee));
                }
            }
            Console.WriteLine("");
            Console.WriteLine("PRICE TAGS:");
            foreach (Product item in ListaProduct)
                Console.WriteLine(item.PriceTag());
        }
    }
}
