using System;
using System.Collections.Generic;

namespace Conjunto
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> A = new HashSet<string>();
            HashSet<string> B = new HashSet<string>();
            HashSet<string> C = new HashSet<string>();            

            Console.Write("O curso A possui quantos alunos? ");
            int qtdCursoA = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite os códigos dos alunos do curso A:");
            for (int i = 0; i < qtdCursoA; i++)
                A.Add(Console.ReadLine());

            Console.Write("O curso B possui quantos alunos? ");
            int qtdCursoB = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite os códigos dos alunos do curso B:");
            for (int i = 0; i < qtdCursoB; i++)
                B.Add(Console.ReadLine());

            Console.Write("O curso C possui quantos alunos? ");
            int qtdCursoC = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite os códigos dos alunos do curso C:");
            for (int i = 0; i < qtdCursoC; i++)
                C.Add(Console.ReadLine());

            HashSet<string> qtdAlunos = new HashSet<string>();

            qtdAlunos.UnionWith(A);
            qtdAlunos.UnionWith(B);
            qtdAlunos.UnionWith(C);            

            Console.Write("Total de alunos: " + qtdAlunos.Count);

        }
    }
}
