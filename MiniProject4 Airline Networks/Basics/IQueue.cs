namespace MiniProject4_Airline_Networks.Basics
{
    public interface IQueue<T> : IContainer<T> {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}