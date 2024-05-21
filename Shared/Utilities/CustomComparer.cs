namespace Utilities;
public class CustomComparer<T> : IComparer<T>
{
    private readonly bool isMax;
    private readonly IComparer<T> _comparer;

    public CustomComparer(SortDirection sortDirection,
        IComparer<T> comparer)
    {
        isMax = sortDirection == SortDirection.Descending;
        _comparer = comparer;
    }

    public int Compare(T? x, T? y)
    {
        return !isMax ? compare(x, y) : compare(y, x);
    }

    private int compare(T x, T y) => _comparer.Compare(x, y);
}