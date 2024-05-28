namespace Tests.DisjointSetTests;
using global::DataStructures.DisjointSet;
using Xunit;
public class DisjointSetNodeTests
{
    [Fact]
    public void Constructor_Should_Set_Value_Correctly()
    {
        // Arrange
        var value = "A";

        // Act
        var node = new DisjointSetNode<string>(value);

        // Assert
        Assert.Equal(value, node.Value);
        Assert.Equal(0, node.Rank);
        Assert.Null(node.Parent);
    }

    [Fact]
    public void Constructor_With_Rank_Should_Set_Properties_Correctly()
    {
        // Arrange
        var value = "B";
        var rank = 5;

        // Act
        var node = new DisjointSetNode<string>(value, rank);

        // Assert
        Assert.Equal(value, node.Value);
        Assert.Equal(rank, node.Rank);
        Assert.Null(node.Parent);
    }

    [Fact]
    public void Set_Properties_Should_Work_Correctly()
    {
        // Arrange
        var node = new DisjointSetNode<string>();
        var value = "C";
        var rank = 3;
        var parentNode = new DisjointSetNode<string>("Parent");

        // Act
        node.Value = value;
        node.Rank = rank;
        node.Parent = parentNode;

        // Assert
        Assert.Equal(value, node.Value);
        Assert.Equal(rank, node.Rank);
        Assert.Equal(parentNode, node.Parent);
    }

    [Fact]
    public void ToString_Should_Return_Value_As_String()
    {
        // Arrange
        var value = "D";
        var node = new DisjointSetNode<string>(value);

        // Act
        var result = node.ToString();

        // Assert
        Assert.Equal(value, result);
    }
}