using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MiniProject4_Airline_Networks.Utils;

namespace MiniProject4_Airline_Networks
{
    public class WeightedGraph
    {
        public Dictionary<string, List<Edge>> _vertices;
        public static bool WeightIsDistanceOrTime = true; // Weight is distance if true or time if false

        public WeightedGraph(IEnumerable<string> airports) {
            _vertices = airports.ToDictionary(x => x, x => new List<Edge>());
            
            // _vertices = new Dictionary<string, IList<Edge>>();
            //
            // foreach (var airportName in airports)
            // {
            //     _vertices.Add(airportName, new List<Edge>());
            // }
        }

        public void AddEdge(Route route) {
            var edge = new Edge(route);
            _vertices[route.SOURCE_CODE].Add(edge);
        }

        public int GetV() { return _vertices.Count; }

        public IEnumerable<Edge> Adjacents(string airportCode) { return _vertices[airportCode]; }

        public override string ToString()
        {
            var text = "";

            foreach (var (source, edges) in _vertices)
            {
                var destinationsStr = "";
                foreach (var edge in edges)
                {
                    destinationsStr += $"{edge.To}, ";
                }

                text += $"{source} :  {destinationsStr} \n";
                
            }
            

            return text;
            
        }

        public class Edge {
            public string From;
            public string To { get; }
            double _distance;
            double _time;
            public double Weight => WeightIsDistanceOrTime ? _distance : _time;

            public Edge(Route route)
            {
                From = route.SOURCE_CODE;
                To = route.DESTINATION_CODE;
                _distance = route.DISTANCE;
                _time = route.TIME;
            }

        }
    }
    
    
}