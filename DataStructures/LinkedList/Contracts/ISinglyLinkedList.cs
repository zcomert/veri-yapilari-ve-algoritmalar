using DataStructures.LinkedList.Singly;

namespace DataStructures.LinkedList.Contracts;

// Abstract Data Type
public interface ISinglyLinkedList<T>
{
    SinglyLinkedListNode<T>? Head { get; }
    int Count { get; }
    void AddFirst(T item);
    void AddLast(T item);
    void AddBefore(SinglyLinkedListNode<T> node, T item);
    void AddAfter(SinglyLinkedListNode<T> node, T item);
    T RemoveFirst();
    public T RemoveLast();
    T Remove(SinglyLinkedListNode<T> node);
}
