using Spectre.Console;

namespace TSP_DMM
{
    class Program
    {
        static void Main(string[] args)
        {
            int verticesCount = 20;
            double[,] sharedEdgeWeights = new double[verticesCount, verticesCount];
            Random rand = new Random();

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = i + 1; j < verticesCount; j++)
                {
                    sharedEdgeWeights[i, j] = rand.Next(1, 100);
                    sharedEdgeWeights[j, i] = sharedEdgeWeights[i, j];
                }
            }

            var matrixGraph = new AdjacencyMatrix(verticesCount, sharedEdgeWeights);
            var listGraph = new AdjacencyList(verticesCount, sharedEdgeWeights);
            listGraph.PrintList();
            matrixGraph.PrintMatrix();
            Console.ReadLine();
        }
    }
}