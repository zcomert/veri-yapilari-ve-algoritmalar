namespace Tests.StackTests;

using System;
using DataStructures.Stack;
using Xunit;

public class StackTests
{
    [Fact]
    public void Push_AddsItemToStack()
    {
        var stack = new Stack<int>("Array");

        stack.Push(15);

        Assert.True(stack.Peek().Equals(15));
    }

    [Fact]
    public void Pop_RemovesAndReturnsTopItemFromStack()
    {
        var stack = new Stack<int>("Linked");

        stack.Push(15);

        Assert.True(stack.Pop().Equals(15));
    }

    [Fact]
    public void Peek_ReturnsTopItemFromStackWithoutRemovingIt()
    {
        var stack = new Stack<int>("Array");

        stack.Push(15);
        stack.Push(26);
        stack.Push(39);
        stack.Push(10);

        Assert.True(stack.Peek().Equals(10));
    }

    [Fact]
    public void Pop_ThrowsException_WhenStackIsEmpty()
    {
        var stack = new Stack<int>("Array");
        Assert.Throws<Exception>(() => stack.Pop());
    }
}

