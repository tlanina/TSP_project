 using Spectre.Console;
 using TSP_DMM;

 public class AdjacencyMatrix : Graph
    {
        private double[,] matrix;
        private static Random rand = new Random();
        private double[,] edgeWeights;

        public AdjacencyMatrix(int verticesCount, double[,] sharedEdgeWeights)
        {
            VerticesCount = verticesCount;
            matrix = new double[verticesCount, verticesCount];
            edgeWeights = new double[verticesCount, verticesCount];

            Array.Copy(sharedEdgeWeights, edgeWeights, sharedEdgeWeights.Length);

            for (int i = 0; i < VerticesCount; i++)
            {
                for (int j = i + 1; j < VerticesCount; j++)
                {
                    double weight = edgeWeights[i, j];
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

        public override double GetWeight(int u, int v)
        {
            return edgeWeights[u, v];
        }

        public override List<(int, double)> GetNeighbors(int u)
        {
            List<(int, double)> neighbors = new List<(int, double)>();
            for (int v = 0; v < VerticesCount; v++)
            {
                if (matrix[u, v] > 0)
                    neighbors.Add((v, matrix[u, v]));
            }
            return neighbors;
        }

        public void PrintMatrix()
        {
            var table = new Table();
            table.AddColumn(" ");
            
            for (int i = 0; i < VerticesCount; i++)
            {
                table.AddColumn(i.ToString());
            }
            
            for (int i = 0; i < VerticesCount; i++)
            {
                var row = new string[VerticesCount + 1];
                row[0] = i.ToString();
                for (int j = 0; j < VerticesCount; j++)
                {
                    row[j + 1] = matrix[i, j].ToString();
                }
                table.AddRow(row);
            }
            AnsiConsole.Write(table);
        }
    }