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
            throw new NotImplementedException();
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    // Serinin son elemanını temsil etmelidir.
    public T LastItem
    {
        get
        {
            throw new NotImplementedException();
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    // Serideki eleman sayısını temsil etmelidir.
    public int Count => throw new NotImplementedException();

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

}