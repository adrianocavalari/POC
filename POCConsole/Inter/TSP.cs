using System.Collections.Generic;

namespace POCConsole.Inter
{
    //https://www.geeksforgeeks.org/traveling-salesman-problem-tsp-implementation/

    // Travelling Salesman Problem (TSP) using Dynamic programing

    public class TSP
    {

        public static void Exec()
        {
            // matrix representation of graph
            int[,] graph = {{ 0,    10,   15,   20},            //return 80
                            { 10,   0,    35,   25},            //
                            { 15,   35,   0,    30},            //
                            { 20,   25,   30,   0}};            //
            int s = 0;
            TravellingSalesmanProblem(graph, s).Dump();
        }

        static int TravellingSalesmanProblem(int[,] graph, int s)
        {
            // store all vertex apart
            // from source vertex
            var vertex = new List<int>();

            for (int i = 0; i < graph.GetLength(0); i++)
                if (i != s)
                    vertex.Add(i);

            // store minimum weight
            // Hamiltonian Cycle.
            int min_path = int.MaxValue;
            do
            {
                // store current Path weight(cost)
                int current_pathweight = 0;

                // compute current path weight
                int k = s;

                for (int i = 0; i < vertex.Count; i++)
                {
                    current_pathweight += graph[k, vertex[i]];
                    k = vertex[i];
                }

                current_pathweight += graph[k, s];

                // update minimum
                min_path = Math.Min(min_path, current_pathweight);

            } while (FindNextPermutation(vertex));

            return min_path;
        }

        // Function to find the next permutation
        // of the given integer array
        public static bool FindNextPermutation(List<int> data)
        {
            // If the given dataset is empty
            // or contains only one element
            // next_permutation is not possible
            if (data.Count <= 1)
                return false;

            int last = data.Count - 2;

            // find the longest non-increasing
            // suffix and find the pivot
            while (last >= 0)
            {
                if (data[last] < data[last + 1])
                {
                    break;
                }
                last--;
            }

            // If there is no increasing pair
            // there is no higher order permutation
            if (last < 0)
                return false;

            int nextGreater = data.Count - 1;

            // Find the rightmost successor
            // to the pivot
            for (int i = data.Count - 1; i > last; i--)
            {
                if (data[i] > data[last])
                {
                    nextGreater = i;
                    break;
                }
            }

            // Swap the successor and
            // the pivot
            data = Swap(data, nextGreater, last);

            // Reverse the suffix
            Reverse(data, last + 1, data.Count - 1);

            // Return true as the
            // next_permutation is done
            return true;
        }

        // Function to swap the data
        // present in the left and right indices
        public static List<int> Swap(List<int> data, int left, int right)
        {
            // Swap the data
            int temp = data[left];
            data[left] = data[right];
            data[right] = temp;

            // Return the updated array
            return data;
        }

        // Function to reverse the sub-array
        // starting from left to the right
        // both inclusive
        public static List<int> Reverse(List<int> data, int left, int right)
        {
            // Reverse the sub-array
            while (left < right)
            {
                int temp = data[left];
                data[left++] = data[right];
                data[right--] = temp;
            }

            // Return the updated array
            return data;
        }
    }
}