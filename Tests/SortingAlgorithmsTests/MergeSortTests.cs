using SortingAlgorithms;

namespace SortingAlgorithmsTests;

public class MergeSortTests
{
    [Fact]
    public void Sort_WhenArrayIsUnsorted_SortsInAscendingOrder()
    {
        int[] values = [38, 27, 43, 3, 9, 82, 10];

        MergeSort.Sort(values);

        Assert.Equal([3, 9, 10, 27, 38, 43, 82], values);
    }

    [Fact]
    public void Sort_WhenArrayContainsDuplicateValues_SortsCorrectly()
    {
        int[] values = [4, 1, 3, 4, 2, 1];

        MergeSort.Sort(values);

        Assert.Equal([1, 1, 2, 3, 4, 4], values);
    }

    [Fact]
    public void Sort_WhenArrayIsEmpty_DoesNotThrow()
    {
        int[] values = [];

        MergeSort.Sort(values);

        Assert.Empty(values);
    }
}
