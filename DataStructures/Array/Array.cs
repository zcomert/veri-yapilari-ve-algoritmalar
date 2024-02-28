namespace DataStructures.Array.Contracts;

public class Array<T> : StaticArray<T>, IDynamicArray<T>
{
    private int index = 0;

    public int Count => throw new NotImplementedException();

    public int Capacity => throw new NotImplementedException();

    public void DoubleArray()
    {
        throw new NotImplementedException();
    }

    public T RemoveAt(int position)
    {
        throw new NotImplementedException();
    }

    public void Swap(int position1, int position2)
    {
        throw new NotImplementedException();
    }
}