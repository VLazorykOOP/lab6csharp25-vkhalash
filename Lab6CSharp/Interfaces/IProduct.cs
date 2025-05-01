namespace Lab6CSharp.Interfaces
{
    public interface IProduct : IFormattable
    {
        public string Name { get; }
        public decimal Price { get; }
        public int TargetAge { get; }

        public bool IsMatchingType(string searchType);
    }
}
