namespace POCConsole.Inter
{
    public class SolutionMergeSort
    {
        public static void Exec()
        {
            Console.WriteLine(string.Join(", ", MergeSort(new[] { 38, 27, 43, 3, 9, 82, 10 })));
        }

        public static int[] MergeSort(int[] array)
        {
            var n = array.Length;
            if (n < 2)
                return array;

            var mid = n / 2;

            var left = MergeSort(array[..mid]);
            var right = MergeSort(array[mid..]);

            return Merge(left, right);
        }

        public static int[] Merge(int[] left, int[] right)
        {
            var res = new int[left.Length + right.Length];
            var resCount = 0;
            var i = 0;
            var j = 0;

            while (i < left.Length || j < right.Length)
            {
                if (i < left.Length && j < right.Length)
                {
                    if (left[i] < right[j])
                    {
                        res[resCount] = left[i];
                        i++;
                    }
                    else
                    {
                        res[resCount] = right[j];
                        j++;
                    }
                }
                else if (i < left.Length)
                {
                    res[resCount] = left[i];
                    i++;
                }
                else if (j < right.Length)
                {
                    res[resCount] = right[j];
                    j++;
                }
                resCount++;
            }

            return res;
        }
    }
}
