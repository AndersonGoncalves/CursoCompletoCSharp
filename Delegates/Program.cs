using System;
using Delegates.Entities;
using System.Collections.Generic;
using Delegates.Services;
using System.Linq;
using System.Globalization;

namespace Delegates
{
    class Program
    {
        delegate double Operacao(double x, double y);

        public static int x = 0;
        public static int y = 0;
        static void Main(string[] args)
        {
            List<Produto> Lista = new List<Produto>()
            {
                new Produto {Codigo = 1, Nome = "TV 4K", Preco = 2000.00 },
                new Produto {Codigo = 2, Nome = "Mouse", Preco = 70.00 },
                new Produto {Codigo = 3, Nome = "Computador", Preco = 4000.00 },
                new Produto {Codigo = 4, Nome = "Teclado", Preco = 100.00 },
                new Produto {Codigo = 5, Nome = "Celular", Preco = 1500.00 },
                new Produto {Codigo = 6, Nome = "Ventilador", Preco = 99.00 },
                new Produto {Codigo = 7, Nome = "Notebook", Preco = 5170.00 }
            };

            Lista.Sort((x, y) => x.Codigo.CompareTo(y.Codigo));
            foreach (Produto produto in Lista)
            {
                Console.WriteLine(produto);
            }
            Console.WriteLine();


            #region Delegates e Predicate
            //Operacao op = CalcularProdutoServices.Max;
            Operacao op = new Operacao(CalcularProdutoServices.Max);

            Console.Write("Informe o codigo(1): ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Informe o codigo(2): ");
            y = int.Parse(Console.ReadLine());

            double result = op(Lista.Find(MaiorX).Preco, Lista.Find(MaiorY).Preco);
            Console.WriteLine("Maior valor: "+ result.ToString("F2"));
            #endregion

            Console.WriteLine();

            #region Action
            //Lista.ForEach(p => p.Preco += p.Preco * 0.1);
            Lista.ForEach(AlterarPreco);            
            foreach (Produto produto in Lista)
                Console.WriteLine(produto);
            #endregion

            Console.WriteLine();

            #region Func
            List<string> listaNome = Lista.Select(x => x.Nome.ToUpper().ToString()).ToList();
            foreach (string item in listaNome)
                Console.WriteLine(item);            

            Console.WriteLine();

            var soma = CalcularProdutoServices.FiltrarSum(Lista, x => x.Preco <= 110);
            Console.WriteLine(soma.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine();

            Console.Write("Informe o código do produto: ");
            int cod = int.Parse(Console.ReadLine());
            Produto p = CalcularProdutoServices.FiltrarProduto(Lista, x => x.Codigo == cod);
            if (p != null)
                Console.WriteLine(p);
            else
                Console.WriteLine("Produto não encontrado!");
            #endregion
        }

        public static void AlterarPreco(Produto p)
        {
            p.Preco += p.Preco * 0.1;
        }

        public static bool MaiorX(Produto p)
        {
            return p.Codigo == x;
        }

        public static bool MaiorY(Produto p)
        {
            return p.Codigo == y;
        }
    }
}