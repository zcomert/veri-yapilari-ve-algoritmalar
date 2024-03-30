using DataStructures.Stack.Contracts;

namespace DataStructures.Stack;

public class Stack<T> : IStack<T>
{
    private readonly IStack<T>? _stack;

    public int Count => throw new NotImplementedException();

    public Stack()
    {

    }

    public T? Peek()
    {
        throw new NotImplementedException();
    }

    public T? Pop()
    {
        throw new NotImplementedException();
    }

    public void Push(T item)
    {
        throw new NotImplementedException();
    }
}