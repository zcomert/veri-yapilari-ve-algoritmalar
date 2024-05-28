namespace Tests.DisjointSetTests;
using System;
using DataStructures.DisjointSet;
using Xunit;

public class DisjointSetTests
{
    [Fact]
    public void Constructor_Should_Initialize_Empty_Set()
    {
        // Act
        var disjointSet = new DisjointSet<int>();

        // Assert
        Assert.Equal(0, disjointSet.Count);
    }

    [Fact]
    public void Constructor_With_Collection_Should_Create_Sets()
    {
        // Arrange
        var values = new[] { 1, 2, 3 };

        // Act
        var disjointSet = new DisjointSet<int>(values);

        // Assert
        Assert.Equal(values.Length, disjointSet.Count);
        foreach (var value in values)
        {
            Assert.Equal(value, disjointSet.FindSet(value));
        }
    }

    [Fact]
    public void MakeSet_Should_Add_New_Set()
    {
        // Arrange
        var disjointSet = new DisjointSet<string>();

        // Act
        disjointSet.MakeSet("A");

        // Assert
        Assert.Equal(1, disjointSet.Count);
        Assert.Equal("A", disjointSet.FindSet("A"));
    }

    [Fact]
    public void MakeSet_Should_Throw_Exception_If_Value_Already_Exists()
    {
        // Arrange
        var disjointSet = new DisjointSet<int>();
        disjointSet.MakeSet(1);

        // Act & Assert
        Assert.Throws<Exception>(() => disjointSet.MakeSet(1));
    }

    [Fact]
    public void FindSet_Should_Return_Correct_Set()
    {
        // Arrange
        var disjointSet = new DisjointSet<int>();
        disjointSet.MakeSet(1);
        disjointSet.MakeSet(2);
        disjointSet.MakeSet(3);

        // Act & Assert
        Assert.Equal(1, disjointSet.FindSet(1));
        Assert.Equal(2, disjointSet.FindSet(2));
        Assert.Equal(3, disjointSet.FindSet(3));
    }

    [Fact]
    public void FindSet_Should_Throw_Exception_If_Value_Not_Found()
    {
        // Arrange
        var disjointSet = new DisjointSet<int>();

        // Act & Assert
        Assert.Throws<Exception>(() => disjointSet.FindSet(1));
    }

    [Fact]
    public void Union_Should_Union_Two_Sets()
    {
        // Arrange
        var disjointSet = new DisjointSet<int>();
        disjointSet.MakeSet(1);
        disjointSet.MakeSet(2);

        // Act
        disjointSet.Union(1, 2);

        // Assert
        Assert.Equal(disjointSet.FindSet(1), disjointSet.FindSet(2));
    }

    [Fact]
    public void Union_Should_Handle_Different_Ranks_Correctly()
    {
        // Arrange
        var disjointSet = new DisjointSet<int>();
        disjointSet.MakeSet(1);
        disjointSet.MakeSet(2);
        disjointSet.MakeSet(3);
        disjointSet.Union(1, 2);

        // Act
        disjointSet.Union(1, 3);

        // Assert
        Assert.Equal(disjointSet.FindSet(1), disjointSet.FindSet(3));
    }

    [Fact]
    public void Union_Should_Not_Union_Same_Set_Twice()
    {
        // Arrange
        var disjointSet = new DisjointSet<int>();
        disjointSet.MakeSet(1);
        disjointSet.MakeSet(2);
        disjointSet.Union(1, 2);

        // Act
        disjointSet.Union(1, 2);

        // Assert
        Assert.Equal(disjointSet.FindSet(1), disjointSet.FindSet(2));
    }

    [Fact]
    public void Enumerator_Should_Return_All_Values()
    {
        // Arrange
        var values = new[] { 1, 2, 3 };
        var disjointSet = new DisjointSet<int>(values);

        // Act
        var result = disjointSet.ToList();

        // Assert
        Assert.Equal(values.Length, result.Count);
        foreach (var value in values)
        {
            Assert.Contains(value, result);
        }
    }
}
