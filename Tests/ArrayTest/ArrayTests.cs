using DataStructures.Array;

namespace Tests.ArrayTests;

public class ArrayTests
{
    private Array<float> _array;

    public ArrayTests()
    {
        // Arrange
        _array = new Array<float>();
        _array.Add(5.0f);
        _array.Add((float)15.0);
        _array.Add((float)35.0);
        _array.Add((float)45.0);
    }

    [Fact]
    public void Add_AddsElement_CountIncreases()
    {
        // Act
        _array.Add(62.0f);

        // Assert
        Assert.Equal(5, _array.Count);
    }

    [Fact]
    public void RemoveAt_RemovesElement_CountDecreases()
    {
        // Act
        _array.RemoveAt(0);

        // Assert
        Assert.Equal(3, _array.Count);
    }

    [Fact]
    public void RemoveAt_RemovesCorrectElement()
    {
        // Act
        var item = _array.RemoveAt(1);

        // Assert
        Assert.Equal(15.0f, item);
    }

    [Fact]
    public void RemoveAt_ThrowsIndexOutOfRangeException_WhenIndexOutOfRange()
    {
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => _array.RemoveAt(5));
    }

    [Fact]
    public void Swap_SwapsElements()
    {
        // Act
        _array.Add(7.25f);
        _array.Swap(1, 4);

        // Assert
        Assert.Equal(7.25f, _array.GetItem(1));
        Assert.Equal(15.0f, _array.GetItem(4));
    }

    [Fact]
    public void ShrinkArray_DoesNotShrinkCapacity_WhenCountIsGreaterThanQuarterOfCapacity()
    {
        // Act
        _array.Add(8.0f);
        _array.RemoveAt(0);
        _array.RemoveAt(0);


        // Assert
        Assert.Equal(8, _array.Capacity);
    }

    [Fact]
    public void ShrinkArray_ShrinksCapacity_WhenCountIsLessThanQuarterOfCapacity()
    {
        // Act
        _array.Add(8.0f);
        _array.RemoveAt(0);
        _array.RemoveAt(0);
        _array.RemoveAt(0);

        // Assert
        Assert.Equal(4, _array.Capacity);
    }

    [Fact]
    public void Swap_Without_Extra_Variable()
    {
        // Arrange
        int a = 60;
        int b = 10;

        // Act
        a = a + b; // a=70 b=10
        b = a - b; // a=70 b=60
        a = a - b; // a=10 b=60

        // Assert
        Assert.Equal(10, a);
        Assert.Equal(60, b);
    }

}