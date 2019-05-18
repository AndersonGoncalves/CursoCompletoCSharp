using System;
using System.Collections.Generic;
using System.Text;

namespace Abstrato.Entities
{
    public class Company : TaxPayer
    {
        public int NumberOfEmployees { get; set; }

        public Company(string name, double anualIncome, int numberOfEmployees) :base(name, anualIncome)
        {
            NumberOfEmployees = numberOfEmployees;
        }

        public sealed override double Tax()
        {
            double imposto = (NumberOfEmployees > 10) ? 0.14 : 0.16;
            return AnualIncome * imposto;
        }
    }
}
