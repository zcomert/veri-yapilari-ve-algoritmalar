namespace DataStructures.Trees.AVL;

public class AVLTree<T> where T : IComparable<T>
{
    public AVLTreeNode<T> root;

    public void Insert(T value)
    {
        root = Insert(root, value);
    }

    private AVLTreeNode<T> Insert(AVLTreeNode<T> node, T value)
    {
        if (node == null)
            return new AVLTreeNode<T>(value);

        int compare = value.CompareTo(node.Value);
        if (compare < 0)
            node.Left = Insert(node.Left, value);
        else if (compare > 0)
            node.Right = Insert(node.Right, value);
        else
            return node; // Duplicate values are not allowed

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        return Balance(node);
    }

    public void Delete(T value)
    {
        root = Delete(root, value);
    }

    private AVLTreeNode<T> Delete(AVLTreeNode<T> node, T value)
    {
        if (node == null)
            return null;

        int compare = value.CompareTo(node.Value);
        if (compare < 0)
            node.Left = Delete(node.Left, value);
        else if (compare > 0)
            node.Right = Delete(node.Right, value);
        else
        {
            if (node.Left == null || node.Right == null)
            {
                node = (node.Left ?? node.Right);
            }
            else
            {
                AVLTreeNode<T> temp = MinValueNode(node.Right);
                node.Value = temp.Value;
                node.Right = Delete(node.Right, temp.Value);
            }
        }

        if (node == null)
            return node;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        return Balance(node);
    }

    private AVLTreeNode<T> MinValueNode(AVLTreeNode<T> node)
    {
        AVLTreeNode<T> current = node;
        while (current.Left != null)
            current = current.Left;

        return current;
    }

    private AVLTreeNode<T> Balance(AVLTreeNode<T> node)
    {
        int balanceFactor = GetBalanceFactor(node);

        // Left-Left (LL) Case
        if (balanceFactor > 1 && GetBalanceFactor(node.Left) >= 0)
            return RotateRight(node);

        // Right-Right (RR) Case
        if (balanceFactor < -1 && GetBalanceFactor(node.Right) <= 0)
            return RotateLeft(node);

        // Left-Right (LR) Case
        if (balanceFactor > 1 && GetBalanceFactor(node.Left) < 0)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        // Right-Left (RL) Case
        if (balanceFactor < -1 && GetBalanceFactor(node.Right) > 0)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    private int GetHeight(AVLTreeNode<T> node)
    {
        return node?.Height ?? 0;
    }

    private int GetBalanceFactor(AVLTreeNode<T> node)
    {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }

    private AVLTreeNode<T> RotateRight(AVLTreeNode<T> y)
    {
        AVLTreeNode<T> x = y.Left;
        AVLTreeNode<T> T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

    private AVLTreeNode<T> RotateLeft(AVLTreeNode<T> x)
    {
        AVLTreeNode<T> y = x.Right;
        AVLTreeNode<T> T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y;
    }

    public void InOrderTraversal(Action<T> action)
    {
        InOrderTraversal(root, action);
    }

    private void InOrderTraversal(AVLTreeNode<T> node, Action<T> action)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, action);
            action(node.Value);
            InOrderTraversal(node.Right, action);
        }
    }

}

