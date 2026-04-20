using PriorityQueue;
using Utilities;

namespace Graph.MinimumSpanningTree
{
    public class Prims<T, TW>
        where T : IComparable
        where TW : IComparable
    {
        public List<MSTEdge<T, TW>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T, TW>>();

            dfs(graph,
                graph.ReferenceVertex,
                new BinaryHeap<MSTEdge<T, TW>>(SortDirection.Asceding),
                new HashSet<T>(),
                edges);

            return edges;
        }

        private void dfs(IGraph<T> graph,
            IGraphVertex<T> currentVertex,
            BinaryHeap<MSTEdge<T, TW>> spNeighours,
            HashSet<T> spVertices,
            List<MSTEdge<T, TW>> spEdges)
        {
            while (true)
            {
                // kenarlara dikkat
                foreach (var edge in currentVertex.Edges)
                {
                    spNeighours.Add(new MSTEdge<T, TW>(currentVertex.Key,
                        edge.TargetVertexKey,
                        edge.Weight<TW>()));
                }

                // minEdge 
                var minEdge = spNeighours.DeleteMinMax();

                // var olan kenarları dikkate alma 
                while (spVertices.Contains(minEdge.Source)
                    && spVertices.Contains(minEdge.Destination))
                {
                    minEdge = spNeighours.DeleteMinMax();
                    if (spNeighours.Count == 0)
                        return;
                }

                // vertex takibi 
                if (!spVertices.Contains(minEdge.Source))
                {
                    spVertices.Add(minEdge.Source);
                }

                spVertices.Add(minEdge.Destination);
                spEdges.Add(minEdge);

                currentVertex = graph.GetVertex(minEdge.Destination);
            }
        }
    }
}
