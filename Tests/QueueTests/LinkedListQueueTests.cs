using DataStructures.Queue;

namespace Tests.QueueTests;

public class LinkedListQueueTests
{
    [Fact]
    public void NewQueue_ShouldBeEmpty()
    {
        // Arrange
        LinkedListQueue<int> queue = new LinkedListQueue<int>();

        // Act & Assert
        Assert.Equal(0, queue.Count);
        Assert.Throws<Exception>(() => queue.Dequeue());
        Assert.Equal(default(int), queue.Peek());
    }

    [Fact]
    public void Enqueue_ShouldIncreaseCount()
    {
        // Arrange
        LinkedListQueue<int> queue = new LinkedListQueue<int>();

        // Act
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        // Assert
        Assert.Equal(3, queue.Count);
        Assert.Equal(10, queue.Peek());
    }

    [Fact]
    public void Dequeue_ShouldRemoveAndReturnElement()
    {
        // Arrange
        LinkedListQueue<int> queue = new LinkedListQueue<int>(new int[] { 1, 2, 3, 4, 5, 6 });


        // Act
        var dequeuedItem = queue.Dequeue();

        // Assert
        Assert.Equal(5, queue.Count);
        Assert.Equal(1, dequeuedItem);
        Assert.Equal(2, queue.Peek());
    }

    [Fact]
    public void Dequeue_OnEmptyQueue_ShouldThrowException()
    {
        // Arrange
        LinkedListQueue<int> queue = new LinkedListQueue<int>();


        // Act & Assert
        Assert.Throws<Exception>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_ShouldReturnFirstElementWithoutRemoving()
    {
        // Arrange
        LinkedListQueue<char> queue = new LinkedListQueue<char>(new char[] { 'a', 'b', 'c', 'd' });


        // Act
        var peekedItem = queue.Peek();

        // Assert
        Assert.Equal(4, queue.Count);
        Assert.Equal('a', peekedItem);
    }

    [Fact]
    public void Peek_OnEmptyQueue_ShouldReturnDefault()
    {
        // Arrange
        LinkedListQueue<int> queue = new LinkedListQueue<int>();

        // Act & Assert
        Assert.Equal(default(int), queue.Peek());
    }

    [Fact]
    public void Enqueue_Items_From_Constructor()
    {
        // Arrange
        LinkedListQueue<int> queue = new LinkedListQueue<int>(new int[] { 10, 20, 30 });

        // Act & Assert
        Assert.Equal(10, queue.Peek());
        Assert.Equal(10, queue.Peek());
        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Peek());
    }
}
