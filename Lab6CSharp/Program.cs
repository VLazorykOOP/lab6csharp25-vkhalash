using Lab6CSharp.Entities.People;
using Lab6CSharp.Entities.Products;
using Lab6CSharp.Exceptions;
using Lab6CSharp.Interfaces;

namespace Lab6CSharp
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Enter option 1-2: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 2;

            while (!isValid)
            {
                Console.Write("Please enter a valid option. Enter option 1-2: ");
                isValid = int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 2;
            }

            switch (option)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
            }
        }

        private static void Task1()
        {
            Console.WriteLine("Creating Person:");
            Person person = new("Alice", 28);
            person.Show();
            person.HandleInput("Bob, 35");
            person.Show();

            Console.WriteLine("\nCreating Worker:");
            Worker worker = new("John", 30, "Software Developer");
            worker.Show();
            worker.HandleInput("Mary, 40, Senior Developer");
            worker.Show();

            Console.WriteLine("\nCreating Employee:");
            Employee employee = new("Tech Corp", 120000);
            employee.Show();
            employee.HandleInput("James, 45, Manager, Global Inc, 150000");
            employee.Show();

            Console.WriteLine("\nCreating Engineer:");
            Engineer engineer = new("Sara", 32, "Mechanical Engineer", "AutoMakers", 100000, "Mechanical Design");
            engineer.Show();
            engineer.HandleInput("Sarah, 33, Electrical Engineer, TechWorks, 120000, Electrical Design");
            engineer.Show();

            Console.WriteLine("\nSerialized outputs:");
            Console.WriteLine(person.Serialize());
            Console.WriteLine(worker.Serialize());
            Console.WriteLine(employee.Serialize());
            Console.WriteLine(engineer.Serialize());

            Console.WriteLine("\nRendering outputs:");
            person.Render();
            worker.Render();
            employee.Render();
            engineer.Render();
        }

        private static void Task2()
        {
            try
            {
                var db = new ProductDatabase();

                IProduct book = new Book("The Hobbit", 19.99m, "J.R.R. Tolkien", "HarperCollins", 12);
                IProduct toy = new Toy("Lego Star Wars", 49.99m, "LEGO", "Plastic", 8);
                IProduct sportEquip = new SportEquipment("Football", 25.00m, "Nike", 10);

                db.AddProduct(book);
                db.AddProduct(toy);
                db.AddProduct(sportEquip);

                Console.WriteLine("Iterating over products in the database:");
                foreach (var product in db.GetAllProducts())
                {
                    Console.Write($"{product.Name}");
                    Console.WriteLine();
                }

                db.DisplayAllProducts();
                db.DisplayProductByIndex(1);
                db.SearchProductsByType("book");
                db.SearchProductsByType("toy");
                db.SearchProductsByType("sport-equip");
                db.SearchProductsByType("electronics");
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine($"Product not found: {ex.Message}");
            }
            catch (InvalidProductException ex)
            {
                Console.WriteLine($"Invalid product: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
