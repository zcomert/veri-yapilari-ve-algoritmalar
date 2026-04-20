using Graph.AdjancencySet;

namespace GraphTests;

public class WeightedGraphTests
{
    [Fact]
    public void DefaultConstructor_ShouldCreateEmptyWeightedGraph()
    {
        var graph = new WeightedGraph<int, int>();

        Assert.True(graph.isWeightedGraph);
        Assert.Equal(0, graph.Count);
    }

    [Fact]
    public void AddEdge_ShouldCreateUndirectedWeightedConnection()
    {
        var graph = CreateWeightedGraph();

        graph.AddEdge("A", "B", 5);

        var edge = graph.GetVertex("A").GetEdge(graph.GetVertex("B"));

        Assert.True(graph.HasEdge("A", "B"));
        Assert.Equal(5, edge.Weight<int>());
        Assert.Equal(new[] { "B" }, graph.Edges("A"));
        Assert.Equal(new[] { "A" }, graph.Edges("B"));
    }

    [Fact]
    public void RemoveEdge_ShouldRemoveBothSides()
    {
        var graph = CreateWeightedGraph();
        graph.AddEdge("A", "B", 5);

        graph.RemoveEdge("A", "B");

        Assert.False(graph.HasEdge("A", "B"));
        Assert.Empty(graph.Edges("A"));
        Assert.Empty(graph.Edges("B"));
    }

    [Fact]
    public void RemoveVertex_ShouldDeleteIncidentWeightedEdges()
    {
        var graph = CreateWeightedGraph();
        graph.AddEdge("A", "B", 5);
        graph.AddEdge("A", "C", 7);

        graph.RemoveVertex("A");

        Assert.False(graph.ContainsVertex("A"));
        Assert.Empty(graph.Edges("B"));
        Assert.Empty(graph.Edges("C"));
    }

    [Fact]
    public void Clone_ShouldCopyVertices_WhenGraphHasNoEdges()
    {
        var graph = CreateWeightedGraph();

        var clone = graph.Clone();

        Assert.Equal(3, clone.Count);
        Assert.True(clone.ContainsVertex("A"));
        Assert.True(clone.ContainsVertex("B"));
        Assert.True(clone.ContainsVertex("C"));
    }

    [Fact]
    public void Clone_ShouldThrow_WhenGraphContainsUndirectedWeightedEdges()
    {
        var graph = CreateWeightedGraph();
        graph.AddEdge("A", "B", 5);

        Assert.Throws<ArgumentException>(() => graph.Clone());
    }

    private static WeightedGraph<string, int> CreateWeightedGraph()
    {
        return new WeightedGraph<string, int>(new[] { "A", "B", "C" });
    }
}
