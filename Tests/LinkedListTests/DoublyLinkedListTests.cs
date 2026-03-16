using LinkedList.DoublyLinkedList;
using Xunit;

namespace LinkedListTests;

public class DoublyLinkedListTests
{
    [Fact]
    public void Node_Constructor_With_Item_Test()
    {
        // Arrange
        int item = 10;

        // Act
        var node = new DoublyLinkedListNode<int>(item);

        // Assert
        Assert.Equal(item, node.Item);
        Assert.Null(node.Next);
        Assert.Null(node.Prev);
    }

    [Fact]
    public void Node_Default_Constructor_Test()
    {
        // Act
        var node = new DoublyLinkedListNode<int>();

        // Assert
        Assert.Equal(0, node.Item);
        Assert.Null(node.Next);
        Assert.Null(node.Prev);
    }

    [Fact]
    public void Node_ToString_Test()
    {
        // Arrange
        var node = new DoublyLinkedListNode<int>(10);
        var nullNode = new DoublyLinkedListNode<string>(null);

        // Assert
        Assert.Equal("10", node.ToString());
        Assert.Equal("null", nullNode.ToString());
    }

    [Fact]
    public void AddFirst_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();

        // Act
        list.AddFirst(1);
        list.AddFirst(2);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(2, list.Head!.Item);
        Assert.Equal(1, list.Tail!.Item);
        Assert.Equal(list.Head.Next, list.Tail);
        Assert.Equal(list.Tail.Prev, list.Head);
    }

    [Fact]
    public void AddLast_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();

        // Act
        list.AddLast(1);
        list.AddLast(2);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(1, list.Head!.Item);
        Assert.Equal(2, list.Tail!.Item);
        Assert.Equal(list.Head.Next, list.Tail);
        Assert.Equal(list.Tail.Prev, list.Head);
    }

    [Fact]
    public void AddAfter_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(3);
        var node = list.Head!;

        // Act
        list.AddAfter(node, 2);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal(1, list.Head!.Item);
        Assert.Equal(2, list.Head.Next!.Item);
        Assert.Equal(3, list.Tail!.Item);
        Assert.Equal(list.Head.Next, list.Tail.Prev);
    }

    [Fact]
    public void AddBefore_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(3);
        var node = list.Tail!;

        // Act
        list.AddBefore(node, 2);

        // Assert
        Assert.Equal(3, list.Count);
        Assert.Equal(1, list.Head!.Item);
        Assert.Equal(2, list.Head.Next!.Item);
        Assert.Equal(3, list.Tail!.Item);
        Assert.Equal(list.Head.Next, list.Tail.Prev);
    }

    [Fact]
    public void RemoveFirst_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);

        // Act
        var item = list.RemoveFirst();

        // Assert
        Assert.Equal(1, item);
        Assert.Equal(1, list.Count);
        Assert.Equal(2, list.Head!.Item);
        Assert.Null(list.Head.Prev);
    }

    [Fact]
    public void RemoveLast_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);

        // Act
        var item = list.RemoveLast();

        // Assert
        Assert.Equal(2, item);
        Assert.Equal(1, list.Count);
        Assert.Equal(1, list.Tail!.Item);
        Assert.Null(list.Tail.Next);
    }

    [Fact]
    public void Remove_Specific_Node_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        var nodeToRemove = list.Head!.Next!;

        // Act
        var item = list.Remove(nodeToRemove);

        // Assert
        Assert.Equal(2, item);
        Assert.Equal(2, list.Count);
        Assert.Equal(1, list.Head.Item);
        Assert.Equal(3, list.Tail.Item);
        Assert.Equal(list.Head.Next, list.Tail);
        Assert.Equal(list.Tail.Prev, list.Head);
    }

    [Fact]
    public void Enumerator_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        // Act
        var result = new System.Collections.Generic.List<int>();
        foreach (var item in list)
        {
            result.Add(item);
        }

        // Assert
        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    [Theory]
    [InlineData(new int[] { 10, 20, 30 }, 3, 10, 30)]
    [InlineData(new int[] { 5 }, 1, 5, 5)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5, 1, 5)]
    public void AddLast_Parameterized_Test(int[] items, int expectedCount, int expectedHead, int expectedTail)
    {
        // Arrange
        var list = new DoublyLinkedList<int>();

        // Act
        foreach (var item in items)
        {
            list.AddLast(item);
        }

        // Assert
        Assert.Equal(expectedCount, list.Count);
        Assert.Equal(expectedHead, list.Head!.Item);
        Assert.Equal(expectedTail, list.Tail!.Item);
    }

    [Fact]
    public void RemoveFirst_Empty_List_Throws_Exception_Test()
    {
        var list = new DoublyLinkedList<int>();
        Assert.Throws<Exception>(() => list.RemoveFirst());
    }

    [Fact]
    public void RemoveLast_Empty_List_Throws_Exception_Test()
    {
        var list = new DoublyLinkedList<int>();
        Assert.Throws<Exception>(() => list.RemoveLast());
    }

    [Fact]
    public void AddAfter_Null_Node_Throws_ArgumentNullException_Test()
    {
        var list = new DoublyLinkedList<int>();
        Assert.Throws<ArgumentNullException>(() => list.AddAfter(null!, 10));
    }

    [Fact]
    public void AddBefore_Null_Node_Throws_ArgumentNullException_Test()
    {
        var list = new DoublyLinkedList<int>();
        Assert.Throws<ArgumentNullException>(() => list.AddBefore(null!, 10));
    }

    [Fact]
    public void Remove_Null_Node_Throws_ArgumentNullException_Test()
    {
        var list = new DoublyLinkedList<int>();
        Assert.Throws<ArgumentNullException>(() => list.Remove(null!));
    }

    [Fact]
    public void Remove_Only_Node_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.AddFirst(10);
        var node = list.Head!;

        // Act
        var item = list.Remove(node);

        // Assert
        Assert.Equal(10, item);
        Assert.Equal(0, list.Count);
        Assert.Null(list.Head);
        Assert.Null(list.Tail);
    }

    [Fact]
    public void AddAfter_Tail_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        var tail = list.Tail!;

        // Act
        list.AddAfter(tail, 2);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(2, list.Tail!.Item);
        Assert.Equal(list.Head, list.Tail.Prev);
    }

    [Fact]
    public void AddBefore_Head_Test()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        var head = list.Head!;

        // Act
        list.AddBefore(head, 0);

        // Assert
        Assert.Equal(2, list.Count);
        Assert.Equal(0, list.Head!.Item);
        Assert.Equal(list.Tail, list.Head.Next);
    }
}
