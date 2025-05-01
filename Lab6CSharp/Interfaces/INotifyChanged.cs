namespace Lab6CSharp.Interfaces
{
    public interface INotifyChanged
    {
        protected event EventHandler Changed;
    }
}