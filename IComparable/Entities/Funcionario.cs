using System;
using System.Globalization;

namespace IComparable.Entities
{
    public class Funcionario : IComparable<Funcionario>
    {
        public string Nome { get; set; }
        public double Salario { get; set; }

        public Funcionario() {
        }
        public int CompareTo(Funcionario other)
        {
            if (Nome != other.Nome)
                return Nome.CompareTo(other.Nome);
            else
                return Salario.CompareTo(other.Salario);
        }
        public override string ToString()
        {
            return Nome + ", " + Salario.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
