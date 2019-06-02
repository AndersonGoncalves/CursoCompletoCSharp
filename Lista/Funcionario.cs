using System.Globalization;

namespace Lista
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }

        public Funcionario(int id, string nome, double salario)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
        }

        public void ReajustarSalario(double percentual)
        {
            Salario += Salario * (percentual / 100);
        }

        public override string ToString()
        {
            return Id + ", " + Nome + ",  " + Salario.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}