using DataStructures.Queue;

namespace Tests.QueueTests;

public class ArrayQueueTests
{
    [Fact]
    public void NewQueue_ShouldBeEmpty()
    {
        // Arrange

        // Act & Assert
        // Assert.Equal(0, queue.Count);
        // Assert.Throws<Exception>(() => queue.Dequeue());
        // Assert.Equal(default(int), queue.Peek());
    }

    [Fact]
    public void Enqueue_ShouldIncreaseCount()
    {
        // Arrange


        // Act


        // Assert
        // Assert.Equal(2, queue.Count);
        // Assert.Equal(5, queue.Peek());
    }

    [Fact]
    public void Dequeue_ShouldRemoveAndReturnElement()
    {

        // Assert
        // Assert.Equal(1, queue.Count);
        // Assert.Equal(5, dequeuedItem);
        // Assert.Equal(10, queue.Peek());
    }

    [Fact]
    public void Dequeue_OnEmptyQueue_ShouldThrowException()
    {
        // Arrange


        // Act & Assert
        // Assert.Throws<Exception>(() => queue.Dequeue());
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
        // Assert.Equal(2, queue.Count);
        // Assert.Equal(5, peekedItem);
    }

    [Fact]
    public void Peek_OnEmptyQueue_ShouldReturnDefault()
    {
        // Arrange
        var queue = new ArrayQueue<int>();

        // Act & Assert
        // Assert.Equal(default(int), queue.Peek());
    }

    [Fact]
    public void ConstructWithCollection_ShouldEnqueueAllItems()
    {
        // Arrange

        // Act

        // Assert
        // Assert.Equal(3, queue.Count);
        // Assert.Equal(1, queue.Peek());
    }
}