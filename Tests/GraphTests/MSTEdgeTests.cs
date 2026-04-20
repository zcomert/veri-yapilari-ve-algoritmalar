using Graph.MinimumSpanningTree;

namespace GraphTests;

public class MSTEdgeTests
{
    [Fact]
    public void Constructor_ShouldSetProperties()
    {
        var edge = new MSTEdge<string, int>("A", "B", 7);

        Assert.Equal("A", edge.Source);
        Assert.Equal("B", edge.Destination);
        Assert.Equal(7, edge.Weight);
    }

    [Fact]
    public void CompareTo_ShouldCompareByWeight()
    {
        var small = new MSTEdge<string, int>("A", "B", 2);
        var large = new MSTEdge<string, int>("B", "C", 5);

        Assert.True(small.CompareTo(large) < 0);
        Assert.True(large.CompareTo(small) > 0);
    }

    [Fact]
    public void ToString_ShouldIncludeSourceDestinationAndWeight()
    {
        var edge = new MSTEdge<string, int>("A", "B", 7);

        Assert.Equal("A - B W:7", edge.ToString());
    }
}
