using System.Collections;

namespace LinkedList.DoublyLinkedList;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private int _count = 0;
    public DoublyLinkedListNode<T>? Head { get; set; }
    public DoublyLinkedListNode<T>? Tail { get; set; }

    public int Count { get => _count; }

    public DoublyLinkedList()
    {

    }

    public void AddFirst(T item)
    {
        var newNode = new DoublyLinkedListNode<T>(item);
        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
            _count++;
            return;
        }

        newNode.Next = Head;
        Head.Prev = newNode;
        Head = newNode;
        _count++;
    }

    public void AddLast(T item)
    {
        var newNode = new DoublyLinkedListNode<T>(item);
        if (Head is null)
        {
            Head = newNode;
            Tail = newNode;
            _count++;
            return;
        }

        newNode.Prev = Tail;
        Tail!.Next = newNode;
        Tail = newNode;
        _count++;
    }

    public void AddAfter(DoublyLinkedListNode<T> node, T item)
    {
        if (node == null) throw new ArgumentNullException(nameof(node));

        var newNode = new DoublyLinkedListNode<T>(item);
        
        newNode.Next = node.Next;
        newNode.Prev = node;

        if (node.Next != null)
        {
            node.Next.Prev = newNode;
        }
        else
        {
            Tail = newNode;
        }

        node.Next = newNode;
        _count++;
    }

    public void AddBefore(DoublyLinkedListNode<T> node, T item)
    {
        if (node == null) throw new ArgumentNullException(nameof(node));

        var newNode = new DoublyLinkedListNode<T>(item);

        newNode.Next = node;
        newNode.Prev = node.Prev;

        if (node.Prev != null)
        {
            node.Prev.Next = newNode;
        }
        else
        {
            Head = newNode;
        }

        node.Prev = newNode;
        _count++;
    }

    public T? RemoveFirst()
    {
        if (Head is null)
            throw new Exception("DoublyLinkedList is empty!");

        T? item = Head.Item;

        if (Head.Next == null)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Head = Head.Next;
            Head.Prev = null;
        }

        _count--;
        return item;
    }

    public T? RemoveLast()
    {
        if (Tail is null)
            throw new Exception("DoublyLinkedList is empty!");

        T? item = Tail.Item;

        if (Tail.Prev == null)
        {
            Head = null;
            Tail = null;
        }
        else
        {
            Tail = Tail.Prev;
            Tail.Next = null;
        }

        _count--;
        return item;
    }

    public T? Remove(DoublyLinkedListNode<T> node)
    {
        if (node == null) throw new ArgumentNullException(nameof(node));

        if (node == Head)
            return RemoveFirst();
        
        if (node == Tail)
            return RemoveLast();

        node.Prev!.Next = node.Next;
        node.Next!.Prev = node.Prev;

        _count--;
        return node.Item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new DoublyLinkedListEnumerator<T>(Head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
