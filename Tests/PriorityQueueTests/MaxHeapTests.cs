using DataStructures.PriorityQueue;

namespace Tests.PriorityQueue;
public class MaxHeapTests
{
    [Fact]
    public void MaxHeap_Should_Be_Empty_On_Initialization()
    {
        // Arrange
        var heap = new MaxHeap<int>();

        // Act & Assert
        Assert.True(heap.IsEmpty());
    }

    [Fact]
    public void Add_Should_Add_Element_And_HeapifyUp()
    {
        // Arrange
        var heap = new MaxHeap<int>();
        var values = new List<int> { 5, 3, 8, 1, 9 };

        // Act
        foreach (var value in values)
        {
            heap.Add(value);
        }

        // Assert

    }

    [Fact]
    public void Peek_Should_Return_Maximum_Element()
    {
        // Arrange
        var heap = new MaxHeap<int>(new List<int> { 5, 3, 8, 1, 9 });

        // Act
        var max = heap.Peek();

        // Assert

    }

    [Fact]
    public void DeleteMinMax_Should_Remove_Maximum_Element_And_HeapifyDown()
    {
        // Arrange
        var heap = new MaxHeap<int>(new List<int> { 5, 3, 8, 1, 9 });

        // Act
        var max = heap.DeleteMinMax();

        // Assert

    }

    [Fact]
    public void Add_Should_Heapify_Correctly()
    {
        // Arrange
        var heap = new MaxHeap<int>();
        var values = new List<int> { 3, 1, 6, 5, 2, 4 };

        // Act
        foreach (var value in values)
        {
            heap.Add(value);
        }

        // Assert

    }

    [Fact]
    public void DeleteMinMax_Should_Throw_Exception_When_Heap_Is_Empty()
    {
        // Arrange
        var heap = new MaxHeap<int>();

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => heap.DeleteMinMax());
    }

    [Fact]
    public void Add_Should_Work_With_Strings()
    {
        // Arrange
        var heap = new MaxHeap<string>();
        var values = new List<string> { "apple", "banana", "cherry" };

        // Act
        foreach (var value in values)
        {
            heap.Add(value);
        }

        // Assert

    }

    [Fact]
    public void MaxHeap_Should_Be_Created_From_Collection()
    {
        // Arrange
        var values = new List<int> { 5, 3, 8, 1, 9 };
        var heap = new MaxHeap<int>(values);

        // Act & Assert

    }

    [Fact]
    public void MaxHeap_Enumeration_Should_Return_All_Elements()
    {
        // Arrange
        var values = new List<int> { 5, 3, 8, 1, 9 };
        var heap = new MaxHeap<int>(values);

        // Act
        var enumerator = heap.GetEnumerator();
        var elements = new List<int>();
        while (enumerator.MoveNext())
        {
            elements.Add((int)enumerator.Current);
        }

        // Assert

    }

    [Fact]
    public void MaxHeap_With_Single_Element_Should_Work()
    {
        // Arrange
        var heap = new MaxHeap<int>();
        heap.Add(10);

        // Act
        var max = heap.Peek();

        // Assert

    }

    [Fact]
    public void MaxHeap_With_Duplicate_Elements_Should_Work()
    {
        // Arrange
        var heap = new MaxHeap<int>();
        var values = new List<int> { 10, 10, 10 };

        // Act
        foreach (var value in values)
        {
            heap.Add(value);
        }

        // Assert

    }
}
