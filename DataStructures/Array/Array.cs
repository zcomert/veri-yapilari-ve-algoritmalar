namespace Array;
using System;
using System.Collections.Generic;

public class Array<T>
    where T : IComparable
{
    private T[] _items;
    private int _count;

    public Array(int size = 4)
    {
        _items = new T[size];
        _count = 0;
    }

    public T this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    public int Length => _count;

    public int Capacity => _items.Length;

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            // Resize the array
            T[] newItems = new T[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }
        _items[_count] = item;
        _count++;
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
            {
                int elementsToShift = _count - i - 1;
                if (elementsToShift > 0)
                {
                    Array.Copy(_items, i + 1, _items, i, elementsToShift);
                }
                _items[--_count] = default!;
                return true;
            }
        }
        return false;
    }

    
    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }
}
