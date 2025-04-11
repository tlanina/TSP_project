using System;
using System.Collections.Generic;

namespace TSP_DMM
{
    public class AdjacencyMatrix : Graph
    {
        private double[,] matrix;
        private static Random rand = new Random();  

        public AdjacencyMatrix(int verticesCount)
        {
            VerticesCount = verticesCount;
            matrix = new double[verticesCount, verticesCount];


            for (int i = 0; i < VerticesCount; i++)
            {
                for (int j = i + 1; j < VerticesCount; j++) 
                {
                    double weight = rand.Next(1, 100); 
                    AddEdge(i, j, weight);
                }
            }
        }

        public override void AddEdge(int u, int v, double weight)
        {
            if (u == v || weight <= 0)
                return;

            matrix[u, v] = weight;
            matrix[v, u] = weight;
        }

        public override bool HasEdge(int u, int v)
        {
            return matrix[u, v] > 0;
        }

        public override int GetWeight(int u, int v)
        {
            return (int)matrix[u, v];
        }

        public override List<(int, double)> GetNeighbors(int u)
        {
            return Enumerable.Range(0, VerticesCount).Where(v => matrix[u, v] > 0).Select(v => (v, matrix[u, v])).ToList();
        }

        public void PrintMatrix()
        {
            Console.WriteLine("Матриця суміжності:");
            for (int i = 0; i < VerticesCount; i++)
            {
                for (int j = 0; j < VerticesCount; j++)
                    Console.Write($"{matrix[i, j],4}");
                Console.WriteLine();
            }
        }
    }
}