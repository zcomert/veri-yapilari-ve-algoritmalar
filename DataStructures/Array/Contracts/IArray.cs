namespace DataStructures.Array;

public interface IArray<T>
{
    int Length { get; }
    T GetItem(int index);
    void SetItem(int index, T value);
}