namespace DataStructures.LinkedList.Doubly;
public class DbNode<T>
{
    public T? Value { get; set; }

    public DbNode<T> Next { get; set; }
    public DbNode<T> Prev { get; set; }

    public DbNode(T? value) : this()
    {
        Value = value;
    }

    public DbNode()
    {
        Next = null;
        Prev = null;
    }

    public override string? ToString()
    {
        return $"{Value}";
    }
}
