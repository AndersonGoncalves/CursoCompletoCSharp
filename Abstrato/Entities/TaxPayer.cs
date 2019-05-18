using System.Globalization;

namespace Abstrato.Entities
{
    public abstract class TaxPayer
    {
        protected string Name { get; set; }
        protected double AnualIncome { get; set; }

        protected TaxPayer(string name, double anualIncome)
        {
            Name = name;
            AnualIncome = anualIncome;
        }

        public abstract double Tax();

        public override string ToString()
        {
            return Name + ": $" + Tax().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}