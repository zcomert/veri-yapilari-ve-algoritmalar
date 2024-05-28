using System.Collections;

namespace DataStructures.DisjointSet;
public class DisjointSet<T> : IEnumerable<T>
{
    private Dictionary<T, DisjointSetNode<T>> set;


    public DisjointSet()
    {
        set = new Dictionary<T, DisjointSetNode<T>>();
    }

    public DisjointSet(IEnumerable<T> collection) : this()
    {
        foreach (var item in collection)
            MakeSet(item);
    }

    public int Count { get; private set; }

    public void MakeSet(T value)
    {
        if (set.ContainsKey(value))
            throw new Exception("The value has already been defined.");

        var newSet = new DisjointSetNode<T>(value, 0);
        newSet.Parent = newSet;
        set.Add(value, newSet);
        Count++;
    }

    public T FindSet(T value)
    {
        if (!set.ContainsKey(value))
            throw new Exception("The value is not in this set!");
        return findSet(set[value]).Value;
    }

    private DisjointSetNode<T> findSet(DisjointSetNode<T> node)
    {
        var parent = node.Parent;
        if (node != parent)
        {
            node.Parent = findSet(node.Parent);
            return node.Parent;
        }
        return parent;
    }

    public void Union(T valueA, T valueB)
    {
        if (valueA == null || valueB == null)
            throw new ArgumentNullException();

        var rootA = FindSet(valueA);
        var rootB = FindSet(valueB);

        if (rootA.Equals(rootB))
            return;

        var nodeA = set[rootA];
        var nodeB = set[rootB];

        if (nodeA.Rank <= nodeB.Rank)
        {
            nodeB.Parent = nodeA;
            nodeA.Rank += nodeB.Rank; 
        }
        else
        {
            nodeA.Parent = nodeB;
            nodeB.Rank += nodeA.Rank; 
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return set.Values.Select(x => x.Value).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

