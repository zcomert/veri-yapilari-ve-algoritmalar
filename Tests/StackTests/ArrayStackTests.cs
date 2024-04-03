namespace Tests.StackTests;

using DataStructures.Stack;
using Xunit;

public class ArrayStackTests
{
    [Fact]
    public void Push_AddsItemToStack()
    {
        // Arrange
        var stack = new ArrayStack<int>();

        // Act
        stack.Push(2);
        stack.Push(1);
        stack.Push(5);
        stack.Push(6);
        stack.Push(0);

        // Assert
        Assert.Equal(0, stack.Peek());

    }

    [Fact]
    public void Pop_RemovesAndReturnsTopItemFromStack()
    {
        // Arrange
        var stack = new ArrayStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        var item = stack.Pop();

        // Assert
        Assert.Equal(3, item);
    }

    [Fact]
    public void Peek_ReturnsTopItemFromStackWithoutRemovingIt()
    {
        // Arrange
        var stack = new ArrayStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        var item = stack.Peek();

        // Assert
        Assert.Equal(3, item);
    }

    [Fact]
    public void Pop_ThrowsException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new ArrayStack<int>();

        // Act & Assert
        Assert.Throws<Exception>(()=>stack.Pop());
    }
}
