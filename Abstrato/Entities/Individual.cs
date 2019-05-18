using System;
using System.Collections.Generic;
using System.Text;

namespace Abstrato.Entities
{
    public class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual(string name, double anualIncome, double healthExpenditures) :base(name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public sealed override double Tax()
        {
            double imposto = (AnualIncome < 20000.00) ? 0.15 : 0.25;            
            return (AnualIncome * imposto) - ((HealthExpenditures > 0 ? HealthExpenditures * 0.50 : 0));
        }
    }
}
