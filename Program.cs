using System;

namespace TSP_DMM
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new AdjacencyMatrix(20);
            
            graph.PrintMatrix();
        }
    }
}