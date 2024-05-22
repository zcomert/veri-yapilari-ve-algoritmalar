using DataStructures.Array;
using System.Collections;

namespace DataStructures.PriorityQueue;
public abstract class BHeap<T> : IEnumerable
    where T : IComparable
{
    protected int position;
    public Array<T> Array { get; private set; } = new Array<T>();

    public int Count { get; private set; }

    public BHeap(int _size = 128)
    {
        Count = 0;
        Array = new Array<T>(_size);
        position = 0;
    }

    public BHeap(IEnumerable<T> collection) : this(collection.ToArray().Length)
    {
        foreach (var item in collection)
            Add(item);
    }

    public int GetLeftChildIndex(int i) => 2 * i + 1;
    public int GetRightChildIndex(int i) => 2 * i + 2;
    public int GetParentIndex(int i) => (i - 1) / 2;

    protected bool HasLeftChild(int i) =>
        GetLeftChildIndex(i) < position;

    protected bool HasRightChild(int i) =>
        GetRightChildIndex(i) < position;

    protected bool IsRoot(int i) { return i == 0; }

    protected T GetLeftChild(int i) =>
        Array.GetValue(GetLeftChildIndex(i));
    protected T GetRightChild(int i) =>
        Array.GetValue(GetRightChildIndex(i));

    protected T GetParent(int i) =>
        Array.GetValue(GetParentIndex(i));

    public bool IsEmpty() => position == 0;

    public T Peek()
    {
        if (IsEmpty())
            throw new Exception("Empty heap!");
        return Array.GetValue(0);
    }

    public void Swap(int first, int second)
    {
        var temp = Array.GetValue(first);
        Array.SetValue(Array.GetValue(second), first);
        Array.SetValue(temp, second);
    }

    public void Add(T value)
    {
        //if (position == Array.Length)
        //    throw new IndexOutOfRangeException("Overflow!");
        Array.SetValue(value, position);
        position++;
        Count++;
        HeapifyUp();
    }

    public T DeleteMinMax()
    {
        if (position == 0)
            throw new IndexOutOfRangeException("Underflow!");
        var temp = Array.GetValue(0);
        Array.SetValue(Array.GetValue(position - 1), 0);
        // Array.RemoveAt(position - 1);
        position--;
        Count--;
        HeapifyDown();
        return temp;
    }

    protected abstract void HeapifyUp();
    protected abstract void HeapifyDown();

    public IEnumerator GetEnumerator()
    {
        return Array.GetEnumerator();
    }
}