using System;
using System.Collections.Generic;
using Delegates.Entities;

namespace Delegates.Services
{
    public static class CalcularProdutoServices
    {
        public static double Max(double x, double y)
        {
            return (x > y) ? x : y;
        }

        public static double Min(double x, double y)
        {
            return (x > y) ? y : x;
        }

        public static double Sum(double x, double y)
        {
            return x + y; ;
        }

        public static double Square(double x)
        {
            return Math.Pow(2, x);
        }

        public static double FiltrarSum(List<Produto> lista, Func<Produto, bool> criterio)
        {
            double sum = 0.0;
            foreach (Produto p in lista)
            {
                if (criterio.Invoke(p))
                    sum += p.Preco;
            }
            return sum;
        }

        public static Produto FiltrarProduto(List<Produto> lista, Func<Produto, bool> criterio)
        {
            foreach (Produto p in lista)
            {
                if (criterio(p))
                    return p;
            }
            return null;
        }
    }
}
