namespace Lab6CSharp.Entities.People
{
    public class Employee : Worker
    {
        private string company;
        private decimal salary;

        public Employee() : base()
        {
            company = "Company Name";
            salary = 0;
            Console.WriteLine("Employee default constructor called");
        }

        public Employee(string company, decimal salary)
        {
            this.company = company;
            this.salary = salary;
            Console.WriteLine("Employee parameterized constructor called");
        }

        public Employee(string name, int age, string jobTitle, string company, decimal salary)
            : base(name, age, jobTitle)
        {
            this.company = company;
            this.salary = salary;
            Console.WriteLine("Employee full constructor called");
        }

        ~Employee()
        {
            Console.WriteLine("Employee destructor called");
        }

        public override string Serialize()
        {
            return base.Serialize() + $",{company},{salary}";
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine($"Rendering employee at {company} with salary {salary}");
        }

        public new void HandleInput(string input)
        {
            base.HandleInput(input);

            string[] inputs = input.Split(',');
            if (inputs.Length > 3)
            {
                company = inputs[3].Trim();
                OnChanged();
                Console.WriteLine($"Company updated to: {company}");
            }

            if (inputs.Length > 4 && decimal.TryParse(inputs[4].Trim(), out decimal parsedSalary))
            {
                salary = parsedSalary;
                OnChanged();
                Console.WriteLine($"Salary updated to: {salary}");
            }
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Employee: company: {company}, salary: {salary}");
        }
    }
}
