using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Delegates.Entities
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto()
        {
        }
        public Produto(int codigo, string nome, double preco)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
        }
        public override string ToString()
        {
            return Codigo + "-" + Nome + " (" + Preco.ToString("F2", CultureInfo.InvariantCulture) + ")";
        }
    }
}
