namespace DataStructures.Stack.Contracts;

public interface IStack<T>
{
    int Count { get; }
    void Push(T item);
    T? Pop();
    T? Peek();
}