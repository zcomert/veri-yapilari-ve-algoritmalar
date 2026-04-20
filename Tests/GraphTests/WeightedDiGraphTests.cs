using Graph.AdjancencySet;

namespace GraphTests;

public class WeightedDiGraphTests
{
    [Fact]
    public void DefaultConstructor_ShouldCreateEmptyWeightedDirectedGraph()
    {
        var graph = new WeightedDiGraph<int, int>();

        Assert.True(graph.isWeightedGraph);
        Assert.Equal(0, graph.Count);
    }

    [Fact]
    public void AddEdge_ShouldCreateOneWayWeightedConnection()
    {
        var graph = CreateWeightedDirectedGraph();

        graph.AddEdge("A", "B", 11);

        var source = graph.GetVertex("A");
        var edge = source.GetOutEdge(graph.GetVertex("B"));

        Assert.True(graph.HasEdge("A", "B"));
        Assert.False(graph.HasEdge("B", "A"));
        Assert.Equal(11, edge.Weight<int>());
        Assert.Equal(1, source.OutEdgesCount);
        Assert.Equal(1, graph.GetVertex("B").InEdgesCount);
    }

    [Fact]
    public void AddEdge_ShouldThrow_WhenDuplicateDirectedEdgeExists()
    {
        var graph = CreateWeightedDirectedGraph();
        graph.AddEdge("A", "B", 11);

        var exception = Assert.Throws<Exception>(() => graph.AddEdge("A", "B", 15));

        Assert.Equal("The edge has been already defined!", exception.Message);
    }

    [Fact]
    public void RemoveEdge_ShouldRemoveDirectedWeightedConnection()
    {
        var graph = CreateWeightedDirectedGraph();
        graph.AddEdge("A", "B", 11);

        graph.RemoveEdge("A", "B");

        Assert.False(graph.HasEdge("A", "B"));
        Assert.Equal(0, graph.GetVertex("A").OutEdgesCount);
        Assert.Equal(0, graph.GetVertex("B").InEdgesCount);
    }

    [Fact]
    public void RemoveVertex_ShouldRemoveVertexFromGraph()
    {
        var graph = CreateWeightedDirectedGraph();
        graph.AddEdge("A", "B", 11);
        graph.AddEdge("C", "A", 13);

        graph.RemoveVertex("A");

        Assert.False(graph.ContainsVertex("A"));
        Assert.Equal(2, graph.Count);
        Assert.True(graph.ContainsVertex("B"));
        Assert.True(graph.ContainsVertex("C"));
    }

    [Fact]
    public void Clone_ShouldPreserveDirectedWeights()
    {
        var graph = CreateWeightedDirectedGraph();
        graph.AddEdge("A", "B", 11);
        graph.AddEdge("B", "C", 4);

        var clone = graph.Clone();

        Assert.Equal(11, clone.GetVertex("A").GetOutEdge(clone.GetVertex("B")).Weight<int>());
        Assert.Equal(4, clone.GetVertex("B").GetOutEdge(clone.GetVertex("C")).Weight<int>());
    }

    private static WeightedDiGraph<string, int> CreateWeightedDirectedGraph()
    {
        return new WeightedDiGraph<string, int>(new[] { "A", "B", "C" });
    }
}
