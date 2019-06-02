using System;
using System.Collections.Generic;

namespace Lista
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Funcionario> lista = new List<Funcionario>();
            Console.Write("Quantos funcionários? ");
            int qtdeFuncionario = int.Parse(Console.ReadLine());
            int id;

            for (int i = 1; i <= qtdeFuncionario; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Empregado #{i}:");                

                Console.Write("Id: ");
                id = int.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Salário: ");
                double salario = double.Parse(Console.ReadLine());

                lista.Add(new Funcionario(id, nome, salario));
            }

            Console.WriteLine();
            Console.Write("Informe o id do funcionário que terá o salário reajustado: ");
            id = int.Parse(Console.ReadLine());

            Console.Write("Informe o percentual: ");
            double percentual = double.Parse(Console.ReadLine());

            Console.WriteLine();
            lista.Find(x => x.Id == id).ReajustarSalario(percentual);

            foreach (Funcionario item in lista)
                Console.WriteLine(item);
        }
    }
}