namespace Array;
using System;
using System.Collections;
using System.Collections.Generic;

public class Array<T> : IEnumerable
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
        DoubleArray();
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

    private void Swap(ref T item1, ref T item2)
    {
        var temp = item1;
        item1 = item2;
        item2 = temp;
    }

    private void DoubleArray()
    {
        if (_count == _items.Length)
        {
            // Resize the array
            T[] newItems = new T[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }
    }

    public void Insert(int index, T item)
    {
        DoubleArray();
        if (index < 0) throw new ArgumentOutOfRangeException("Index out of range!");
        for (int i = _count - 1; i >= index; i--)
        {
            if (i == index)
            {
                Swap(ref _items[i], ref _items[i + 1]);
                _items[i] = item;
                _count++;
                return;
            }
            Swap(ref _items[i], ref _items[i + 1]);
        }
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Length; i++)
        {
            if (_items[i].Equals(item))
                return i;
        }

        return -1;
    }

    public bool Contains(T item)
    {
        if (IndexOf(item) < 0) return false;
        return true;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 && index > Length) throw new ArgumentOutOfRangeException("Index out of range!");
        var item = _items[index];
        Remove(_items[index]);
        return item;
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < Length; i++)
        {
            yield return _items[i];
        }
    }

    public T[] Sort()
    {
        var newArray = new T[Capacity];
        Array.Copy(_items, newArray, _items.Length);
        bool IsSwappped = false;
        for (int i = 0; i < Length - 1; i++)
        {
            IsSwappped = false;

            for (int j = 0; j < Length - i - 1; j++)
            {
                if (newArray[j + 1].CompareTo(newArray[j]) == -1)
                {
                    Swap(ref newArray[j + 1], ref newArray[j]);
                    IsSwappped = true;
                }

                if (IsSwappped == false)
                    break;
            }
        }
        return newArray;
    }
}
