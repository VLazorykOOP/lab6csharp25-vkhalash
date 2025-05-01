using Lab6CSharp.Interfaces;

namespace Lab6CSharp.Entities.People
{
    public class Person : IRenderable, ISerializable, IInputHandler, INotifyChanged
    {
        private string name;
        private int age;

        public int Age { get { return age; } }

        public event EventHandler? Changed;

        protected void OnChanged() => Changed?.Invoke(this, EventArgs.Empty);

        public Person()
        {
            name = "John Doe";
            age = 0;
            Console.WriteLine("Person default constructor called");
        }

        public Person(string name)
        {
            this.name = name;
            age = 0;
            Console.WriteLine("Person parameterized constructor called");
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine("Person full constructor called");
        }

        ~Person()
        {
            Console.WriteLine("Person destructor called");
        }

        public virtual void Render()
        {
            Console.WriteLine($"Rendering person: {name}, age: {age}");
        }

        public virtual string Serialize()
        {
            return $"{name}, {age}";
        }

        public void HandleInput(string input)
        {
            string[] inputs = input.Split(',');
            if (inputs.Length > 0)
            {
                name = inputs[0].Trim();
                OnChanged();
                Console.WriteLine($"Name updated to: {name}");
            }

            if (inputs.Length > 1 && int.TryParse(inputs[1].Trim(), out int parsedAge))
            {
                age = parsedAge;
                OnChanged();
                Console.WriteLine($"Age updated to: {age}");
            }
        }

        public virtual void Show()
        {
            Console.WriteLine($"Person: name: {name}, age: {age}");
        }
    }
}
