using Graph.AdjancencySet;

namespace GraphTests;

public class GraphAdjacencySetTests
{
    [Fact]
    public void DefaultConstructor_ShouldCreateEmptyUnweightedGraph()
    {
        var graph = new Graph<int>();

        Assert.False(graph.isWeightedGraph);
        Assert.Equal(0, graph.Count);
        Assert.Empty(graph);
    }

    [Fact]
    public void CollectionConstructor_ShouldAddVertices()
    {
        var graph = new Graph<string>(new[] { "A", "B", "C" });

        Assert.Equal(3, graph.Count);
        Assert.True(graph.ContainsVertex("A"));
        Assert.True(graph.ContainsVertex("B"));
        Assert.True(graph.ContainsVertex("C"));
    }

    [Fact]
    public void AddVertex_ShouldThrow_WhenKeyIsNull()
    {
        var graph = new Graph<string>();

        Assert.Throws<ArgumentNullException>(() => graph.AddVertex(null!));
    }

    [Fact]
    public void AddEdge_ShouldCreateUndirectedConnection()
    {
        var graph = CreateUnweightedGraph();

        graph.AddEdge("A", "B");

        Assert.True(graph.HasEdge("A", "B"));
        Assert.Equal(new[] { "B" }, graph.Edges("A"));
        Assert.Equal(new[] { "A" }, graph.Edges("B"));
    }

    [Fact]
    public void AddEdge_ShouldThrow_WhenEdgeAlreadyExists()
    {
        var graph = CreateUnweightedGraph();
        graph.AddEdge("A", "B");

        var exception = Assert.Throws<Exception>(() => graph.AddEdge("A", "B"));

        Assert.Equal("The edge has been already defined!", exception.Message);
    }

    [Fact]
    public void HasEdge_ShouldThrow_WhenVertexDoesNotExist()
    {
        var graph = CreateUnweightedGraph();

        var exception = Assert.Throws<ArgumentException>(() => graph.HasEdge("A", "Z"));

        Assert.Equal("Source or destination vertex is not in this graph.", exception.Message);
    }

    [Fact]
    public void RemoveEdge_ShouldRemoveConnectionFromBothVertices()
    {
        var graph = CreateUnweightedGraph();
        graph.AddEdge("A", "B");

        graph.RemoveEdge("A", "B");

        Assert.False(graph.HasEdge("A", "B"));
        Assert.Empty(graph.Edges("A"));
        Assert.Empty(graph.Edges("B"));
    }

    [Fact]
    public void RemoveVertex_ShouldDeleteVertex_AndIncidentEdges()
    {
        var graph = CreateUnweightedGraph();
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");

        graph.RemoveVertex("A");

        Assert.False(graph.ContainsVertex("A"));
        Assert.Empty(graph.Edges("B"));
        Assert.Empty(graph.Edges("C"));
    }

    [Fact]
    public void Clone_ShouldCopyVertices_WhenGraphHasNoEdges()
    {
        var graph = CreateUnweightedGraph();

        var clone = graph.Clone();

        Assert.Equal(3, graph.Count);
        Assert.Equal(3, clone.Count);
        Assert.True(clone.ContainsVertex("A"));
        Assert.True(clone.ContainsVertex("B"));
        Assert.True(clone.ContainsVertex("C"));
    }

    [Fact]
    public void Clone_ShouldThrow_WhenGraphContainsUndirectedEdges()
    {
        var graph = CreateUnweightedGraph();
        graph.AddEdge("A", "B");

        var exception = Assert.Throws<Exception>(() => graph.Clone());

        Assert.Equal("The edge has been already defined!", exception.Message);
    }

    [Fact]
    public void GetVertex_ShouldExposeNeighbors_AndDefaultWeight()
    {
        var graph = CreateUnweightedGraph();
        graph.AddEdge("A", "B");

        var vertex = graph.GetVertex("A");
        var edge = vertex.GetEdge(graph.GetVertex("B"));

        Assert.Equal("A", vertex.Key);
        Assert.Equal(new[] { "B" }, vertex.ToList());
        Assert.Equal("B", edge.TargetVertexKey);
        Assert.Equal(1, edge.Weight<int>());
    }

    private static Graph<string> CreateUnweightedGraph()
    {
        return new Graph<string>(new[] { "A", "B", "C" });
    }
}
