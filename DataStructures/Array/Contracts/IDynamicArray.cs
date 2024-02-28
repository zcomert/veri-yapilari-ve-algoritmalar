namespace DataStructures.Array.Contracts;

public interface IDynamicArray<T>
{
    int Count { get; }
    int Capacity { get; }
    T RemoveAt(int position);
    void Swap(int position1, int position2);
    void DoubleArray();
}