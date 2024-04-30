using DataStructures.Trees.BinaryTree;

namespace Test.TreesTests;


public class NodeTests
{
    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(30)]
    public void Node_ConstructWithValue_ShouldSetValue(int value)
    {
        // Arrange & Act
        var node = new Node<int>(value);

        // Assert
        Assert.Equal(value, node.Value);
    }

    [Theory]
    [InlineData(10, 20)]
    [InlineData(20, 30)]
    [InlineData(30, 40)]
    public void Node_SetValue_Should_Update_Value(int initialValue, int newValue)
    {
        // Arrange
        var node = new Node<int>(initialValue);

        // Act
        node.Value = newValue;

        // Assert
        Assert.Equal(newValue, node.Value);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    public void Node_IsLeaf_WithNoChildren_ShouldReturnTrue(int value)
    {
        // Arrange
        var leafNode = new Node<int>(value);

        // Act & Assert
        Assert.True(leafNode.IsLeaf);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(30)]
    public void Node_IsLeaf_WithChildren_ShouldReturnFalse(int value)
    {
        // Arrange
        var parentNode = new Node<int>(value);
        parentNode.Left = new Node<int>(value - 5); // Assuming a simple binary tree structure

        // Act & Assert
        Assert.False(parentNode.IsLeaf);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    public void Node_ToString_ShouldReturnValueAsString(int value)
    {
        // Arrange
        var node = new Node<int>(value);

        // Act
        var stringValue = node.ToString();

        // Assert
        Assert.Equal(value.ToString(), stringValue);
    }
}