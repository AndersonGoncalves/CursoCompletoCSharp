using System.Text;
using System.Globalization;

namespace Polimorfismo.Entities
{
    public class ImportedProduct : Product
    {
        public double CustomsFee { get; set; }
        public ImportedProduct()
        {
        }
        public ImportedProduct(string name, double price, double customsFee) : base(name, price)
        {
            CustomsFee = customsFee;
        }

        public sealed override string PriceTag()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("PRICE TAGS:");
            sb.AppendLine($"{Name} ${Price.ToString("F2", CultureInfo.InvariantCulture)} (Customs fee: ${CustomsFee.ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();
        }

        public double TotalPrice()
        {
            return Price + CustomsFee;
        }
    }
}
