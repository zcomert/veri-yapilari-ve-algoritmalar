using System.Collections;
using DataStructures.Array;

namespace Array;

public class StaticArray<T> : IArray<T>, IEnumerable<T>
{
    private T[] _innerArray;
    public StaticArray()
    {
        _innerArray = new T[4];
    }

    public StaticArray(IEnumerable<T> collection)
    {
        _innerArray = new T[collection.Count()];
        int i = 0;
        foreach (var item in collection)
        {
            SetItem(i, item);
        }
    }

    public int Length => _innerArray.Length;


    public T GetItem(int index)
    {
        if (index < 0 || index >= _innerArray.Length)
            throw new IndexOutOfRangeException();

        return _innerArray[index];
    }

    public void SetItem(int index, T value)
    {
        if (index < 0 || index >= _innerArray.Length)
            throw new IndexOutOfRangeException();

        _innerArray[index] = value;
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= _innerArray.Length)
            throw new IndexOutOfRangeException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in _innerArray)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
