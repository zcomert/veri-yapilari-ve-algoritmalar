using Graph.AdjancencySet;
using Graph.MinimumSpanningTree;

namespace GraphTests;

public class PrimsTests
{
    [Fact]
    public void FindMinimumSpanningTree_ShouldReturnExpectedEdges_ForConnectedWeightedGraph()
    {
        var graph = CreateWeightedGraph();
        var algorithm = new Prims<string, int>();

        var result = algorithm.FindMinimumSpanningTree(graph);

        Assert.Equal(3, result.Count);
        Assert.Equal(6, result.Sum(edge => edge.Weight));
        Assert.Contains(result, edge => edge.Source == "A" && edge.Destination == "B" && edge.Weight == 1);
        Assert.Contains(result, edge => edge.Source == "B" && edge.Destination == "C" && edge.Weight == 2);
        Assert.Contains(result, edge => edge.Source == "C" && edge.Destination == "D" && edge.Weight == 3);
    }

    private static WeightedGraph<string, int> CreateWeightedGraph()
    {
        var graph = new WeightedGraph<string, int>(new[] { "A", "B", "C", "D" });
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("B", "C", 2);
        graph.AddEdge("C", "D", 3);
        graph.AddEdge("A", "C", 4);
        graph.AddEdge("B", "D", 5);
        return graph;
    }
}
