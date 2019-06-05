using System;
using System.IO;
using System.Collections.Generic;
using Arquivos2.Entities;
using System.Globalization;

namespace Arquivos2
{
    class Program
    {
        static void Main(string[] args)
        {
            string arquivo = @"D:\Pedido.txt";
            string arquivoDestino = @"D:\arquivoDestino.txt";
            List<Pedido> Pedidos = new List<Pedido>();

            try
            {
                string[] linhas = File.ReadAllLines(arquivo);
                using (StreamWriter sw = File.AppendText(arquivoDestino))
                {
                    foreach (string linha in linhas)
                    {
                        string[] colunas = linha.Split(',');
                        double valor = double.Parse(colunas[1], CultureInfo.InvariantCulture);
                        Pedidos.Add(new Pedido(colunas[0], valor, int.Parse(colunas[2].ToString())));
                    }

                    foreach (Pedido pedido in Pedidos)
                        sw.WriteLine(pedido);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}