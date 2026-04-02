using LinkedList.SinglyLinkedList;
using Stack.ADT;

namespace Stack;

public class LinkedListStack<T> : IStack<T>
{
    private SinglyLinkedList<T> _items;
    private int _count;
    public LinkedListStack()
    {
        _items = new SinglyLinkedList<T>();
        _count = 0;
    }
    public int Count => _count;

    public bool IsEmpty => _count == 0;

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        return _items.Head.Item;
    }


    public void Push(T item)
    {
        _items.AddFirst(item);
        _count++;
        return;
    }

    
    public T Pop()
    {
        var popItem = _items.RemoveFirst();
        _count--;
        return popItem;
    }
}