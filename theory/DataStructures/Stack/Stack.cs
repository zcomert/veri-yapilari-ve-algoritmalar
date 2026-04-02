using Stack.ADT;

namespace Stack;

public class Stack<T> : IStack<T>
{
    private IStack<T> _stack;
    public Stack()
    {
        _stack = new LinkedListStack<T>();
    }
    public int Count => _stack.Count;

    public bool IsEmpty => _stack.IsEmpty;

    public void Clear()
    {
        _stack.Clear(); 
    }

    public T Peek()
    {
        return _stack.Peek();
    }

    public T Pop()
    {
        return _stack.Pop();
    }

    public void Push(T item)
    {
        _stack.Push(item);
    }
}
