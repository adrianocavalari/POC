using Shouldly;

namespace POCConsole.Course.MCI
{
    //O(n logn)
    //Most efficient sort
    public class MergeSort
    {
        public static void Exec()
        {
            MergeSortExec(
                new[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 })
                .DumpList()
                .ShouldBe(new[] { 0, 1, 2, 4, 5, 6, 44, 63, 87, 99, 283 });
        }

        private static int[] MergeSortExec(int[] array)
        {
            if (array.Length < 2)
                return array;

            var mid = array.Length / 2;

            var left = MergeSortExec(array[..mid]);
            var right = MergeSortExec(array[mid..]);

            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var res = new int[left.Length + right.Length];

            var place = 0;
            var i = 0;
            var j = 0;
            while (i < left.Length || j < right.Length)
            {
                if (i < left.Length && j < right.Length)
                {
                    if (left[i] < right[j])
                    {
                        res[place] = left[i];
                        i++;
                    }
                    else
                    {
                        res[place] = right[j];
                        j++;
                    }
                }
                else
                {
                    if (i < left.Length)
                    {
                        res[place] = left[i];
                        i++;
                    }

                    if (j < right.Length)
                    {
                        res[place] = right[j];
                        j++;
                    }
                }

                place++;
            }


            return res;
        }
    }
}
