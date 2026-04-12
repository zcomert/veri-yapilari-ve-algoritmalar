using Utilities;

namespace SortingAlgorithms;

public class SelectionSort
{
    public static void Sort<T>(T[] array)
        where T : IComparable
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            T minValue = array[i];
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j].CompareTo(minValue) < 0)
                {
                    minIndex = j;
                    minValue = array[minIndex];
                }
            }
            Sorting.Swap<T>(array, i, minIndex);
        }
    }

    public static void Sort<T>(T[] array,
        SortDirection sortDirection = SortDirection.Asceding)
        where T : IComparable
    {
        var comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (comparer.Compare(array[j], array[i]) >= 0)
                    continue;
                Sorting.Swap(array, i, j);
            }
        }
    }


}