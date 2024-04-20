using DataStructures.Stack.Contracts;

namespace DataStructures.Stack;

public class ArrayStack<T> : IStack<T>
{
    private List<T> _innerArray;
    private int LastIndex => Count - 1;
    public int Count => _innerArray.Count;
    public ArrayStack()
    {
        _innerArray = new List<T>();
    }

    public ArrayStack(IEnumerable<T> collection) : this()
    {
        foreach (var item in collection)
        {
            Push(item);
        }
    }


    public T? Peek()
    {
        return Count == 0
            ? default
            : _innerArray[LastIndex];
    }

    public T? Pop()
    {
        if (Count == 0)
        {
            throw new Exception("Underflow! Empty stack!");
        }
        var temp = _innerArray[LastIndex]; // Peek()
        _innerArray.RemoveAt(LastIndex);
        return temp;
    }

    public void Push(T item)
    {
        _innerArray.Add(item);
    }
}
