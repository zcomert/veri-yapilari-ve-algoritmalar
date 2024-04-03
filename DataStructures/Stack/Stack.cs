using DataStructures.Stack.Contracts;

namespace DataStructures.Stack;

public class Stack<T> : IStack<T>
{
    private readonly IStack<T>? _stack;

    public int Count => _stack.Count;

    public Stack()
    {
        // _stack = new ArrayStack<T>();
        _stack = new LinkedListStack<T>();
    }

    public Stack(string type)
    {
        if (type.ToLower() == "array")
            _stack = new ArrayStack<T>();
        else if (type.ToLower() == "linked")
            _stack = new LinkedListStack<T>();
        else
        {
            throw new Exception("Type not valid!");
        }
    }

    public Stack(IEnumerable<T> collection) : this()
    {
        foreach (var item in collection)
        {
            Push(item);
        }
    }

    public T? Peek()
    {
        return _stack.Peek();
    }

    public T? Pop()
    {
        return _stack.Pop();
    }

    public void Push(T item)
    {
        _stack.Push(item);
    }
}