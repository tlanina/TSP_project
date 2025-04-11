using Spectre.Console;
using TSP_DMM;

public class AdjacencyList : Graph
    {
        private List<List<(int, double)>> adjacencyList;
        private double[,] edgeWeights;
        private static Random rand = new Random();

        public AdjacencyList(int verticesCount, double[,] sharedEdgeWeights)
        {
            VerticesCount = verticesCount;
            adjacencyList = new List<List<(int, double)>>();

            for (int i = 0; i < verticesCount; i++)
            {
                adjacencyList.Add(new List<(int, double)>());
            }

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

            adjacencyList[u].Add((v, weight));
            adjacencyList[v].Add((u, weight));
        }

        public override bool HasEdge(int u, int v)
        {
            return adjacencyList[u].Exists(neighbor => neighbor.Item1 == v);
        }

        public override double GetWeight(int u, int v)
        {
            return edgeWeights[u, v];
        }

        public override List<(int, double)> GetNeighbors(int u)
        {
            return adjacencyList[u];
        }

        public void PrintList()
        {
            var table = new Table();
            table.AddColumn("Вершина");
            table.AddColumn("Сусіди");

            for (int i = 0; i < VerticesCount; i++)
            {
                var neighborsString = string.Join(", ", adjacencyList[i].Select(n => $"({n.Item1}, {n.Item2})"));
                table.AddRow(i.ToString(), neighborsString);
            }
            
            AnsiConsole.Write(table);
        }
    }