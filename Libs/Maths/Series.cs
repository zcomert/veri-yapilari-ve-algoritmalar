using System.Text;

namespace Maths;

public class Series<T>
{
    private T[] _series;

    // Serinin ilk elemanı temsil etmelidir.
    public T FirstItem
    {
        get
        {
            if (Count == 0)
                throw new InvalidOperationException("Array is empty!");
            return _series[0];
        }
        set
        {
            _series[0] = value;
        }
    }

    // Serinin son elemanını temsil etmelidir.
    public T LastItem
    {
        get
        {
            if (Count == 0)
                throw new InvalidOperationException("Array is empty!");
            return _series[Count - 1];
        }
        set
        {
            _series[Count - 1] = value;
        }
    }

    // Serideki eleman sayısını temsil etmelidir.
    public int Count => _series.Length;

    public Series(T[] inputs)
    {
        _series = inputs;
    }

    public override string ToString()
    {
        StringBuilder s = new StringBuilder();
        foreach (var item in _series)
        {
            s.Append(item);
        }
        return s.ToString();
    }

    public bool MyEquals(Series<int> seriesB)
    {
        for (int i = 0; i < Count; i++)
        {
            if (!_series[i].Equals(seriesB._series[i]))
                return false;
        }
        return true;
    }
}