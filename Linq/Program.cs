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

            //List<Produto> list0 = lista.OrderBy(x => x.Categoria.Nome).ThenBy(x => x.Id).ToList();
            IEnumerable<Produto> list0 = lista.OrderBy(x => x.Categoria.Nome).ThenBy(x => x.Id);
            Print("Lista completa ordenada por categoria e id:", list0);

            //var list1 = lista.Where(x => x.Categoria == c1);
            var list1 =
                from x in lista
                where x.Categoria == c1
                select x;
            Print("Somente eletrônico: ", list1);

            //var list2 = lista.Where(x => x.Categoria == c2).Select(p => p.Nome);
            var list2 =
                from produto in lista
                where produto.Categoria == c2
                select produto.Nome;
            Print("Somente a descrição dos produtos da categoria Informática:", list2);

            //var list3 = lista.Select(x => new { x.Nome, x.Preco });
            var list3 =
                from produto in lista
                select new { produto.Nome, produto.Preco };
            Print("Somente nome e preço: ", list3);

            //var list4 = list0.Skip(2).Take(3);
            var list4 =
                (from produto in lista
                 orderby produto.Id
                 orderby produto.Categoria.Nome
                 select produto).Skip(2).Take(3);
            Print("Paginando => Na posição 2, mostrar 3 produtos: ", list4);

            var list5 = lista.First();
            Console.WriteLine("Primeiro da lista: ");
            Console.WriteLine(list5);
            Console.WriteLine();

            //var list6 = lista.Where(p => p.Categoria.Id == 5).FirstOrDefault();
            var list6 =
                (from produto in lista
                 where produto.Categoria.Id == 5
                 select produto).FirstOrDefault();
            Console.WriteLine("Primeiro da lista em branco: ");
            Console.WriteLine(list6);
            Console.WriteLine();

            var list7 = lista.Where(p => p.Id == 2).Single();
            Console.WriteLine("Um produto da lista: ");
            Console.WriteLine(list7);
            Console.WriteLine();

            //var list8 = lista.Where(p => p.Id == 50).SingleOrDefault();
            var list8 =
                (from produto in lista
                 where produto.Id == 50
                 select produto).SingleOrDefault();
            Console.WriteLine("Um produto da lista em branco: ");
            Console.WriteLine(list8);
            Console.WriteLine();

            //var list9 = lista.Max(p => p.Preco);
            var list9 =
                (from p in lista
                 select p.Preco).Max();
            Console.WriteLine("Max: ");
            Console.WriteLine(list9);
            Console.WriteLine();

            var list10 = lista.Min(p => p.Preco);
            Console.WriteLine("Min: ");
            Console.WriteLine(list10);
            Console.WriteLine();            

            var list11 = lista.Where(p => p.Categoria.Id == 1).Sum(p => p.Preco);
            Console.WriteLine("Total da categoria 1: ");
            Console.WriteLine(list11);
            Console.WriteLine();            

            var list12 = lista.Where(p => p.Categoria.Id == 1).Average(p => p.Preco);
            Console.WriteLine("Média da categoria 1: ");
            Console.WriteLine(list12);
            Console.WriteLine();
                        
            var list13 = lista.Where(p => p.Categoria.Id == 5).Select(p => p.Preco).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Média da categoria 5 em branco: ");
            Console.WriteLine(list13);
            Console.WriteLine();
            
            var list14 = lista.Where(p => p.Categoria.Id == 1).Select(p => p.Preco).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("Valor agregado da categoria 1: ");
            Console.WriteLine(list14);
            Console.WriteLine();

            IEnumerable<IGrouping<Categoria, Produto>> list15 = lista.GroupBy(p => p.Categoria);
            foreach (IGrouping<Categoria, Produto> group in list15)
            {
                Console.WriteLine("Categoria " + group.Key.Nome + ":");
                foreach (Produto p in group)
                    Console.WriteLine(p);
                Console.WriteLine();
            }
        }
    }
}