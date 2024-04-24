using DataStructures.Queue;

namespace Tests.QueueTests;

public class ArrayQueueTests
{
    [Fact]
    public void NewQueue_ShouldBeEmpty()
    {
        // Arrange
        ArrayQueue<int> queue = new ArrayQueue<int>();
        // Act & Assert
        Assert.Equal(0, queue.Count);
        Assert.Throws<Exception>(() => queue.Dequeue());
        Assert.Equal(default(int), queue.Peek());
    }

    [Fact]
    public void Enqueue_ShouldIncreaseCount()
    {
        // Arrange
        ArrayQueue<int> queue = new ArrayQueue<int>();

        // Act
        var count = queue.Count;
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        var count2 = queue.Count;
        // Assert
        Assert.Equal(0, count);
        Assert.Equal(3, count2);
        Assert.Equal(1, queue.Peek());
    }

    [Fact]
    public void Dequeue_ShouldRemoveAndReturnElement()
    {
        ArrayQueue<int> queue = new ArrayQueue<int>(new int[] { 1, 2, 3, 4, 5 });

        // Assert
        Assert.Equal(5, queue.Count);
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Peek());
    }

    [Fact]
    public void Dequeue_OnEmptyQueue_ShouldThrowException()
    {
        // Arrange
        ArrayQueue<int> queue = new ArrayQueue<int>();


        // Act & Assert
        Assert.Throws<Exception>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_ShouldReturnFirstElementWithoutRemoving()
    {
        // Arrange
        var queue = new ArrayQueue<int>();
        queue.Enqueue(5);
        queue.Enqueue(10);

        // Act
        var peekedItem = queue.Peek();

        // Assert
        Assert.Equal(2, queue.Count);
        Assert.Equal(5, peekedItem);
    }

    [Fact]
    public void Peek_OnEmptyQueue_ShouldReturnDefault()
    {
        // Arrange
        var queue = new ArrayQueue<int>();

        // Act & Assert
        Assert.Equal(default(int), queue.Peek());
    }

    [Fact]
    public void ConstructWithCollection_ShouldEnqueueAllItems()
    {
        // Arrange
        ArrayQueue<string> queue = new ArrayQueue<string>(new String[] { "Samsun", "Uşak", "Malatya" });

        // Act

        // Assert
        Assert.Equal(3, queue.Count);
        Assert.Equal("Samsun", queue.Peek());
    }
}