using System;
using System.Globalization;

namespace ProvaLogicaProgramacao {
    class Program {
        static void Main(string[] args) {

            #region Exercício 01

            //Fazer um programa para ler o código de uma peça 1,
            //o número de peças 1, o valor unitário de cada peça 1,
            //o código de uma peça 2, o número de peças 2 e o valor
            //unitário de cada peça 2.Calcule e mostre o valor a ser pago.
            //Entrada: 12 1 5.30
            //Entrada: 16 2 5.10 
            //Saída: VALOR A PAGAR: R$ 15.50

            Console.WriteLine("Exercício 01");
            Console.WriteLine("Digite o Código / quantidade / valor da primeira peça (separado por espaço): ");
            string[] peca1 = Console.ReadLine().Split(' ');

            Console.WriteLine("Digite o Código / quantidade / valor da segunda peça (separado por espaço): ");
            string[] peca2 = Console.ReadLine().Split(' ');

            double valorPagar = (int.Parse(peca1[1]) * double.Parse(peca1[2])) + (int.Parse(peca2[1]) * double.Parse(peca2[2]));
            Console.WriteLine("VALOR A PAGAR: {0}", valorPagar.ToString("F2", CultureInfo.InvariantCulture));
            #endregion


            #region Exercício 02

            //Faça um programa para ler o valor do raio de um círculo,
            //e depois mostrar o valor da área deste círculo com quatro casas
            //decimais conforme exemplos. Fórmula: Area = PI*raio*raio
            //Entrada: 2.00
            //Saída: A=12.5664 

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Exercício 02");
            Console.WriteLine("Informe o valor do raio:");
            double raio = double.Parse(Console.ReadLine());
            double area = Math.PI * Math.Pow(raio, 2);
            Console.WriteLine($"A={area.ToString("F4", CultureInfo.InvariantCulture)}");
            #endregion
        }
    }
}
