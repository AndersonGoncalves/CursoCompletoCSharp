using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Arquivos2.Entities
{
    public class Pedido
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        
        public Pedido(string nome, double valor, int quantidade)
        {
            Nome = nome;
            Valor = valor;
            Quantidade = quantidade;
        }
        public double ValorTotal()
        {
            return Valor * Quantidade;
        }
        public override string ToString()
        {
            return Nome + ", " + ValorTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}