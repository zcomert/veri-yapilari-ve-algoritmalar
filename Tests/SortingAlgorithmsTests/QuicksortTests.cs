using SortingAlgorithms;

namespace SortingAlgorithmsTests;

public class QuicksortTests
{
    [Fact]
    public void Sort_WhenArrayIsUnsorted_SortsInAscendingOrder()
    {
        int[] values = [10, 7, 8, 9, 1, 5];

        Quicksort.Sort(values);

        Assert.Equal([1, 5, 7, 8, 9, 10], values);
    }

    [Fact]
    public void Sort_WhenPivotIsLargestValue_CompletesAndSortsArray()
    {
        int[] values = [3, 2, 1];

        Quicksort.Sort(values);

        Assert.Equal([1, 2, 3], values);
    }

    [Fact]
    public void Sort_WhenArrayContainsDuplicates_SortsCorrectly()
    {
        int[] values = [4, 2, 4, 1, 3, 2];

        Quicksort.Sort(values);

        Assert.Equal([1, 2, 2, 3, 4, 4], values);
    }
}
