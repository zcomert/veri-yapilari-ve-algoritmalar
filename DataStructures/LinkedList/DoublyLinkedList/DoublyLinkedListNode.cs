namespace LinkedList.DoublyLinkedList;

public class DoublyLinkedListNode<T>
{
    public T? Item { get; set; }
    public DoublyLinkedListNode<T>? Next { get; set; }
    public DoublyLinkedListNode<T>? Prev { get; set; }

    public DoublyLinkedListNode()
    {

    }

    public DoublyLinkedListNode(T? item)
    {
        Item = item;
    }

    public override string ToString()
    {
        return Item?.ToString() ?? "null";
    }
}
