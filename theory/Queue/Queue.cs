using Queue.ADT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue;

public class Queue<T> : IQueue<T>
{
    private IQueue<T> _queue;
    public Queue()
    {
        _queue = new QueueLinkedList<T>();
    }
    public int Count => _queue.Count;

    public bool IsEmpty => _queue.IsEmpty;

    public void Clear()
    {
        _queue.Clear(); 
    }

    public T Dequeu()
    {
        return _queue.Dequeu();
    }

    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
    }

    public T Peek()
    {
        return _queue.Peek();
    }
}
