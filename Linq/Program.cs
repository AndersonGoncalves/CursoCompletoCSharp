using System;
using System.Linq;
using System.Collections.Generic;
using Linq.Entities;

namespace Linq
{
    class Program
    {
        private static void Print<T>(string msg, IEnumerable<T> colecao)
        {
            Console.WriteLine(msg);
            foreach(T obj in colecao)
                Console.WriteLine(obj);
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            Categoria c1 = new Categoria() { Id = 1, Nome = "Eletônico" };
            Categoria c2 = new Categoria() { Id = 2, Nome = "Informática" };

            List<Produto> lista = new List<Produto>()
            {
                new Produto {Id = 1, Nome = "Celular", Preco = 1500.00, Categoria = c1 },
                new Produto {Id = 2, Nome = "Som", Preco = 500.00, Categoria = c1 },
                new Produto {Id = 3, Nome = "Notebook Dell", Preco = 5500.00, Categoria = c2 },
                new Produto {Id = 4, Nome = "Notebook HP", Preco = 5600.00, Categoria = c2 },
                new Produto {Id = 5, Nome = "TV 4K", Preco = 2500.00, Categoria = c1 },
                new Produto {Id = 6, Nome = "Monitor", Preco = 550.00, Categoria = c2 },
                new Produto {Id = 7, Nome = "Liquidificador", Preco = 100.00, Categoria = c1 },
                new Produto {Id = 8, Nome = "Geladeira", Preco = 2800.00, Categoria = c1 },
                new Produto {Id = 9, Nome = "Mouse", Preco = 99.00, Categoria = c2 },
                new Produto {Id = 10, Nome = "Teclado", Preco = 80.00, Categoria = c2 },
                new Produto {Id = 11, Nome = "Processador I7", Preco = 7000.00, Categoria = c2 }
            };

            IEnumerable<Produto> list0 = lista.OrderBy(x => x.Categoria.Nome).ThenBy(x => x.Id);
            Print("Lista completa ordenada por categoria e id:", list0);

            var list1 = lista.Where(x => x.Categoria == c1);
            Print("Somente eletrônico: ", list1);

            var list2 = lista.Where(x => x.Categoria == c2).Select(p => p.Nome);
            Print("Somente a descrição dos produtos da categoria Informática:", list2);

            var list3 = lista.Select(x => new { x.Nome, x.Preco });
            Print("Somente nome e preço: ", list3);

            var list4 = lista.First();
            Console.WriteLine("Primeiro da lista: ");
            Console.WriteLine(list4);
            Console.WriteLine();

            var list5 = list0.Skip(2).Take(3);
            Print("Paginando => Na posição 2, mostrar 3 produtos: ", list5);
         }
    }
}