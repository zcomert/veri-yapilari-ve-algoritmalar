using System.Collections;

namespace DataStructures.Trees.BinaryTree;

public class BinaryTree<T> : IEnumerable
{
    public Node<T> Root { get; set; }
    public int Count { get; set; }

    public BinaryTree()
    {
        Count = 0;
    }

    public BinaryTree(IEnumerable<T> collection) : this()
    {
        foreach (var item in collection)
            Insert(item);
    }

    public T Insert(T value)
    {
        var newNode = new Node<T>(value);

        // Root ?
        if (Root == null)
        {
            Root = newNode;
            Count++;
            return value;
        }

        var list = new List<Node<T>>();
        var q = new Queue<Node<T>>();
        q.Enqueue(Root);
        while (q.Count > 0)
        {
            var temp = q.Dequeue();
            list.Add(temp);
            if (temp.Left != null)
                q.Enqueue(temp.Left);
            else
            {
                temp.Left = newNode;
                Count++;
                return value;
            }
            if (temp.Right != null)
                q.Enqueue(temp.Right);
            else
            {
                temp.Right = newNode;
                Count++;
                return value;
            }
        }
        throw new Exception("The insertion operation failed.");
    }

    public static List<Node<T>> PreOrder(Node<T> root, List<Node<T>> list)
    {
        if (!(root == null))
        {
            list.Add(root);
            PreOrder(root.Left, list);
            PreOrder(root.Right, list);
        }
        return list;
    }

    public static List<Node<T>> InOrder(Node<T> root, List<Node<T>> list)
    {
        if (!(root == null))
        {
            InOrder(root.Left, list);
            list.Add(root);
            InOrder(root.Right, list);
        }
        return list;
    }

    public static List<Node<T>> PostOrder(Node<T> root, List<Node<T>> list)
    {
        if (!(root == null))
        {
            PostOrder(root.Left, list);
            PostOrder(root.Right, list);
            list.Add(root);
        }
        return list;
    }

    public static List<T> InOrderIterationTraverse(Node<T> root)
    {
        if (root == null)
            return null;

        var list = new List<T>();
        var stack = new Stack<Node<T>>();
        bool done = false;
        Node<T> currentNode = root;
        while (!done)
        {
            if (currentNode != null)
            {
                stack.Push(currentNode);
                currentNode = currentNode.Left;
            }
            else
            {
                if (stack.Count == 0)
                {
                    done = true;
                }
                else
                {
                    currentNode = stack.Pop();
                    list.Add(currentNode.Value);
                    currentNode = currentNode.Right;
                }
            }
        }

        return list;
    }

    public static List<Node<T>> LevelOrderTraverse(Node<T> root)
    {
        var list = new List<Node<T>>();
        if (root != null)
        {
            var q = new Queue<Node<T>>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                list.Add(temp);
                if (temp.Left != null) q.Enqueue(temp.Left);
                if (temp.Right != null) q.Enqueue(temp.Right);
            }
        }
        return list;
    }

    public IEnumerator GetEnumerator()
    {
        // return LevelOrderTraverse(this.Root).GetEnumerator();
        return InOrderIterationTraverse(this.Root).GetEnumerator();
    }

    public T Delete(T value)
    {
        throw new NotImplementedException();
    }

    public T Delete()
    {
        throw new NotImplementedException();
    }

    public static int NumberOfHalfNodes(Node<T> root)
    {
        return BinaryTree<T>
            .LevelOrderTraverse(root)
            .Where(node => (node.Left != null && node.Right == null)
                || (node.Left == null && node.Right != null))
            .ToList()
            .Count;
    }

    public static int NumberOfFullNodes(Node<T> root) =>
        BinaryTree<T>.LevelOrderTraverse(root)
        .Where(node => node.Left != null && node.Right != null)
        .ToList()
        .Count;

    public static int NumberOfLeafs(Node<T> root)
    {
        int count = 0;
        if (root == null) return count;
        var q = new Queue<Node<T>>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var temp = q.Dequeue();
            if (temp.Left == null && temp.Right == null)
                count++;
            if (temp.Left != null)
                q.Enqueue(temp.Left);
            if (temp.Right != null)
                q.Enqueue(temp.Right);
        }
        return count;
        /*
        return new BinaryTree<T>()
            .LevelOrderNonRecursiveTraversal(root)
            .Where(x => x.Left == null && x.Right == null)
            .ToList()
            .Count;
        */
    }

}
