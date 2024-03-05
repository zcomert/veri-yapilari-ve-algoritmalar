namespace DataStructures.Array.Contracts;

public interface IDynamicArray<T>
{
    int Count { get; }
    int Capacity { get; }
    void Add(T value);
    T RemoveAt(int position);
    void Swap(int position1, int position2);
}