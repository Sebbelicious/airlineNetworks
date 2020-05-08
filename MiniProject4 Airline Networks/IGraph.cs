using System.Collections.Generic;
using MiniProject4_Airline_Networks.Utils;

namespace MiniProject4_Airline_Networks
{
    public interface IGraph
    {
        
        int V { get; }
        int E { get; }
        void AddEdge(int v, int w); // add an edge from vertice v to vertice w
        void AddEdge(Route route);
        void AddUndirectedEdge(int v, int w) {
        AddEdge(v, w);
        AddEdge(w, v);
        }
        
        IEnumerable<AdjacencyGraph.EdgeNode> Adjacents(int v); // list all adjacent vertices to vertice v
    }
}