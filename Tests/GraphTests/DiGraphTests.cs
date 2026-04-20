using Graph.AdjancencySet;

namespace GraphTests;

public class DiGraphTests
{
    [Fact]
    public void DefaultConstructor_ShouldCreateEmptyDirectedGraph()
    {
        var graph = new DiGraph<int>();

        Assert.False(graph.isWeightedGraph);
        Assert.Equal(0, graph.Count);
        Assert.Empty(graph);
    }

    [Fact]
    public void AddEdge_ShouldCreateOneWayConnection_AndTrackInOutCounts()
    {
        var graph = CreateDirectedGraph();

        graph.AddEdge("A", "B");

        var source = graph.GetVertex("A");
        var target = graph.GetVertex("B");

        Assert.True(graph.HasEdge("A", "B"));
        Assert.False(graph.HasEdge("B", "A"));
        Assert.Equal(1, source.OutEdgesCount);
        Assert.Equal(0, source.InEdgesCount);
        Assert.Equal(0, target.OutEdgesCount);
        Assert.Equal(1, target.InEdgesCount);
    }

    [Fact]
    public void AddEdge_ShouldThrow_WhenEdgeAlreadyExists()
    {
        var graph = CreateDirectedGraph();
        graph.AddEdge("A", "B");

        var exception = Assert.Throws<Exception>(() => graph.AddEdge("A", "B"));

        Assert.Equal("The edge has been already defined!", exception.Message);
    }

    [Fact]
    public void RemoveEdge_ShouldRemoveDirectedConnection()
    {
        var graph = CreateDirectedGraph();
        graph.AddEdge("A", "B");

        graph.RemoveEdge("A", "B");

        Assert.False(graph.HasEdge("A", "B"));
        Assert.Empty(graph.Edges("A"));
        Assert.Equal(0, graph.GetVertex("A").OutEdgesCount);
        Assert.Equal(0, graph.GetVertex("B").InEdgesCount);
    }

    [Fact]
    public void RemoveVertex_ShouldRemoveVertexFromGraph()
    {
        var graph = CreateDirectedGraph();
        graph.AddEdge("A", "B");
        graph.AddEdge("C", "A");

        graph.RemoveVertex("A");

        Assert.False(graph.ContainsVertex("A"));
        Assert.Equal(2, graph.Count);
        Assert.True(graph.ContainsVertex("B"));
        Assert.True(graph.ContainsVertex("C"));
    }

    [Fact]
    public void Clone_ShouldCopyVerticesAndDirectedEdges_Independently()
    {
        var graph = CreateDirectedGraph();
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "C");

        var clone = graph.Clone();
        clone.AddVertex("D");
        clone.AddEdge("C", "D");

        Assert.False(graph.ContainsVertex("D"));
        Assert.True(clone.HasEdge("C", "D"));
        Assert.False(graph.HasEdge("C", "A"));
    }

    [Fact]
    public void GetVertex_ShouldExposeOutEdgeAndDefaultWeight()
    {
        var graph = CreateDirectedGraph();
        graph.AddEdge("A", "B");

        var edge = graph.GetVertex("A").GetOutEdge(graph.GetVertex("B"));

        Assert.Equal("B", edge.TargetVertexKey);
        Assert.Equal(1, edge.Weight<int>());
    }

    private static DiGraph<string> CreateDirectedGraph()
    {
        return new DiGraph<string>(new[] { "A", "B", "C" });
    }
}
