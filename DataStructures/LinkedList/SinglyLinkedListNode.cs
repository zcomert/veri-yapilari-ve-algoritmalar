namespace LinkedList;

public class SinglyLinkedListNode<T>
{
    public T? Item { get; set; }
    public SinglyLinkedListNode<T> Next { get; set; }

    public SinglyLinkedListNode()
    {

    }
    public SinglyLinkedListNode(T? item)
    {
        Item = item;
    }

    public override string ToString()
    {
        return Item?.ToString() ?? "null";
    }



}
