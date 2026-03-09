namespace LinkedList;

public class Node<T>
{
    public T? Item { get; set; }
    public Node<T> Next { get; set; }

    public Node()
    {

    }
    public Node(T? item)
    {
        Item = item;
    }

    public override string ToString()
    {
        return Item?.ToString() ?? "null";
    }



}
