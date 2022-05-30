namespace POCConsole.Inter
{
    //https://practice.geeksforgeeks.org/problems/bfs-traversal-of-graph/1/#

    public class BFSTest
    {
        public static void Exec()
        {
            GFG.Main();
        }

        public List<int> bfsOfGraph(int V, List<List<int>> adj)
        {
            var list = new List<int>();

            var vis = new bool[V];

            var queue = new Queue<int>();

            queue.Enqueue(0);
            vis[0] = true;

            while (queue.Count != 0)
            {
                int n = queue.Dequeue();
                list.Add(n);

                foreach (var i in adj[n])
                {
                    if (!vis[i])
                    {
                        vis[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }

            return list;
        }
    }

    public class GFG
    {
        public static void Main()
        {
            //10, 26
            var V = 10;                                                 
            var adj = new List<List<int>>                               //
            {                                                           //Generates array like
                new() { 2, 3, 4, 5, 6, 7 },                             //[[2, 3, 4, 5, 6, 7], 
                new() { 2, 3, 4, 5, 7, 8 },                             //[2, 3, 4, 5, 7, 8], 
                new() { 3, 5, 7, 8, 9 },                                //[3, 5, 7, 8, 9]
                new() { 4, 7, 8, 9 },                                   //[4, 7, 8, 9]
                new() { 5 },                                            //[5]
                new() { 7, 9 },                                         //[7, 9]
                new() { 8 },                                            //[8]
                new() { },                                              //[]
                new() { 9 },                                            //[9]
                new() { },                                              //[]]
            };                                                          //




            //var ip = Console.ReadLine().Trim().Split(' ');
            //int V = int.Parse(ip[0]);
            //int E = int.Parse(ip[1]);
            //List<List<int>> adj = new List<List<int>>();
            //for (int i = 0; i < V; i++)
            //{
            //    adj.Add(new List<int>());
            //}
            //for (int i = 0; i < E; i++)
            //{
            //    ip = Console.ReadLine().Trim().Split(' ');
            //    int u = int.Parse(ip[0]);
            //    int v = int.Parse(ip[1]);
            //    adj[u].Add(v);
            //}
            var obj = new BFSTest();
            var res = obj.bfsOfGraph(V, adj);

            var path = new List<int>();

            for (var at = adj[8][0]; at != null; at = res[at-1])
            {
                path.Add(at);
            }

            foreach (int i in res) { Console.Write(i + " "); }
            Console.WriteLine();
        }
    }
}
