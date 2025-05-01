namespace Lab6CSharp.Interfaces
{
    public interface IProductInfo : ISerializable, ICloneable
    {
        protected void DisplayInfo();
        protected bool IsMatchingType(string searchType);
    }
}
