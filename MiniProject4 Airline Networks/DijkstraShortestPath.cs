using System;
using System.Collections.Generic;
using MiniProject4_Airline_Networks.Basics;

namespace MiniProject4_Airline_Networks
{
    public class DijkstraShortestPath
    {
        private readonly WeightedGraph _graph;
        private readonly string _source;
        private Dictionary<string, string> _edgeTo;
        private Dictionary<string, double> _distTo;
        private PriorityQueue<Path> _pqMin = new PriorityQueue<Path>(3_684);

        public DijkstraShortestPath(WeightedGraph graph, string source)
        {
            _graph = graph;
            _source = source;
            var V = graph.GetV();
            _edgeTo = new Dictionary<string, string>();
            _distTo = new Dictionary<string, double>();

            foreach (var item in graph._vertices)
            {
                _edgeTo.Add(item.Key, "");
                _distTo.Add(item.Key, double.MaxValue);
            }

            _edgeTo[source] = source;
            _distTo[source] = 0;
            _pqMin.Enqueue(new Path(source, 0.0));
            Build();
        }

        public class Path : IComparable<Path> {
            public string v;
            double weight;

            public Path(string v, double weight) {
                this.v = v;
                this.weight = weight;
            }

            public int CompareTo(Path other)
            {
                if (weight < other.weight) return -1;
                if (weight > other.weight) return 1;
                return 0;
            }

            public override string ToString()
            {
                return "" + v + ": " + weight;
            }
            
        }

        private void Build()
        {
            while (!_pqMin.IsEmpty())
            {
                var path = _pqMin.Dequeue();
                Relax(path);
            }
        }

        private void Relax(Path path)
        {
            var adj = _graph.Adjacents(path.v);
            
            foreach (var edge in adj) 
            {
                double newDistance = _distTo[edge.From] + edge.Weight;
                if (_distTo[edge.To] > newDistance)
                {
                    // update distTo and edgeTo...
                    _distTo[edge.To] = newDistance;
                    _edgeTo[edge.To] = edge.From;
                    // update priority queue
                    _pqMin.Enqueue(new Path(edge.To, newDistance));
                }
            }
        }

        public string ShowPathTo(string w)
        {
            String path = "" + w;
            while (_edgeTo[w] != w && !_edgeTo[w].Equals(""))
            {
                w = _edgeTo[w];
                path = "" + w + " -> " + path;
            }

            return path;
        }

        public void Print()
        {
            foreach (var item in _graph._vertices)
            {
                Console.WriteLine("" + item.Key + ": " + ShowPathTo(item.Key));
            }
        }

        // public static void Main(string[] args)
        // {
        //     WeightedGraph g = new WeightedGraph(6);
        //     g.AddEdge(0, 2, 3.0);
        //     g.AddEdge(0, 1, 2.0);
        //     g.AddEdge(0, 5, 1.0);
        //     g.AddEdge(0, 5, 1.0);
        //     g.AddEdge(0, 5, 1.0);
        //     g.AddEdge(0, 5, 1.0);
        //     g.AddEdge(0, 5, 1.0);
        //
        //     DijkstraShortestPath dsp = new DijkstraShortestPath(g, 0);
        //     dsp.Print();
        // }
    }
}