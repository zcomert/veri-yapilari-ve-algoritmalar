using SortingAlgorithms;
using Utilities;

namespace SortingAlgorithmsTests;

public class SelectionSortTests
{
    [Fact]
    public void Sort_WithoutDirection_SortsInAscendingOrder()
    {
        int[] values = [64, 25, 12, 22, 11];

        SelectionSort.Sort(values);

        Assert.Equal([11, 12, 22, 25, 64], values);
    }

    [Fact]
    public void Sort_WithDescendingDirection_SortsInDescendingOrder()
    {
        int[] values = [64, 25, 12, 22, 11];

        SelectionSort.Sort(values, SortDirection.Descending);

        Assert.Equal([64, 25, 22, 12, 11], values);
    }

    [Fact]
    public void Sort_WhenArrayContainsDuplicates_SortsCorrectly()
    {
        int[] values = [3, 1, 2, 3, 1];

        SelectionSort.Sort(values);

        Assert.Equal([1, 1, 2, 3, 3], values);
    }
}
