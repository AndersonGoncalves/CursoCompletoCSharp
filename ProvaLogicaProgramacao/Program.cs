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

            //Exercício 2.2:
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Exercício 2.2");
            Console.WriteLine("Digite o valor de A, B e C (separado por espaço):");
            string[] abc = Console.ReadLine().Split(' ');
            double a = double.Parse(abc[0]);
            double b = double.Parse(abc[1]);
            double c = double.Parse(abc[2]);
            double delta = Math.Pow(b, 2) - (4.0 * a * c);
            double x1 = (-b + Math.Sqrt(delta)) / (2.0 * a); 
            double x2 = (-b - Math.Sqrt(delta)) / (2.0 * a);
            Console.WriteLine("X1 = {0}",x1.ToString("F5", CultureInfo.InvariantCulture));
            Console.WriteLine("X2 = {0}", x2.ToString("F5", CultureInfo.InvariantCulture));
            #endregion


            #region PARTE 3: ESTRUTURAS REPETITIVAS
            //Exercício 3.1:
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Exercício 3.1");
            while (true) {
                Console.WriteLine("Informe a seha de acesso:");
                string senha = Console.ReadLine();
                if (senha != "2002") {
                    Console.WriteLine("Senha inválida");
                }
                else {
                    Console.WriteLine("Acesso permitido!");
                    break;
                }
            }
            #endregion

        }
    }
}
