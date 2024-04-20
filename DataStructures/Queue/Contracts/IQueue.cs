namespace DataStructures.Queue.Contracts;

public interface IQueue<T>
{
    public int Count { get; }
    public void Enqueue(T item);
    public T Dequeue();

    public T Peek();
}