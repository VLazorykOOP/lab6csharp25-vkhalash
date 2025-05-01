namespace Lab6CSharp.Entities.People
{
    public class Engineer : Employee
    {
        private string discipline;

        public Engineer() : base()
        {
            discipline = "Discipline Name";
            Console.WriteLine("Engineer default constructor called");
        }

        public Engineer(string discipline)
        {
            this.discipline = discipline;
            Console.WriteLine("Engineer parameterized constructor called");
        }

        public Engineer(string name, int age, string jobTitle, string company, decimal salary, string discipline)
            : base(name, age, jobTitle, company, salary)
        {
            this.discipline = discipline;
            Console.WriteLine("Engineer full constructor called");
        }

        ~Engineer()
        {
            Console.WriteLine("Engineer destructor called");
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine($"Rendering engineer with discipline: {discipline}");
        }

        public override string Serialize()
        {
            return base.Serialize() + $", {discipline}";
        }

        public new void HandleInput(string input)
        {
            base.HandleInput(input);

            string[] inputs = input.Split(',');
            if (inputs.Length > 5)
            {
                discipline = inputs[5].Trim();
                OnChanged();
                Console.WriteLine($"Discipline updated to: {discipline}");
            }
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Engineer: discipline: {discipline}");
        }
    }
}
