using DisjointSet;

namespace DisjointSetTests;

public class DisjointSetNodeTests
{
    [Fact]
    public void DefaultConstructor_ShouldCreateNode()
    {
        var node = new DisjointSetNode<int>();

        Assert.NotNull(node);
    }

    [Fact]
    public void ValueConstructor_ShouldSetValue_AndDefaultRank()
    {
        var node = new DisjointSetNode<string>("A");

        Assert.Equal("A", node.Value);
        Assert.Equal(0, node.Rank);
    }

    [Fact]
    public void ValueAndRankConstructor_ShouldSetProperties()
    {
        var node = new DisjointSetNode<int>(42, 3);

        Assert.Equal(42, node.Value);
        Assert.Equal(3, node.Rank);
    }

    [Fact]
    public void Properties_ShouldBeAssignable()
    {
        var parent = new DisjointSetNode<int>(1, 2);
        var child = new DisjointSetNode<int>(2)
        {
            Parent = parent,
            Rank = 5
        };

        Assert.Same(parent, child.Parent);
        Assert.Equal(5, child.Rank);
    }

    [Fact]
    public void ToString_ShouldReturnValueText()
    {
        var node = new DisjointSetNode<int>(99);

        Assert.Equal("99", node.ToString());
    }
}
