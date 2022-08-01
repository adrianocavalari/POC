using Shouldly;
using System.Numerics;
using System.Text;

namespace POCConsole.Course.MCI
{
    //       (2) -- (0)
    //     /    \
    //   (1) -- (3)

    public class Graph
    {
        private int numbersOfNodes;
        private Dictionary<int,List<int>> adjacentList;

        public Graph()
        {
            numbersOfNodes = 0;
            adjacentList = new Dictionary<int, List<int>>();
        }

        public void AddVertex(int node)
        {
            adjacentList.Add(node, new List<int>());
            numbersOfNodes++;
        }

        public void AddEdges(int vertex, int node)
        {
            adjacentList[vertex].Add(node);
            adjacentList[node].Add(vertex);

        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in adjacentList)
            {
                stringBuilder.Append($"{item.Key} --> ");

                foreach (var subItem in item.Value)
                {
                    stringBuilder.Append($"{subItem} ");
                }
                stringBuilder.AppendLine();

            }

            return stringBuilder.ToString();
        }

        public static void Exec()
        {
            var graph = new Graph();
            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);
            graph.AddEdges(3, 1);
            graph.AddEdges(3, 4);
            graph.AddEdges(4, 2);
            graph.AddEdges(4, 5);
            graph.AddEdges(1, 2);
            graph.AddEdges(1, 0);
            graph.AddEdges(0, 2);
            graph.AddEdges(6, 5);

            Console.WriteLine(graph.ToString());
        }
    }
}
