using Trees.BinaryTree;
using Trees.BinaryTree.BinarySearchTree;

namespace TreesTests;

public class BSTTests
{
    [Fact]
    public void DefaultConstructor_ShouldCreateEmptyTree()
    {
        var bst = new BST<int>();

        Assert.Null(bst.Root);
    }

    [Fact]
    public void NodeConstructor_ShouldUseProvidedRoot()
    {
        var root = new Node<int>(10);

        var bst = new BST<int>(root);

        Assert.Same(root, bst.Root);
    }

    [Fact]
    public void CollectionConstructor_ShouldBuildValidSearchTree()
    {
        var bst = new BST<int>(new[] { 8, 3, 10, 1, 6, 14, 4, 7, 13 });

        Assert.Equal(8, bst.Root.Value);
        Assert.Equal(3, bst.Root.Left.Value);
        Assert.Equal(10, bst.Root.Right.Value);
        Assert.Equal(1, bst.Root.Left.Left.Value);
        Assert.Equal(6, bst.Root.Left.Right.Value);
        Assert.Equal(14, bst.Root.Right.Right.Value);
        Assert.Equal(4, bst.Root.Left.Right.Left.Value);
        Assert.Equal(7, bst.Root.Left.Right.Right.Value);
        Assert.Equal(13, bst.Root.Right.Right.Left.Value);
    }

    [Fact]
    public void Add_ShouldSetRoot_WhenTreeIsEmpty()
    {
        var bst = new BST<int>();

        bst.Add(10);

        Assert.NotNull(bst.Root);
        Assert.Equal(10, bst.Root.Value);
    }

    [Fact]
    public void Add_ShouldPlaceSmallerValuesLeft_AndLargerValuesRight()
    {
        var bst = new BST<int>();

        bst.Add(10);
        bst.Add(5);
        bst.Add(15);
        bst.Add(12);

        Assert.Equal(5, bst.Root.Left.Value);
        Assert.Equal(15, bst.Root.Right.Value);
        Assert.Equal(12, bst.Root.Right.Left.Value);
    }

    [Fact]
    public void Add_ShouldPlaceDuplicateValuesOnRightSide()
    {
        var bst = new BST<int>();

        bst.Add(10);
        bst.Add(10);
        bst.Add(10);

        Assert.Equal(10, bst.Root.Value);
        Assert.Equal(10, bst.Root.Right.Value);
        Assert.Equal(10, bst.Root.Right.Right.Value);
    }

    [Fact]
    public void FindMin_WithRootParameter_ShouldReturnSmallestValue()
    {
        var bst = CreateSampleTree();

        var min = bst.FindMin(bst.Root);

        Assert.Equal(1, min);
    }

    [Fact]
    public void FindMin_WithoutParameter_ShouldReturnSmallestValue()
    {
        var bst = CreateSampleTree();

        var min = bst.FindMin();

        Assert.Equal(1, min);
    }

    [Fact]
    public void FindMax_ShouldReturnLargestValue()
    {
        var bst = CreateSampleTree();

        var max = bst.FindMax();

        Assert.Equal(14, max);
    }

    [Fact]
    public void FindMax_ShouldThrow_WhenTreeIsEmpty()
    {
        var bst = new BST<int>();

        var exception = Assert.Throws<Exception>(() => bst.FindMax());

        Assert.Equal("Empty tree!", exception.Message);
    }

    [Fact]
    public void Find_ShouldReturnMatchingNode_WhenValueExists()
    {
        var bst = CreateSampleTree();

        var node = bst.Find(6);

        Assert.NotNull(node);
        Assert.Equal(6, node.Value);
        Assert.Equal(4, node.Left.Value);
        Assert.Equal(7, node.Right.Value);
    }

    [Fact]
    public void Find_ShouldThrow_WhenTreeIsEmpty()
    {
        var bst = new BST<int>();

        var exception = Assert.Throws<Exception>(() => bst.Find(5));

        Assert.Equal("Empty tree!", exception.Message);
    }

    [Fact]
    public void Find_ShouldThrow_WhenValueDoesNotExist()
    {
        var bst = CreateSampleTree();

        var exception = Assert.Throws<Exception>(() => bst.Find(999));

        Assert.Equal("Could not found!", exception.Message);
    }

    [Fact]
    public void Remove_ShouldThrow_WhenTreeIsEmpty()
    {
        var bst = new BST<int>();

        var exception = Assert.Throws<Exception>(() => bst.Remove(bst.Root, 5));

        Assert.Equal("Empty tree!", exception.Message);
    }

    [Fact]
    public void Remove_ShouldDeleteLeafNode()
    {
        var bst = CreateSampleTree();

        bst.Root = bst.Remove(bst.Root, 1);

        Assert.Throws<Exception>(() => bst.Find(1));
        Assert.Null(bst.Root.Left.Left);
    }

    [Fact]
    public void Remove_ShouldDeleteNodeWithOneChild()
    {
        var bst = CreateSampleTree();

        bst.Root = bst.Remove(bst.Root, 14);

        Assert.Equal(13, bst.Root.Right.Right.Value);
        Assert.Throws<Exception>(() => bst.Find(14));
    }

    [Fact]
    public void Remove_ShouldDeleteNodeWithTwoChildren_UsingInorderSuccessor()
    {
        var bst = CreateSampleTree();

        bst.Root = bst.Remove(bst.Root, 3);

        Assert.Equal(4, bst.Root.Left.Value);
        Assert.Equal(1, bst.Root.Left.Left.Value);
        Assert.Equal(6, bst.Root.Left.Right.Value);
        Assert.Equal(7, bst.Root.Left.Right.Right.Value);
        Assert.Throws<Exception>(() => bst.Find(3));
    }

    [Fact]
    public void Remove_ShouldAllowReplacingRoot_WhenRootHasTwoChildren()
    {
        var bst = CreateSampleTree();

        bst.Root = bst.Remove(bst.Root, 8);

        Assert.Equal(10, bst.Root.Value);
        Assert.Equal(14, bst.FindMax());
        Assert.Equal(1, bst.FindMin());
        Assert.Throws<Exception>(() => bst.Find(8));
    }

    private static BST<int> CreateSampleTree()
    {
        return new BST<int>(new[] { 8, 3, 10, 1, 6, 14, 4, 7, 13 });
    }
}
