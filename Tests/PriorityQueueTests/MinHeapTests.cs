using DataStructures.PriorityQueue;

namespace Tests.PriorityQueue;

public class MinHeapTests
{
    [Fact]
    public void MinHeap_Should_Be_Empty_On_Initialization()
    {
        // Arrange
        var heap = new MinHeap<int>();

        // Act & Assert
        Assert.True(heap.IsEmpty());
    }

    [Fact]
    public void Add_Should_Add_Element_And_HeapifyUp()
    {
        // Arrange
        var heap = new MinHeap<int>();
        var values = new List<int> { 5, 3, 8, 1, 9 };

        // Act
        foreach (var value in values)
        {
            heap.Add(value);
        }

        // Assert
        Assert.Equal(heap.Count, 5);
        Assert.Equal(heap.Peek(), 1);
        Assert.Equal(heap.Array.GetValue(2), 8);
    }

    [Fact]
    public void Peek_Should_Return_Minimum_Element()
    {
        // Arrange
        var heap = new MinHeap<int>(new List<int> { 5, 3, 8, 1, 9 });

        // Act
        var min = heap.Peek();

        // Assert
        Assert.Equal(1, min);
    }

    [Fact]
    public void DeleteMinMax_Should_Remove_Minimum_Element_And_HeapifyDown()
    {
        // Arrange
        var heap = new MinHeap<int>(new List<int> { 5, 3, 8, 1, 9 });

        // Act
        var min = heap.DeleteMinMax();

        // Assert
        Assert.Equal(1, min);
        Assert.Equal(heap.Peek(), 3);
    }

    [Fact]
    public void Add_Should_Heapify_Correctly()
    {
        // Arrange
        var heap = new MinHeap<int>();
        var values = new List<int> { 3, 1, 6, 5, 2, 4 };

        // Act
        foreach (var value in values)
        {
            heap.Add(value);
        }

        // Assert
        Assert.Equal(heap.Peek(), 1);
    }

    [Fact]
    public void DeleteMinMax_Should_Throw_Exception_When_Heap_Is_Empty()
    {
        // Arrange
        var heap = new MinHeap<int>();

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => heap.DeleteMinMax());
    }

    [Fact]
    public void Add_Should_Work_With_Strings()
    {
        // Arrange
        var heap = new MinHeap<string>();
        var values = new List<string> { "apple", "ab", "banana", "cherry" };

        // Act
        foreach (var value in values)
        {
            heap.Add(value);
        }

        // Assert
        Assert.Equal(heap.Peek(), "ab");
    }

    [Fact]
    public void MinHeap_Should_Be_Created_From_Collection()
    {
        // Arrange
        var values = new List<int> { 5, 3, 8, 1, 9 };
        var heap = new MinHeap<int>(values);

        // Act & Assert
        Assert.Equal(5, heap.Count);
        Assert.Equal(1, heap.Peek());
    }

    [Fact]
    public void MinHeap_Enumeration_Should_Return_All_Elements()
    {
        // Arrange
        var values = new List<int> { 5, 3, 8, 1, 9 };
        var heap = new MinHeap<int>(values);

        // Act
        var enumerator = heap.GetEnumerator();
        var elements = new List<int>();
        while (enumerator.MoveNext())
        {
            elements.Add((int)enumerator.Current);
        }

        // Assert
        Assert.Equal(elements[0], 1);
    }

    [Fact]
    public void MinHeap_With_Single_Element_Should_Work()
    {
        // Arrange
        var heap = new MinHeap<int>();
        heap.Add(10);

        // Act
        var min = heap.Peek();

        // Assert
        Assert.True(min == 10);
    }

    [Fact]
    public void MinHeap_With_Duplicate_Elements_Should_Work()
    {
        // Arrange
        var heap = new MinHeap<int>();
        var values = new List<int> { 10, 10, 10 };

        // Act
        foreach (var value in values)
        {
            heap.Add(value);
        }

        // Assert
        Assert.Equal(heap.Peek(), 10);
    }
}
