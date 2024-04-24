using DataStructures.Queue.Contracts;

namespace DataStructures.Queue;

public class Queue<T> : IQueue<T>
{
    private readonly IQueue<T>? _queue;

    public int Count => _queue.Count;

    public Queue()
    {
        // _queue = new ArrayQueue<T>();
        _queue = new LinkedListQueue<T>();
    }

    public Queue(string type)
    {
        if (type.ToLower() == "array")
            _queue = new ArrayQueue<T>();
        else if (type.ToLower() == "linked")
            _queue = new LinkedListQueue<T>();
        else
        {
            throw new Exception("Type not valid!");
        }
    }

    public Queue(IEnumerable<T> collection) : this()
    {
        foreach (var item in collection)
        {
            Enqueue(item);
        }
    }

    public T? Peek()
    {
        return _queue.Peek();
    }

    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
    }

    public T Dequeue()
    {
        return _queue.Dequeue();
    }
}