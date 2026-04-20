using Graph;
using Graph.AdjancencySet;

namespace GraphTests;

public class DiEdgeTests
{
    [Fact]
    public void Constructor_ShouldExposeTargetVertexKey_Weight_AndStringRepresentation()
    {
        var graph = new DiGraph<string>(new[] { "A", "B" });
        var target = graph.GetVertex("B");
        var edge = new DiEdge<string, int>(target, 9);

        Assert.Equal("B", edge.TargetVertexKey);
        Assert.Same(target, edge.TargetVertex);
        Assert.Equal(9, edge.Weight<int>());
        Assert.Equal("B", edge.ToString());
    }
}
