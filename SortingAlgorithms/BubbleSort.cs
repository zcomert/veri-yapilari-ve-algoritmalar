namespace SortingAlgorithms;

public class BubbleSort
{
    public static void Sort<T>(T[] arr)
        where T : IComparable<T>
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool IsSwapped = false;
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j].CompareTo(arr[j + 1]) >= 1)
                {
                    Sorting.Swap(arr, j, j + 1);
                    IsSwapped = true;
                }
            if (!IsSwapped)
                return;
        }
    }
}
