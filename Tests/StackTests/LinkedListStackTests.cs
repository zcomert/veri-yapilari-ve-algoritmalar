namespace Tests.StackTests;

using DataStructures.Stack;
using Xunit;

public class LinkedListStackTests
{
    [Fact]
    public void Push_AddsItemToStack()
    {
        var stack = new LinkedListStack<String>();

        stack.Push("Hello");

        Assert.Equal("Hello", stack.Peek());
    }

    [Fact]
    public void Pop_RemovesAndReturnsTopItemFromStack()
    {
        var stack = new LinkedListStack<String>();

        stack.Push("Hello");

        Assert.Equal("Hello", stack.Pop());
    }

    [Fact]
    public void Peek_ReturnsTopItemFromStackWithoutRemovingIt()
    {
        var stack = new LinkedListStack<String>();

        stack.Push("Hello");

        Assert.Equal("Hello", stack.Peek());
    }

    [Fact]
    public void Pop_ThrowsException_WhenStackIsEmpty()
    {
        var stack = new LinkedListStack<String>();

        Assert.Throws<Exception>(() => stack.Pop());
    }
}

