using Stack;

namespace StackTests;

public class ArrayStackTests
{
    [Fact]
    public void Push_AddsItemToStack()
    {
        // Arrange
        var stack = new ArrayStack<int>();

        // Act
        stack.Push(10);

        // Assert
        Assert.Equal(1, stack.Count);
        Assert.False(stack.IsEmpty);
        Assert.Equal(10, stack.Peek());
    }

    [Fact]
    public void Pop_RemovesAndReturnsTopItem()
    {
        // Arrange
        var stack = new ArrayStack<int>();
        stack.Push(10);
        stack.Push(20);

        // Act
        var item = stack.Pop();

        // Assert
        Assert.Equal(20, item);
        Assert.Equal(1, stack.Count);
        Assert.Equal(10, stack.Peek());
    }

    [Fact]
    public void Peek_ReturnsTopItemWithoutRemoving()
    {
        // Arrange
        var stack = new ArrayStack<int>();
        stack.Push(10);

        // Act
        var item = stack.Peek();

        // Assert
        Assert.Equal(10, item);
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Clear_RemovesAllItems()
    {
        // Arrange
        var stack = new ArrayStack<int>();
        stack.Push(10);
        stack.Push(20);

        // Act
        stack.Clear();

        // Assert
        Assert.Equal(0, stack.Count);
        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void Pop_EmptyStack_ThrowsInvalidOperationException()
    {
        // Arrange
        var stack = new ArrayStack<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_EmptyStack_ThrowsInvalidOperationException()
    {
        // Arrange
        var stack = new ArrayStack<int>();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Push_TriggersResize_WhenFull()
    {
        // Arrange
        var stack = new ArrayStack<int>(2);
        stack.Push(1);
        stack.Push(2);

        // Act
        stack.Push(3); // Should trigger resize

        // Assert
        Assert.Equal(3, stack.Count);
        Assert.Equal(3, stack.Peek());
    }
}
