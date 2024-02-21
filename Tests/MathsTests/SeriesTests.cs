using Maths;

namespace MathsTests;

public class SeriesTests
{
    private Series<char> _series { get; set; }

    public SeriesTests()
    {
        // Arrange : ifadelerini oluşturunuz.
        _series = new Series<char>("hello".ToCharArray());
    }

    [Fact]
    public void Check_First_Item_In_Series()
    {
        // Arrange

        // Act
        if (_series.Count == 0)
            Assert.Throws<InvalidOperationException>(() => _series.FirstItem);

        var result = _series.FirstItem;

        // Asserts
        Assert.Equal('h', result);
    }

    [Fact]
    public void Check_Last_Item_In_Series()
    {
        // Arrange

        // Act
        if (_series.Count == 0)
            Assert.Throws<InvalidOperationException>(() => _series.LastItem);

        var result = _series.LastItem;

        // Asserts
        Assert.Equal('o', result);
    }

    [Fact]
    public void Check_Count()
    {
        // Arrange

        // Act
        var result = _series.Count;

        // Asserts
        Assert.Equal(5, result);
    }

    [Fact]
    public void Check_ToString()
    {
        // Arrange

        // Act
        var result = _series.ToString();

        // Asserts
        Assert.Equal("hello", result);
    }

    [Fact]
    public void Chekc_Equals()
    {
        // Arrange 
        var seriesA = new Series<int>(new int[] { 1, 2, 3 });
        var seriesB = new Series<int>(new int[] { 1, 2, 3 });

        // Act
        var result = seriesA.MyEquals(seriesB);

        // Assert
        Assert.True(result);
    }
}