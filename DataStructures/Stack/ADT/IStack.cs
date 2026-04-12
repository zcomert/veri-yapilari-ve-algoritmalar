namespace Stack.ADT;

public interface IStack<T>
{
    void Push(T item);
    T Pop();
    T Peek();
    void Clear();
    int Count { get; }
    bool IsEmpty { get; }
}
