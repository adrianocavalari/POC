namespace POCConsole.Inter.BaseAlgo
{
    public class NextPermutation
    {
        public static void Exec()
        {
            var list = new List<int> { 1, 2, 3 };
            FindNextPermutation(list).ToArray().DumpList();
        }

        // Function to find the next permutation
        // of the given integer array
        public static List<int> FindNextPermutation(List<int> data)
        {
            // If the given dataset is empty
            // or contains only one element
            // next_permutation is not possible
            if (data.Count <= 1)
                return data;

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
                return data;

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
            return data;
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
