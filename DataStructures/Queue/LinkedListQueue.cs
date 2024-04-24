using DataStructures.LinkedList.Doubly;
using DataStructures.Queue.Contracts;

namespace DataStructures.Queue;

public class LinkedListQueue<T> : IQueue<T>
{
    private DoublyLinkedList<T> linkedlistqueue;

    public LinkedListQueue()
    {
        linkedlistqueue = new DoublyLinkedList<T>();
    }

    public LinkedListQueue(IEnumerable<T> collection) : this()
    {
        foreach (var item in collection)
        {
            Enqueue(item);
        }
    }

    public int Count => linkedlistqueue.Count();

    public T Dequeue()
    {
        if (linkedlistqueue.Head is null)
            throw new Exception("The queue is empty!");
        return linkedlistqueue.RemoveFirst();
    }

    public void Enqueue(T item)
    {
        linkedlistqueue.AddLast(item);
    }

    public T Peek()
    {
        return linkedlistqueue.Head is null ? default : linkedlistqueue.Head.Value;
    }
}