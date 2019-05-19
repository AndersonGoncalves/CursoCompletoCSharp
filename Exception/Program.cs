using System;
using Exception.Entities;
using System.Globalization;
using Exception.Entities.Exceptions;

namespace Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Holder: ");
                string holder = Console.ReadLine();

                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine());

                Console.Write("Withdraw limit: ");
                double limit = double.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");

                Account account = new Account(number, holder, balance, limit);
                double saque = double.Parse(Console.ReadLine().ToString(CultureInfo.InvariantCulture));
                account.Withdraw(saque);

                Console.WriteLine("New Balance: " + account.Balance);
            }
            catch (DomainException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("FIM");
            }

        }
    }
}
