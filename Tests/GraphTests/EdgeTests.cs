using Graph;
using Graph.AdjancencySet;

namespace GraphTests;

public class EdgeTests
{
    [Fact]
    public void Constructor_ShouldExposeTargetVertexKey_Weight_AndStringRepresentation()
    {
        var graph = new Graph<int>(new[] { 1, 2 });
        var target = graph.GetVertex(2);
        var edge = new Edge<int, int>(target, 7);

        Assert.Equal(2, edge.TargetVertexKey);
        Assert.Same(target, edge.TargetVertex);
        Assert.Equal(7, edge.Weight<int>());
        Assert.Equal("2", edge.ToString());
    }
}
