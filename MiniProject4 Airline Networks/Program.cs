using System;
using System.Net.Mime;
using MiniProject4_Airline_Networks.Utils;

namespace MiniProject4_Airline_Networks
{
    class Program
    {
        static void Main(string[] args)
        {
            // split string into list of Route objects
            var routesText = TextParser.ReadText("routes.txt");
            var routes = TextParser.ParseRoutes(routesText);


            // Make Graph based on routes
            // IGraph graph = new AdjacencyGraph(TextParser.AirportsFromRoutes.Count, TextParser.MakeAirportDict());
           var wg = new WeightedGraph(TextParser.AirportsFromRoutes); 
            // foreach (var route in routes)
            // {
            //     graph.AddEdge(route);
            // }

            foreach (var t in routes)
            {
                wg.AddEdge(t);
            }
            
            var dsp = new DijkstraShortestPath(wg, "CPH");
            dsp.Print();
            
            // Console.WriteLine(wg);
            // Compare timings between BreadthFirstSearch and DepthFirstSearch 
            //
            //
            // Use Dijkstra's algorithm to find shortestpath, both on Route's distance and time attributes
        }
    }
}