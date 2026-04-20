using Trees.BinaryTree;

namespace TreesTests;

public class BinaryTreeTests
{
    [Fact]
    public void Node_Constructor_ShouldSetValue_AndRepresentItselfAsString()
    {
        var node = new Node<int>(42);

        Assert.Equal(42, node.Value);
        Assert.Equal("42", node.ToString());
    }

    [Fact]
    public void Node_DefaultConstructor_ShouldCreateLeafNode()
    {
        var node = new Node<int>();

        Assert.True(node.IsLeaf);
        Assert.Null(node.Left);
        Assert.Null(node.Right);
    }

    [Fact]
    public void Node_IsLeaf_ShouldReturnFalse_WhenNodeHasAnyChild()
    {
        var node = new Node<int>(1)
        {
            Left = new Node<int>(2)
        };

        Assert.False(node.IsLeaf);
    }

    [Fact]
    public void BinaryTree_DefaultConstructor_ShouldCreateEmptyTree()
    {
        var tree = new BinaryTree<int>();

        Assert.Null(tree.Root);
        Assert.Equal(0, tree.Count);
    }

    [Fact]
    public void BinaryTree_CollectionConstructor_ShouldInsertItemsInLevelOrder()
    {
        var tree = new BinaryTree<int>(new[] { 1, 2, 3, 4, 5 });

        Assert.Equal(5, tree.Count);
        Assert.NotNull(tree.Root);
        Assert.Equal(1, tree.Root!.Value);
        Assert.Equal(2, tree.Root.Left!.Value);
        Assert.Equal(3, tree.Root.Right!.Value);
        Assert.Equal(4, tree.Root.Left.Left!.Value);
        Assert.Equal(5, tree.Root.Left.Right!.Value);
    }

    [Fact]
    public void Insert_ShouldSetRoot_WhenTreeIsEmpty()
    {
        var tree = new BinaryTree<string>();

        var inserted = tree.Insert("root");

        Assert.Equal("root", inserted);
        Assert.Equal(1, tree.Count);
        Assert.NotNull(tree.Root);
        Assert.Equal("root", tree.Root!.Value);
    }

    [Fact]
    public void Insert_ShouldPlaceNodesInLevelOrder()
    {
        var tree = new BinaryTree<int>();

        foreach (var value in Enumerable.Range(1, 6))
            tree.Insert(value);

        Assert.Equal(6, tree.Count);
        Assert.Equal(1, tree.Root!.Value);
        Assert.Equal(2, tree.Root.Left!.Value);
        Assert.Equal(3, tree.Root.Right!.Value);
        Assert.Equal(4, tree.Root.Left.Left!.Value);
        Assert.Equal(5, tree.Root.Left.Right!.Value);
        Assert.Equal(6, tree.Root.Right.Left!.Value);
    }

    [Fact]
    public void PreOrder_ShouldReturnExpectedSequence()
    {
        var tree = CreateSampleTree();

        var traversal = BinaryTree<int>.PreOrder(tree.Root!, new List<Node<int>>());

        Assert.Equal(new[] { 1, 2, 4, 5, 3, 6 }, traversal.Select(node => node.Value));
    }

    [Fact]
    public void InOrder_ShouldReturnExpectedSequence()
    {
        var tree = CreateSampleTree();

        var traversal = BinaryTree<int>.InOrder(tree.Root!, new List<Node<int>>());

        Assert.Equal(new[] { 4, 2, 5, 1, 6, 3 }, traversal.Select(node => node.Value));
    }

    [Fact]
    public void PostOrder_ShouldReturnExpectedSequence()
    {
        var tree = CreateSampleTree();

        var traversal = BinaryTree<int>.PostOrder(tree.Root!, new List<Node<int>>());

        Assert.Equal(new[] { 4, 5, 2, 6, 3, 1 }, traversal.Select(node => node.Value));
    }

    [Fact]
    public void TraversalMethods_ShouldReturnEmptyList_WhenRootIsNull()
    {
        Assert.Empty(BinaryTree<int>.PreOrder(null!, new List<Node<int>>()));
        Assert.Empty(BinaryTree<int>.InOrder(null!, new List<Node<int>>()));
        Assert.Empty(BinaryTree<int>.PostOrder(null!, new List<Node<int>>()));
        Assert.Empty(BinaryTree<int>.LevelOrderTraverse(null!));
    }

    [Fact]
    public void InOrderIterationTraverse_ShouldReturnExpectedSequence()
    {
        var tree = CreateSampleTree();

        var traversal = BinaryTree<int>.InOrderIterationTraverse(tree.Root!);

        Assert.NotNull(traversal);
        Assert.Equal(new[] { 4, 2, 5, 1, 6, 3 }, traversal);
    }

    [Fact]
    public void InOrderIterationTraverse_ShouldReturnNull_WhenRootIsNull()
    {
        var traversal = BinaryTree<int>.InOrderIterationTraverse(null!);

        Assert.Null(traversal);
    }

    [Fact]
    public void LevelOrderTraverse_ShouldReturnExpectedSequence()
    {
        var tree = CreateSampleTree();

        var traversal = BinaryTree<int>.LevelOrderTraverse(tree.Root!);

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, traversal.Select(node => node.Value));
    }

    [Fact]
    public void GetEnumerator_ShouldIterateInLevelOrder()
    {
        var tree = CreateSampleTree();
        var values = new List<int>();

        foreach (Node<int> node in tree)
            values.Add(node.Value);

        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, values);
    }

    [Fact]
    public void NumberOfHalfNodes_ShouldReturnZero_ForNullRoot()
    {
        Assert.Equal(0, BinaryTree<int>.NumberOfHalfNodes(null!));
    }

    [Fact]
    public void NumberOfFullNodes_ShouldReturnZero_ForNullRoot()
    {
        Assert.Equal(0, BinaryTree<int>.NumberOfFullNodes(null!));
    }

    [Fact]
    public void NumberOfLeafs_ShouldReturnZero_ForNullRoot()
    {
        Assert.Equal(0, BinaryTree<int>.NumberOfLeafs(null!));
    }

    [Fact]
    public void NodeCountingHelpers_ShouldReturnExpectedCounts_ForMixedTree()
    {
        var root = new Node<int>(1)
        {
            Left = new Node<int>(2)
            {
                Left = new Node<int>(4)
            },
            Right = new Node<int>(3)
            {
                Left = new Node<int>(5),
                Right = new Node<int>(6)
                {
                    Right = new Node<int>(7)
                }
            }
        };

        Assert.Equal(2, BinaryTree<int>.NumberOfHalfNodes(root));
        Assert.Equal(2, BinaryTree<int>.NumberOfFullNodes(root));
        Assert.Equal(3, BinaryTree<int>.NumberOfLeafs(root));
    }

    private static BinaryTree<int> CreateSampleTree()
    {
        return new BinaryTree<int>(new[] { 1, 2, 3, 4, 5, 6 });
    }
}
