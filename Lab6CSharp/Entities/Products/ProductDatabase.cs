using Lab6CSharp.Exceptions;
using Lab6CSharp.Interfaces;

namespace Lab6CSharp.Entities.Products
{
    public class ProductDatabase
    {
        private List<IProduct> products;

        public ProductDatabase()
        {
            products = [];
        }

        public void AddProduct(IProduct product)
        {
            if (product == null)
                throw new InvalidProductException("Cannot add a null product.");
            products.Add(product);
        }

        public void DisplayAllProducts()
        {
            Console.WriteLine("Product list:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public void DisplayProductByIndex(int index)
        {
            try
            {
                Console.WriteLine(products[index].ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error: The product index is out of range.");
            }
        }

        public void SearchProductsByType(string searchType)
        {
            Console.WriteLine($"Products of type '{searchType.ToUpper()}':");
            bool found = false;

            foreach (var product in products)
            {
                if (product.IsMatchingType(searchType))
                {
                    Console.WriteLine(product.ToString());
                    found = true;
                }
            }

            if (!found)
            {
                throw new ProductNotFoundException($"Products of type '{searchType}' not found.");
            }
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            return products;
        }
    }
}
