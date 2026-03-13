
using System.Collections;

namespace LinkedList;
public class SinglyLinkedList<T> : IEnumerable<T>
{
    private int _count = 0;
    public SinglyLinkedListNode<T> Head { get; set; }

    public int Count { get => _count; }

    public SinglyLinkedList()
    {

    }

    public void AddFirst(T item)
    {
        var newNode = new SinglyLinkedListNode<T>(item);
        if (Head is null)
        {
            Head = newNode;
            _count++;
            return;
        }

        newNode.Next = Head;
        Head = newNode;
        _count++;
    }

    public void AddLast(T item)
    {
        var newNode = new SinglyLinkedListNode<T>(item);
        if (Head is null)
        {
            Head = newNode;
            _count++;
            return;
        }

        var curr = Head;
        while (curr.Next != null)
            curr = curr.Next;

        curr.Next = newNode;
        _count++;
    }

    public void AddAfter(SinglyLinkedListNode<T> node, T item)
    {
        var newNode = new SinglyLinkedListNode<T>(item);
        if (Head is null)
        {
            AddFirst(item);
            return;
        }

        var curr = Head;
        while (!curr.Item.Equals(node.Item))
            curr = curr.Next;

        newNode.Next = curr.Next;
        curr.Next = newNode;
        _count++;
    }

    public void AddBefore(SinglyLinkedListNode<T> node, T item)
    {
        var newNode = new SinglyLinkedListNode<T>(item);
        if (Head is null)
        {
            AddFirst(item);
            return;
        }
        if (Head.Item.Equals(node.Item))
        {
            AddFirst(item);
            return;
        }

        var curr = Head;
        while (!curr.Next.Item.Equals(node.Item))
            curr = curr.Next;

        newNode.Next = curr.Next;
        curr.Next = newNode;
        _count++;
    }

    public T Remove(SinglyLinkedListNode<T> node)
    {
        T item = default;
        if (Head is null)
            throw new Exception("SinglyLinkedList is empty!");

        if (Head.Item.Equals(node.Item)) // _count == 1;
        {
            item = RemoveFirst();
            return item;
        }

        var curr = Head;
        while (!curr.Next.Item.Equals(node.Item))
            curr = curr.Next;

        item = curr.Next.Item;
        curr.Next = curr.Next.Next;
        _count--;
        return item;
    }

    public T RemoveFirst()
    {
        T item = default;
        if (Head is null)
            throw new Exception("SinglyLinkedList is empty!");

        if (Head.Next.Equals(null)) // _count == 1;
        {
            item = Head.Item;
            Head = null;
            _count--;
            return item;
        }

        item = Head.Item;
        Head = Head.Next;
        _count--;
        return item;
    }

    public T RemoveLast()
    {
        T item = default;
        if (Head is null)
            throw new Exception("SinglyLinkedList is empty!");

        if (Head.Next.Equals(null)) // _count == 1;
        {
            item = Head.Item;
            Head = null;
            _count--;
            return item;
        }

        var curr = Head;
        while (curr.Next.Next != null)
            curr = curr.Next;

        item = curr.Next.Item;
        curr.Next = null;
        _count--;
        return item;
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
