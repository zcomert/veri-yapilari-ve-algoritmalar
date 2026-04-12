using SortingAlgorithms;
using Utilities;

namespace SortingAlgorithmsTests;

public class InsertionSortTests
{
    [Fact]
    public void Sort_WithoutDirection_SortsInAscendingOrder()
    {
        int[] values = [5, 2, 4, 6, 1, 3];

        int[] result = InsertionSort.Sort(values);

        Assert.Same(values, result);
        Assert.Equal([1, 2, 3, 4, 5, 6], values);
    }

    [Fact]
    public void Sort_WithDescendingDirection_SortsInDescendingOrder()
    {
        int[] values = [5, 2, 4, 6, 1, 3];

        InsertionSort.Sort(values, SortDirection.Descending);

        Assert.Equal([6, 5, 4, 3, 2, 1], values);
    }

    [Fact]
    public void Sort_WhenArrayIsEmpty_ReturnsEmptyArray()
    {
        int[] values = [];

        int[] result = InsertionSort.Sort(values);

        Assert.Same(values, result);
        Assert.Empty(result);
    }
}
