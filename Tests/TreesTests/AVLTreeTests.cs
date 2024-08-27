using DataStructures.Trees.AVL;

namespace Test.TreesTests.AVLTreeTests;
public class AVLTreeTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Arrange
        int value = 10;

        // Act
        var node = new AVLTreeNode<int>(value);

        // Assert
        Assert.Equal(value, node.Value);
        Assert.Null(node.Left);
        Assert.Null(node.Right);
        Assert.Equal(1, node.Height); // Default height should be 1
    }

    [Fact]
    public void Properties_ShouldSetAndGetCorrectly()
    {
        // Arrange
        int value = 20;
        var node = new AVLTreeNode<int>(value);
        var leftNode = new AVLTreeNode<int>(15);
        var rightNode = new AVLTreeNode<int>(25);

        // Act
        node.Left = leftNode;
        node.Right = rightNode;
        node.Height = 2;

        // Assert
        Assert.Equal(leftNode, node.Left);
        Assert.Equal(rightNode, node.Right);
        Assert.Equal(2, node.Height);
    }

    [Fact]
    public void Insert_ShouldInsertElementsCorrectly()
    {
        // Arrange
        var avlTree = new AVLTree<int>();
        var numbers = new int[] { 10, 20, 30, 40, 50 };

        // Act
        foreach (var number in numbers)
        {
            avlTree.Insert(number);
        }

        // Assert
        var result = new List<int>();
        avlTree.InOrderTraversal(value => result.Add(value));

        Assert.Equal(numbers.OrderBy(n => n), result);
    }

    [Fact]
    public void Insert_ShouldMaintainAVLProperty()
    {
        // Arrange
        var avlTree = new AVLTree<int>();
        var numbers = new int[] { 30, 20, 40, 10, 25, 35, 50 };

        // Act
        foreach (var number in numbers)
        {
            avlTree.Insert(number);
        }

        // Assert
        Assert.Equal(3, avlTree.root.Height);  // Root should have height 3 for a balanced tree
    }

    [Fact]
    public void Delete_ShouldDeleteLeafNodeCorrectly()
    {
        // Arrange
        var avlTree = new AVLTree<int>();
        var numbers = new int[] { 10, 20, 30, 40, 50 };

        foreach (var number in numbers)
        {
            avlTree.Insert(number);
        }

        // Act
        avlTree.Delete(50);

        // Assert
        var result = new List<int>();
        avlTree.InOrderTraversal(value => result.Add(value));

        Assert.DoesNotContain(50, result);
        Assert.Equal(new int[] { 10, 20, 30, 40 }, result);
    }

    [Fact]
    public void Delete_ShouldDeleteNodeWithOneChildCorrectly()
    {
        // Arrange
        var avlTree = new AVLTree<int>();
        var numbers = new int[] { 10, 20, 30, 40, 50 };

        foreach (var number in numbers)
        {
            avlTree.Insert(number);
        }

        // Act
        avlTree.Delete(40);

        // Assert
        var result = new List<int>();
        avlTree.InOrderTraversal(value => result.Add(value));

        Assert.DoesNotContain(40, result);
        Assert.Equal(new int[] { 10, 20, 30, 50 }, result);
    }

    [Fact]
    public void Delete_ShouldDeleteNodeWithTwoChildrenCorrectly()
    {
        // Arrange
        var avlTree = new AVLTree<int>();
        var numbers = new int[] { 10, 20, 30, 40, 50 };

        foreach (var number in numbers)
        {
            avlTree.Insert(number);
        }

        // Act
        avlTree.Delete(30);

        // Assert
        var result = new List<int>();
        avlTree.InOrderTraversal(value => result.Add(value));

        Assert.DoesNotContain(30, result);
        Assert.Equal(new int[] { 10, 20, 40, 50 }, result);
    }

    [Fact]
    public void InOrderTraversal_ShouldTraverseTreeInOrder()
    {
        // Arrange
        var avlTree = new AVLTree<int>();
        var numbers = new int[] { 10, 5, 15, 2, 7, 12, 20 };

        foreach (var number in numbers)
        {
            avlTree.Insert(number);
        }

        // Act
        var result = new List<int>();
        avlTree.InOrderTraversal(value => result.Add(value));

        // Assert
        Assert.Equal(new int[] { 2, 5, 7, 10, 12, 15, 20 }, result);
    }
}