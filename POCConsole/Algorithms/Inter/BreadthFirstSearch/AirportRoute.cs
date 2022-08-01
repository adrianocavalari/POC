using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCConsole.Inter.BreadthFirstSearch
{
    public class AirportRoute
    {
        static string[] airports = "PHX BKK OKC JFK LAX MEX EZE HEL LOS LAP LIM".Split(" ");
        static string[][] routes = {
            new string[] { "PHX", "LAX" },
            new string[] { "PHX", "JFK" },
            new string[] { "JFK", "OKC" },
            new string[] { "JFK", "HEL" },
            new string[] { "JFK", "LOS" },
            new string[] { "MEX", "LAX" },
            new string[] { "MEX", "BKK" },
            new string[] { "MEX", "LIM" },
            new string[] { "MEX", "EZE" },
            new string[] { "LIM", "BKK" },
        };

        static Dictionary<string, List<string>> adjacencyList = new();

        static void AddNode(string airport)
        {
            adjacencyList.Add(airport, new());
        }

        static void AddEdge(string origin, string destination)
        {
            adjacencyList[origin].Add(destination);
            adjacencyList[destination].Add(origin);
        }

        public static void Exec()
        {
            foreach (var item in airports)
            {
                AddNode(item);
            }

            foreach (var item in routes)
            {
                AddEdge(item[0], item[1]);
            }

            //PrintJaggedArray();

            //Bfs("PHX");

            Dfs("PHX", new HashSet<string>());
        }

        public static void Bfs(string start)
        {
            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var airport = queue.Dequeue();
                var destinations = adjacencyList[airport];

                foreach (var destination in destinations)
                {

                    if (!visited.Contains(destination))
                    {
                        visited.Add(destination);
                        queue.Enqueue(destination);
                        Console.WriteLine(destination);
                    }

                    if (destination == "BKK")
                    {
                        Console.WriteLine(" Found it ");
                    }
                }
            }
        }

        public static void Dfs(string start, HashSet<string> visited)
        {
            visited.Add(start);

            var destinations = adjacencyList[start];

            foreach (var destination in destinations)
            {
                if(destination == "BKK")
                {
                    Console.WriteLine("DFS found Bangkok in steps");
                    return;
                }

                if (!visited.Contains(destination))
                {
                    Console.WriteLine(destination);
                    Dfs(destination, visited);
                }
            }
        }

            static void PrintJaggedArray()
        {
            var lines = adjacencyList.Select(a => a.Key + ": " + String.Join(", ", a.Value));
            Console.WriteLine(string.Join(Environment.NewLine, lines));
        }
    }
}
