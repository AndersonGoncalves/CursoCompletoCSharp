using System;
using System.Globalization;

namespace ProvaLogicaProgramacao {
    class Program {
        static void Main(string[] args) {
            #region Exercício 01
            Console.WriteLine("Digite o Código / quantidade / valor da primeira peça (separado por espaço): ");
            string[] peca1 = Console.ReadLine().Split(' ');

            Console.WriteLine("Digite o Código / quantidade / valor da segunda peça (separado por espaço): ");
            string[] peca2 = Console.ReadLine().Split(' ');

            double valorPagar = (int.Parse(peca1[1]) * double.Parse(peca1[2])) +
                                (int.Parse(peca2[1]) * double.Parse(peca2[2]));
            Console.WriteLine("VALOR A PAGAR: {0}", valorPagar.ToString("F2", CultureInfo.InvariantCulture));
            #endregion
        }
    }
}
