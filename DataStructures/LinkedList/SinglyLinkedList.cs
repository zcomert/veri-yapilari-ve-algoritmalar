
using System.Collections;

namespace LinkedList;
public class SinglyLinkedList<T> : IEnumerable<T>
{
    public Node<T> Head { get; set; }

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
}
