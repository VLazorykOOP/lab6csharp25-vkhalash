namespace Lab6CSharp.Entities.People
{
    public class Worker : Person
    {
        private string jobTitle;

        public Worker() : base()
        {
            jobTitle = "Job Title";
            Console.WriteLine("Worker default constructor called");
        }

        public Worker(string jobTitle)
        {
            this.jobTitle = jobTitle;
            Console.WriteLine("Worker parameterized constructor called");
        }

        public Worker(string name, int age, string jobTitle) : base(name, age)
        {
            this.jobTitle = jobTitle;
            Console.WriteLine("Worker full constructor called");
        }

        ~Worker()
        {
            Console.WriteLine("Worker destructor called");
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine($"Rendering worker with job title: {jobTitle}");
        }

        public override string Serialize()
        {
            return base.Serialize() + $", {jobTitle}";
        }

        public new void HandleInput(string input)
        {
            base.HandleInput(input);

            string[] inputs = input.Split(',');
            if (inputs.Length > 2)
            {
                jobTitle = inputs[2].Trim();
                OnChanged();
                Console.WriteLine($"Job title updated to: {jobTitle}");
            }
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Worker: job title: {jobTitle}");
        }
    }
}
