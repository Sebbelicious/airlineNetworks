namespace MiniProject4_Airline_Networks.Basics
{
    public interface IStack<T> : IContainer<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
    }
}