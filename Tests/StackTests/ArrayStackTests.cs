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

        // Assert

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


        // Assert

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


        // Assert

    }

    [Fact]
    public void Pop_ThrowsException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new ArrayStack<int>();

        // Act & Assert

    }
}
