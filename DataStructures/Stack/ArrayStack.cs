using Stack.ADT;

namespace Stack;

public class ArrayStack<T> : IStack<T>
{
    private T[] _items;
    private int _count;
    private const int DefaultCapacity = 4;

    public ArrayStack()
    {
        _items = new T[DefaultCapacity];
        _count = 0;
    }

    public ArrayStack(int initialCapacity)
    {
        if (initialCapacity < 0)
            throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Capacity cannot be negative.");
        
        _items = new T[initialCapacity];
        _count = 0;
    }

    public int Count => _count;

    public bool IsEmpty => _count == 0;

    public void Push(T item)
    {
        EnsureCapacity();
        _items[_count++] = item;
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        T item = _items[--_count];
        _items[_count] = default!; // Clear reference for GC
        return item;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        return _items[_count - 1];
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _count);
        _count = 0;
    }

    private void EnsureCapacity()
    {
        if (_count == _items.Length)
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(_items, newItems, _count);
            _items = newItems;
        }
    }
}
