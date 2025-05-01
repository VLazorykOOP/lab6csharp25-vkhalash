using Lab6CSharp.Exceptions;
using Lab6CSharp.Interfaces;

namespace Lab6CSharp.Entities.Products
{
    public class Toy : IProduct
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int TargetAge { get; private set; }
        public string Manufacturer { get; private set; }
        public string Material { get; private set; }

        public Toy(string name, decimal price, string manufacturer, string material, int targetAge)
        {
            if (price < 0 || targetAge < 0)
                throw new InvalidProductException("Price and Target Age must be non-negative.");

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            TargetAge = targetAge;
            Manufacturer = manufacturer ?? throw new ArgumentNullException(nameof(manufacturer));
            Material = material ?? throw new ArgumentNullException(nameof(material));
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return $"Toy: {Name}\nManufacturer: {Manufacturer}\nMaterial: {Material}\nPrice: {Price:C}\nTarget Age: {TargetAge}+";
        }

        public override string ToString()
        {
            return ToString(null, null);
        }

        public bool IsMatchingType(string searchType)
        {
            return searchType.Equals("toy", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
