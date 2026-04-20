namespace DisjointSet;

public class DisjointSetNode<T>
{
    public T Value { get; set; } = default!;
    public int Rank { get; set; }
    public DisjointSetNode<T> Parent { get; set; } = null!;
    public DisjointSetNode()
    {

    }
    public DisjointSetNode(T value)
    {
        Value = value;
        Rank = 0;
    }
    public DisjointSetNode(T value, int rank)
    {
        Value = value;
        Rank = rank;
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}
