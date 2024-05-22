using DataStructures.Trees.BinaryTree.BinarySearchTree;

namespace Test.TreesTests.BinaryTreeTests.BSTTests;

public class BSTTests
{
    [Fact]
    public void Add_Should_Insert_Value_Correctly()
    {
        // Arrange
        var bst = new BST<int>();

        // Act
        bst.Add(10);
        bst.Add(5);
        bst.Add(15);
        bst.Add(3);
        bst.Add(7);
        bst.Add(12);
        bst.Add(17);

        // Assert
        Assert.Equal(bst.Root.Value, 10);
        Assert.Equal(bst.Root.Left.Value, 5);
        Assert.Equal(bst.Root.Right.Value, 15);
    }

    [Fact]
    public void FindMin_Should_Return_Correct_Minimum_Value()
    {
        // Arrange
        var bst = new BST<int>(new List<int> { 10, 5, 15, 3, 7, 12, 17 });

        // Act
        var min = bst.FindMin();

        // Assert
        Assert.Equal(min, 3);
    }

    [Theory]
    [InlineData(new int[] { 10, 5, 15, 3, 7, 12, 17 }, 17)]
    [InlineData(new int[] { 5, 3, 7, 12, 17, 10, 15 }, 17)]
    [InlineData(new int[] { 3, 7, 5, 12, 17, 15, 10 }, 17)]
    public void FindMax_Should_Return_Correct_Maximum_Value(IEnumerable<int> values, int expectedMax)
    {
        // Arrange
        var bst = new BST<int>(values);

        // Act
        var max = bst.FindMax();


        // Assert
        Assert.Equal(expectedMax, max);
    }

    [Fact]
    public void Find_Should_Return_Correct_Node()
    {
        // Arrange
        var bst = new BST<int>(new List<int> { 10, 5, 15, 3, 7, 12, 17 });

        // Act
        var node = bst.Find(17);

        // Assert
        Assert.Equal(node.Value, 17);
    }

    [Fact]
    public void Remove_Should_Remove_Correct_Node()
    {
        // Arrange
        var bst = new BST<int>(new List<int> { 10, 5, 15, 3, 7, 12, 17 });

        var node = bst.Remove(bst.Root, 15);

        Assert.Equal(node.Value, 15);

    }
}