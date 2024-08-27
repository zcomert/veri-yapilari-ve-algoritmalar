namespace DataStructures.Trees.AVL;

public class AVLTreeNode<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public AVLTreeNode<T> Left { get; set; }
    public AVLTreeNode<T> Right { get; set; }
    public int Height { get; set; }

    public AVLTreeNode(T value)
    {
        Value = value;
        Height = 1;
    }
}

