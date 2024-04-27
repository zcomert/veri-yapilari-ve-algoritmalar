using DataStructures.Trees.BinaryTree;

namespace Test.TreesTests.BinaryTreeTests;

public class BinaryTreeTests
{
    [Fact]
    public void Insert_Should_AddNode_To_Tree()
    {
        // Arrange
        var tree = new BinaryTree<int>();
        int value = 10;

        // Act
        tree.Insert(value);

        // Assert
        Assert.NotNull(tree.Root);
        Assert.Equal(value, tree.Root.Value);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5)]
    [InlineData(new int[] { 10, 20, 30, 40, 50 }, 5)]
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, 5)]
    public void Insert_Should_Increment_Count(IEnumerable<int> values, int expectedCount)
    {
        // Arrange
        var tree = new BinaryTree<int>();

        // Act
        foreach (var value in values)
        {
            tree.Insert(value);
        }

        // Assert
        Assert.Equal(expectedCount, tree.Count);
    }

    [Fact]
    public void PreOrder_Should_Return_Correct_Sequence()
    {
        // Arrange
        var tree = new BinaryTree<int>();
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(12);
        tree.Insert(17);

        var expected = new List<int> { 10, 5, 3, 7, 15, 12, 17 };

        // Act
        var result = BinaryTree<int>
            .PreOrder(tree.Root, new List<Node<int>>())
            .Select(node => node.Value);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void InOrder_Should_Return_Correct_Sequence()
    {
        // Arrange
        var values = new int[] { 3, 5, 7, 10, 12, 15, 17 };
        var tree = new BinaryTree<int>();
        foreach (var value in values)
        {
            tree.Insert(value);
        }

        var expectedList = new List<int>() { 10, 5, 12, 3, 15, 7, 17 };

        // Act
        var result = BinaryTree<int>
            .InOrder(tree.Root, new List<Node<int>>())
            .Select(node => node.Value);

        // Assert
        Assert.Equal(expectedList.OrderBy(x => x), result.OrderBy(x => x));
    }



    [Fact]
    public void Level_Order_Traverse_Should_Return_Correct_Sequence()
    {
        // Arrange
        var tree = new BinaryTree<int>();
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(12);
        tree.Insert(17);
        var expected = new List<int> { 10, 5, 15, 3, 7, 12, 17 };

        // Act
        var result = BinaryTree<int>.LevelOrderTraverse(tree.Root)
            .Select(node => node.Value);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 10, 5, 15, 3, 7, 12, 17 }, 0)]
    [InlineData(new int[] { 5, 3, 7, 10, 15, 12 }, 1)]
    [InlineData(new int[] { 3, 7, 5, 12 }, 1)]
    public void Number_Of_HalfNodes_Should_Return_Correct_Count(IEnumerable<int> values, int expected)
    {
        // Arrange
        var tree = new BinaryTree<int>();
        foreach (var value in values)
        {
            tree.Insert(value);
        }

        // Act
        int result = BinaryTree<int>.NumberOfHalfNodes(tree.Root);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 10, 5, 15, 3, 7, 12, 17 }, 3)]
    [InlineData(new int[] { 5, 3, 7, 10, 15, 12, 17 }, 3)]
    [InlineData(new int[] { 3, 7, 5, 12, 17, 15, 10 }, 3)]
    public void Number_Of_Full_Nodes_Should_Return_Correct_Count(IEnumerable<int> values, int expected)
    {
        // Arrange
        var tree = new BinaryTree<int>();
        foreach (var value in values)
        {
            tree.Insert(value);
        }

        // Act
        int result = BinaryTree<int>.NumberOfFullNodes(tree.Root);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Number_Of_Leafs_Should_Return_Correct_Count()
    {
        // Arrange
        var tree = new BinaryTree<int>();
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(12);
        tree.Insert(17);
        int expected = 4;

        // Act
        int result = BinaryTree<int>.NumberOfLeafs(tree.Root);

        // Assert
        Assert.Equal(expected, result);
    }
}