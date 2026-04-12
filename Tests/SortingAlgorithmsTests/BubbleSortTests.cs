using SortingAlgorithms;

namespace SortingAlgorithmsTests;

public class BubbleSortTests
{
    [Fact]
    public void Sort_WhenArrayIsUnsorted_SortsInAscendingOrder()
    {
        int[] values = [5, 1, 4, 2, 8];

        BubbleSort.Sort(values);

        Assert.Equal([1, 2, 4, 5, 8], values);
    }

    [Fact]
    public void Sort_WhenArrayContainsDuplicates_KeepsAllValuesInOrder()
    {
        int[] values = [3, 1, 2, 3, 2];

        BubbleSort.Sort(values);

        Assert.Equal([1, 2, 2, 3, 3], values);
    }

    [Fact]
    public void Sort_WhenArrayHasSingleElement_LeavesArrayUnchanged()
    {
        int[] values = [42];

        BubbleSort.Sort(values);

        Assert.Equal([42], values);
    }
}
