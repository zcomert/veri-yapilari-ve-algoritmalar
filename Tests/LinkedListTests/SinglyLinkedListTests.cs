using DataStructures.LinkedList.Singly;

namespace LinkedListTests;

public class SinglyLinkedListTests
{
    // GLobal
    SinglyLinkedList<int> linkedList;

    public SinglyLinkedListTests()
    {
        this.linkedList = new SinglyLinkedList<int>(new int[] { 1, 2, 3 });
    }

    [Fact]
    public void NewLinkedListIsEmpty()
    {
        // Assert
        Assert.True(linkedList.IsEmpty);
    }

    [Fact]
    public void LinkedListWithCollectionIsPopulated()
    {
        // Arrange
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };

        // Act
        linkedList = new SinglyLinkedList<int>(arr);

        // Assert
        Assert.False(linkedList.IsEmpty);
        Assert.Equal(6, linkedList.Head.Value);
    }

    [Fact]
    public void AddFirstAddsElementToLinkedList()
    {
        linkedList.AddFirst(6);

        Assert.Equal(6, linkedList.Head.Value);
        Assert.Equal(3, linkedList.Head.Next.Value);
        Assert.Equal(4, linkedList.Count);
    }

    [Fact]
    public void AddLastAddsElementToEndOfLinkedList()
    {
        linkedList.AddLast(6);

        Assert.Equal(6, linkedList.Head.Next.Next.Next.Value);
        Assert.Equal(3, linkedList.Head.Value);
        Assert.Equal(4, linkedList.Count);
    }

    [Fact]
    public void AddAfterAddsElementAfterGivenNode()
    {
        // Arrange
        var item = linkedList.Head;

        // Act
        linkedList.AddAfter(new SinglyLinkedListNode<int>(2), 8);
        // Assert

        Assert.Equal(3, item.Value);
        Assert.Equal(2, item.Next.Value);
        Assert.Equal(8, item.Next.Next.Value);
        Assert.Equal(1, item.Next.Next.Next.Value);

    }

    [Fact]
    public void AddAfterThrowsExceptionIfNodeNotFound()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void AddBeforeAddsElementBeforeGivenNode()
    {
        // Arrange
        var item = linkedList.Head;

        // Act
        linkedList.AddBefore(linkedList.Head.Next, 8);
        // Assert

        Assert.Equal(3, item.Value);
        Assert.Equal(8, item.Next.Value);
        Assert.Equal(2, item.Next.Next.Value);
        Assert.Equal(1, item.Next.Next.Next.Value);
    }

    [Fact]
    public void AddBeforeThrowsExceptionIfNodeNotFound()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void RemoveFirstRemovesFirstElement()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void RemoveFirstThrowsExceptionIfListIsEmpty()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void RemoveLastRemovesLastElement()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void RemoveLastThrowsExceptionIfListIsEmpty()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void RemoveRemovesGivenNode()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void RemoveThrowsExceptionIfNodeNotFound()
    {
        throw new NotImplementedException();
    }
}
