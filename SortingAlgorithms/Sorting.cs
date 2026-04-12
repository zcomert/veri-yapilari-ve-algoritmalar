namespace SortingAlgorithms;

public class Sorting
{
    public static void Swap<T>(T[] array, int first, int second)
    {
        var temp = array[first];
        array[first] = array[second];
        array[second] = temp;
    }
}
