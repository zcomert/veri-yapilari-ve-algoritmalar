namespace Array;

using System;
using System.Collections;
using System.Collections.Generic;

public partial class Array<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 4;
    private T[] _innerArray;
    private int _count;

    public int Count => _count;
    public int Length => _count;
    public int Capacity => _innerArray.Length;

    public T this[int index]
    {
        get
        {
            ValidateIndex(index);
            return _innerArray[index];
        }
        set
        {
            ValidateIndex(index);
            _innerArray[index] = value;
        }
    }

    public Array(int size = DefaultCapacity)
    {
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size));

        _innerArray = new T[size == 0 ? DefaultCapacity : size];
    }

    public Array(params T[] init)
    {
        ArgumentNullException.ThrowIfNull(init);

        var capacity = init.Length == 0 ? DefaultCapacity : init.Length;
        _innerArray = new T[capacity];
        System.Array.Copy(init, _innerArray, init.Length);
        _count = init.Length;
    }

    public void Add(T item)
    {
        EnsureCapacity(_count + 1);
        _innerArray[_count] = item;
        _count++;
    }

    public void AddRange(IEnumerable<T> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        foreach (var item in items)
            Add(item);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _count)
            throw new IndexOutOfRangeException();

        EnsureCapacity(_count + 1);

        for (int i = _count; i > index; i--)
            _innerArray[i] = _innerArray[i - 1];

        _innerArray[index] = item;
        _count++;
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index < 0)
            return false;

        RemoveAt(index);
        return true;
    }

    public T RemoveAt(int index)
    {
        ValidateIndex(index);

        var item = _innerArray[index];
        for (int i = index; i < _count - 1; i++)
            _innerArray[i] = _innerArray[i + 1];

        _count--;
        _innerArray[_count] = default!;
        ShrinkIfNeeded();

        return item;
    }

    public T RemoveItem(int position) => RemoveAt(position);

    public void Swap(int p1, int p2)
    {
        ValidateIndex(p1);
        ValidateIndex(p2);

        var temp = _innerArray[p1];
        _innerArray[p1] = _innerArray[p2];
        _innerArray[p2] = temp;
    }

    public int Find(T item) => IndexOf(item);

    public int IndexOf(T item)
    {
        var comparer = EqualityComparer<T>.Default;
        for (int i = 0; i < _count; i++)
        {
            if (comparer.Equals(_innerArray[i], item))
                return i;
        }

        return -1;
    }

    public bool Contains(T item) => IndexOf(item) >= 0;

    public T[] Copy(int v1, int v2)
    {
        if (v1 < 0 || v2 < v1 || v2 > _count)
            throw new IndexOutOfRangeException();

        var newArray = new T[v2 - v1];
        for (int i = v1; i < v2; i++)
            newArray[i - v1] = _innerArray[i];

        return newArray;
    }

    public Array<T> Sort()
    {
        System.Array.Sort(_innerArray, 0, _count, Comparer<T>.Default);
        return this;
    }

    public T GetItem(int position) => this[position];

    public void SetItem(int position, T item) => this[position] = item;

    public T GetValue(int index) => this[index];

    public void SetValue(T value, int index) => this[index] = value;

    public IEnumerator<T> GetEnumerator()
    {
        return new ArrayEnumerator<T>(_innerArray, _count);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void EnsureCapacity(int requiredCapacity)
    {
        if (requiredCapacity <= _innerArray.Length)
            return;

        var newCapacity = _innerArray.Length == 0 ? DefaultCapacity : _innerArray.Length;
        while (newCapacity < requiredCapacity)
            newCapacity *= 2;

        Resize(newCapacity);
    }

    private void ShrinkIfNeeded()
    {
        if (_innerArray.Length <= DefaultCapacity)
            return;

        if (_count > _innerArray.Length / 4)
            return;

        Resize(Math.Max(DefaultCapacity, _innerArray.Length / 2));
    }

    private void Resize(int newCapacity)
    {
        var resized = new T[newCapacity];
        if (_count > 0)
            System.Array.Copy(_innerArray, resized, _count);

        _innerArray = resized;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException();
    }
}

public class ArrayEnumerator<T> : IEnumerator<T>
{
    private readonly T[] _array;
    private readonly int _count;
    private int _index;

    public ArrayEnumerator(T[] array, int count)
    {
        _array = array ?? throw new ArgumentNullException(nameof(array));
        _count = count;
        _index = -1;
    }

    public T Current
    {
        get
        {
            if (_index < 0 || _index >= _count)
                throw new InvalidOperationException();

            return _array[_index];
        }
    }

    object IEnumerator.Current => Current!;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (_index + 1 >= _count)
            return false;

        _index++;
        return true;
    }

    public void Reset()
    {
        _index = -1;
    }
}
