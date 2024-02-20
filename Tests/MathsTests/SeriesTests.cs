using Maths;

namespace MathsTests;

public class SeriesTests
{
    private Series<char> _series { get; set; }

    public SeriesTests()
    {
        // Arrange : ifadelerini oluşturunuz.
    }

    [Fact]
    public void Check_First_Item_In_Series()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void Check_Last_Item_In_Series()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void Check_Count()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void Check_ToString()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void Chekc_Equals()
    {
        // Arrange 
        var seriesA = new Series<int>(new int[] { 1, 2, 3 });
        var seriesB = new Series<int>(new int[] { 1, 2, 3 });

        // Act
        var result = seriesA.Equals(seriesB);

        // Assert
        Assert.True(result);
    }
}