using DataStructures.Array;
using DataStructures.Queue.Contracts;

namespace DataStructures.Queue;

public class ArrayQueue<T> : IQueue<T>
{
    // private List<T> _innerArray;
    private Array<T> _innerArray;

    public ArrayQueue()
    {
        // _innerArray = new List<T>();
        _innerArray = new Array<T>();
    }

    public ArrayQueue(IEnumerable<T> collection) : this()
    {
        foreach (var item in collection)
        {
            Enqueue(item);
        }
    }

    public int Count => _innerArray.Count;

    public T Dequeue()
    {
        if (Count == 0)
            throw new Exception("The queue is empty!");
        // var temp = _innerArray[0];
        // _innerArray.RemoveAt(0);

        var temp = _innerArray.RemoveAt(0);
        return temp;
    }

    public void Enqueue(T item)
    {
        _innerArray.Add(item);
    }

    public T Peek()
    {
        // return Count == 0 ? default : _innerArray[0];
        return Count == 0 ? default : _innerArray.GetItem(0); // _innerArray[0];
    }
}
