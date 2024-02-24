using Maths;

namespace MathsTests;

public class NumberTests
{
    [Fact]
    public void Check_Multiply()
    {
        // Arrange
        var number = new Number(5);

        // Act
        var result = number.Multiply();

        // Assert
        Assert.Equal(10, result);
    }


    [Fact]
    /// Value değerinin kontrolü sağlayacak testi yazınız.
    public void Check_Multiply_With_Parameter()
    {
        // Arrange
        var number = new Number(10);

        // Act
        var result = number.Multiply(10);

        // Assert 
        Assert.True(true);
        Assert.False(false);
        Assert.Equal(result, 100);
    }

    [Fact]
    /// Value değerinin kontrolü sağlayacak testi yazınız.
    public void Check_Multiply_With_NoParameter()
    {
        // Arrange
        var number = new Number(10);

        // Act
        var result = number.Multiply();

        // Assert 
        Assert.Equal(result, 20);
    }


    [Fact]
    public void Check_Number_MinValue()
    {
        // Arrange
        var number = new Number(10);

        // Act
        var result = number.MinValue;

        // Assert 
        Assert.Equal(result, -2147483648);
    }


    [Fact]
    public void Check_Number_MaxValue()
    {
        // Arrange
        var number = new Number(10);

        // Act
        var result = number.MaxValue;

        // Assert 
        Assert.Equal(result, 2147483647);
    }


    [Fact]
    public void Check_ToString()
    {
        // Arrange
        var number = new Number(10);

        // Act
        var result = number.ToString();

        // Assert 
        Assert.Equal(result, "10");
    }
}