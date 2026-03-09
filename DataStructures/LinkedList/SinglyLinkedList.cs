
using System.Collections;

namespace LinkedList;
public class SinglyLinkedList<T> : IEnumerable<T>
{
    public Node<T> Head { get; set; }
    
    public int Count { get; }

    public SinglyLinkedList()
    {
        
    }

    public void AddFirst(T item)
    {
        var newNode = new Node<T>(item);
        if (Head is null)
        {
            Head = newNode;
            return;
        }

        newNode.Next = Head;
        Head = newNode;

    }

    public IEnumerator<T> GetEnumerator()
    {
        return new SinglyLinkedListEnumerator<T>(Head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return GetEnumerator();
    }

    public void AddAfter(Node<T> node, T item)
    {
        throw new NotImplementedException();
    }

    public void AddBefore(Node<T> node, T item)
    {
        throw new NotImplementedException();
    }

    public void AddLast(T item)
    {
        throw new NotImplementedException();
    }

    public T Remove(Node<T> node)
    {
        throw new NotImplementedException();
    }

    public T RemoveFirst()
    {
        throw new NotImplementedException();
    }

    public T RemoveLast()
    {
        throw new NotImplementedException();
    }
}
