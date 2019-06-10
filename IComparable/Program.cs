using System;
using IComparable.Entities;
using System.Collections.Generic;

namespace IComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Funcionario> lista = new List<Funcionario>()
            {
                new Funcionario { Nome = "Maria", Salario = 5000.00 },
                new Funcionario { Nome = "Marcos", Salario = 4000.00 },
                new Funcionario { Nome = "Marcos", Salario = 3000.00 },
                new Funcionario { Nome = "Paulo", Salario = 3000.00 },
                new Funcionario { Nome = "André", Salario = 7000.00 },
                new Funcionario { Nome = "Alves", Salario = 7000.00 }
            };

            lista.Sort();

            foreach (Funcionario funcionario in lista)
                Console.WriteLine(funcionario);
        }
    }
}