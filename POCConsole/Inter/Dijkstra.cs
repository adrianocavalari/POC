using System.Collections.Generic;

namespace POCConsole.Inter
{
    //https://www.geeksforgeeks.org/csharp-program-for-dijkstras-shortest-path-algorithm-greedy-algo-7/

    // A C# program for Dijkstra's single
    // source shortest path algorithm.
    // The program is for adjacency matrix
    // representation of the graph

    public class Dijkstra
    {
        public static void Exec()
        {
            /* Let us create the example graph discussed above */
            //							  0   1   2   3   4   5   6   7   8	                //Result
            //int[,] graph = new int[,] { { 0,  4,  0,  0,  0,  0,  0,  8,  0 },              //0                0
            //                            { 4,  0,  8,  0,  0,  0,  0,  11, 0 },              //1                4
            //                            { 0,  8,  0,  7,  0,  4,  0,  0,  2 },              //2                12
            //                            { 0,  0,  7,  0,  9,  14, 0,  0,  0 },              //3                19
            //                            { 0,  0,  0,  9,  0,  10, 0,  0,  0 },              //4                21
            //                            { 0,  0,  4,  14, 10, 0,  2,  0,  0 },              //5                11
            //                            { 0,  0,  0,  0,  0,  2,  0,  1,  6 },              //6                9
            //                            { 8,  11, 0,  0,  0,  0,  1,  0,  7 },              //7                8
            //                            { 0,  0,  2,  0,  0,  0,  6,  7,  0 } };            //8                14
            //var t = new Dijkstra();
            //t.dijkstra(graph, 0);

            #region WithPriorityQueue

            //Source vertex
            int source = 0;
            int[][] adjacencyMatrix = new int[][] { 
                                        new int[] { 0,0,0,3,12 },
                                        new int[] { 0,0,2,0,0 },
                                        new int[] { 0,0,0,2,0 },
                                        new int[] { 0,5,3,0,0 },
                                        new int[] { 0,0,7,0,0 } };

            int numberOfVertex = adjacencyMatrix[0].Length;
            int[] distance = Enumerable.Repeat(int.MaxValue, numberOfVertex).ToArray();
            int[] parent = Enumerable.Repeat(-1, numberOfVertex).ToArray();
            distance[source] = 0;
            //calling dijkstra  algorithm
            DijkstraPriorityQueue(adjacencyMatrix, numberOfVertex, distance, parent);
            //printing distance
            PrintPath(0, 2, distance, parent);
            #endregion
        }

        // Function that implements Dijkstra's
        // single source shortest path algorithm
        // for a graph represented using adjacency
        // matrix representation
        void dijkstra(int[,] graph, int src)
        {
            var n = graph.GetLength(0);
            var dist = new int[n]; // The output array. dist[i]
                                   // will hold the shortest
                                   // distance from src to i

            // sptSet[i] will true if vertex
            // i is included in shortest path
            // tree or shortest distance from
            // src to i is finalized
            var visited = new bool[n];

            // Initialize all distances as
            // INFINITE and stpSet[] as false
            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
            }

            // Distance of source vertex
            // from itself is always 0
            dist[src] = 0;

            // Find shortest path for all vertices
            for (var count = 0; count < n - 1; count++)
            {
                // Pick the minimum distance vertex
                // from the set of vertices not yet
                // processed. u is always equal to
                // src in first iteration.
                var distance = minDistance(dist, visited, n);

                // Mark the picked vertex as processed
                visited[distance] = true;

                // Update dist value of the adjacent
                // vertices of the picked vertex.
                for (var v = 1; v < n; v++)
                {
                    // Update dist[v] only if is not in
                    // sptSet, there is an edge from u
                    // to v, and total weight of path
                    // from src to v through u is smaller
                    // than current value of dist[v]
                    var isVisited = visited[v];
                    var currentDistance = dist[distance];
                    var nextDistance = graph[distance, v];

                    if (!isVisited
                        && nextDistance != 0
                        && currentDistance != int.MaxValue
                        && currentDistance + nextDistance < dist[v])
                    {
                        dist[v] = currentDistance + nextDistance;
                    }
                }
            }

            // print the constructed distance array
            printSolution(dist, n);

        }

        // A utility function to find the
        // vertex with minimum distance
        // value, from the set of vertices
        // not yet included in shortest
        // path tree
        int minDistance(int[] dist,
                            bool[] visited,
                            int n)
        {
            // Initialize min value
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < n; v++)
            {
                if (visited[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }

            return min_index;
        }

        // A utility function to print
        // the constructed distance array
        void printSolution(int[] dist, int n)
        {
            Console.Write("Vertex	 Distance "
                        + "from Source\n");
            for (int i = 0; i < n; i++)
                Console.Write(i + " \t\t " + dist[i] + "\n");
        }


        public static void DijkstraPriorityQueue(int[][] adjacencyMatrix, int numberOfVertex, int[] distance, int[] parent)
        {
            var vertexQueue = new PriorityQueue<int, int>();
            //adding all vertex to priority queue
            for (int i = 0; i < numberOfVertex; i++)
                vertexQueue.Enqueue(distance[i], i); // priority = distance, object = vertex

            //treversing to all vertices
            while (vertexQueue.Count > 0)
            {
                var u = vertexQueue.Dequeue(); // vertax with least distance
                                               //Traversing to all connecting edges
                for (int v = 0; v < adjacencyMatrix[u].Length; v++)
                {
                    if (adjacencyMatrix[u][v] > 0)
                    {
                        Relax(u, v, adjacencyMatrix[u][v], distance, parent);
                        //updating priority value since distance is changed
                        //vertexQueue.UpdatePriority(v, distance[v]);
                        vertexQueue.Enqueue(v, distance[v]);
                    }
                }
            }
        }

        static void Relax(int u, int v, int weight, int[] distance, int[] parent) 
        {
            if (distance[u] != int.MaxValue && distance[v] > distance[u] + weight)
            {
                distance[v] = distance[u] + weight;
                parent[v] = u;
            }
        }

        public static void PrintPath(int u, int v, int[] distance, int[] parent)
        {
            if (v < 0 || u < 0)
            {
                return;
            }
            if (v != u)
            {
                PrintPath(u, parent[v], distance, parent);
                Console.WriteLine("Vertax {0} weight: {1}", v, distance[v]);
            }
            else
                Console.WriteLine("Vertax {0} weight: {1}", v, distance[v]);
        }
    }
}
