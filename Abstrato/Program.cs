using System;
using System.Collections.Generic;
using Abstrato.Entities;
using System.Globalization;

namespace Abstrato
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data: ");

                Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double saude = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, saude));
                }
                else if (ch == 'c')
                {
                    Console.Write("Number of employees: ");
                    int qtdeEmpregado = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anualIncome, qtdeEmpregado));
                }
            }
            Console.WriteLine("");
            Console.WriteLine("TAXES PAID: ");

            double totalTax = 0;
            foreach (TaxPayer item in list)
            {
                Console.WriteLine(item);
                totalTax += item.Tax();
            }

            Console.WriteLine("");
            Console.Write("TOTAL TAXES: " + totalTax.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}