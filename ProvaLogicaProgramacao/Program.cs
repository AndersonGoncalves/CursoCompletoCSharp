using System;
using System.Globalization;

namespace ProvaLogicaProgramacao {
    class Program {
        static void Main(string[] args) {

            #region PARTE 1: ESTRUTURA SEQUENCIAL 
            //Exercício 1.1:
            Console.WriteLine("Exercício 1.1");
            Console.WriteLine("Digite o Código / quantidade / valor da primeira peça (separado por espaço): ");
            string[] peca1 = Console.ReadLine().Split(' ');

            Console.WriteLine("Digite o Código / quantidade / valor da segunda peça (separado por espaço): ");
            string[] peca2 = Console.ReadLine().Split(' ');

            double valorPagar = (int.Parse(peca1[1]) * double.Parse(peca1[2])) + (int.Parse(peca2[1]) * double.Parse(peca2[2]));
            Console.WriteLine("VALOR A PAGAR: {0}", valorPagar.ToString("F2", CultureInfo.InvariantCulture));

            //Exercício 1.2:
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Exercício 1.2");
            Console.WriteLine("Informe o valor do raio:");
            double raio = double.Parse(Console.ReadLine());
            double area = Math.PI * Math.Pow(raio, 2);
            Console.WriteLine($"A={area.ToString("F4", CultureInfo.InvariantCulture)}");
            #endregion

            #region PARTE 2: ESTRUTURA CONDICIONAL 
            //Exercício 2.1:
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Exercício 2.1");
            Console.WriteLine("Digite o Código / quantidade (separado por espaço): ");
            string[] pecas = Console.ReadLine().Split(' ');

            double ValorDaPeca = 0;
            if (int.Parse(pecas[0]) == 1)
                ValorDaPeca = 4.00; 
            else if (int.Parse(pecas[0]) == 2)
                ValorDaPeca = 4.50;
            else if (int.Parse(pecas[0]) == 3)
                ValorDaPeca = 5.00;
            else if (int.Parse(pecas[0]) == 4)
                ValorDaPeca = 2.00;
            else if (int.Parse(pecas[0]) == 5)
                ValorDaPeca = 1.50;

            double valorFinal = ValorDaPeca * double.Parse(pecas[1]);
            Console.WriteLine($"Total: R$ {valorFinal.ToString("F2", CultureInfo.InvariantCulture)}");
            #endregion
        }
    }
}
