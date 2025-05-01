using Lab6CSharp.Exceptions;
using Lab6CSharp.Interfaces;

namespace Lab6CSharp.Entities.Products
{
    public class Book : IProduct
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int TargetAge { get; private set; }
        public string Author { get; private set; }
        public string Publisher { get; private set; }

        public Book(string name, decimal price, string author, string publisher, int targetAge)
        {
            if (price < 0 || targetAge < 0)
                throw new InvalidProductException("Price and Target Age must be non-negative.");

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            TargetAge = targetAge;
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return $"Book: {Name}\nAuthor: {Author}\nPublisher: {Publisher}\nPrice: {Price:C}\nTarget Age: {TargetAge}+";
        }

        public override string ToString()
        {
            return ToString(null, null);
        }

        public bool IsMatchingType(string searchType)
        {
            return searchType.Equals("book", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
