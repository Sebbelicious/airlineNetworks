// using System;
// using MiniProject4_Airline_Networks.Basics;
//
// namespace MiniProject4_Airline_Networks
// {
//     public class BreadthFirstSearch
//     {
//         private readonly IGraph _graph;
//         private int[] _visitedFrom;
//         private IQueue<Edge> _edges;
//
//         public BreadthFirstSearch(IGraph graph) {
//             _graph = graph;
//             _visitedFrom = new int[graph.V];
//             for (int v = 0; v < _visitedFrom.Length; v++) _visitedFrom[v] = -1;
//             _edges = new ArrayQueue<Edge>(1_000);
//         }
//
//         private class Edge {
//             internal int from;
//             internal int to;
//
//             internal Edge(int from, int to) {
//                 this.from = from;
//                 this.to = to;
//             }
//
//             public override string ToString() {
//                 return ""+from+" -> "+to;
//             }
//         }
//
//         private void Register(Edge edge) {
//             if (_visitedFrom[edge.to] != -1) return;
//             // only register if 'to' has not been registered already
//             _edges.Enqueue(edge);
//             _visitedFrom[edge.to] = edge.from;
//         }
//
//         public void SearchFrom(int v) {
//             Register(new Edge(v, v));
//             while (!_edges.IsEmpty()) {
//                 Edge step = _edges.Dequeue();
//                 foreach (var w in _graph.Adjacents(step.to))
//                 {
//                     Register(new Edge(step.to, w));
//                 }
//             }
//         }
//
//         public string ShowPathTo(int w) {
//             string path = ""+w;
//             while (_visitedFrom[w] != w && _visitedFrom[w] != -1) {
//                 w = _visitedFrom[w];
//                 path = ""+w+" -> "+path;
//             }
//             return path;
//         }
//
//         public void Print() {
//             for (int v = 0; v < _graph.V; v++)
//                 Console.WriteLine("" + v + ": " + ShowPathTo(v));
//         }
//
//         // static void Main(string[] args) {
//         //     IGraph g = new AdjacencyGraph(6);
//         //     g.AddUndirectedEdge(0, 5);
//         //     g.AddUndirectedEdge(0, 1);
//         //     g.AddUndirectedEdge(0, 2);
//         //     g.AddUndirectedEdge(2, 3);
//         //     g.AddUndirectedEdge(2, 4);
//         //     g.AddUndirectedEdge(3, 4);
//         //     g.AddUndirectedEdge(5, 3);
//         //
//         //     BreadthFirstSearch bfs = new BreadthFirstSearch(g);
//         //     bfs.SearchFrom(0);
//         //     bfs.Print();
//         // }
//     }
// }