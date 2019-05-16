using System;
using System.Text;
using System.Globalization;

namespace Polimorfismo.Entities
{
    public class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProduct()
        {
        }
        public UsedProduct(string name, double price, DateTime manufactureDate ) : base(name, price)
        {
            ManufactureDate = manufactureDate;
        }
        public sealed override string PriceTag()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("PRICE TAGS:");
            sb.AppendLine($"{Name}(Used) ${Price.ToString("F2", CultureInfo.InvariantCulture)} (Manufacture date: ${ManufactureDate.ToString("dd/MM/yyyy")}");
            return sb.ToString();
        }
    }
}
