using DataStructures.Array;

namespace ArrayTests;

public class StaticArrayTests
{
    private StaticArray<char> _array;
    public StaticArrayTests()
    {
        // Arrange
        _array = new StaticArray<char>();
        _array.SetItem(0, 'a');
        _array.SetItem(1, 'b');
        _array.SetItem(2, 'c');
        _array.SetItem(3, 'd');
    }

    [Fact]
    public void DefaultConstructor_InitializesArrayWithCorrectLength()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void Get_Item_Test()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void SetItem_ChangesValue()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void SetItem_ThrowsIndexOutOfRangeException_ForInvalidIndex()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void GetItem_ThrowsIndexOutOfRangeException_ForInvalidIndex()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void Length_Test()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void Constructor_with_IEnumerable_Parameter_Test()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void ConstructorWithCollection_InitializesArrayWithCorrectLengthAndValues()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void GetEnumerator_ReturnsAllItemsInArray()
    {
        throw new NotImplementedException();
    }
}