using Shouldly;

namespace POCConsole.Course.MCI
{
    //O(N^2)
    //Faster when array is nearly sorted
    public class InsertionSort
    {
        public static void Exec()
        {
            InsertionSortExec(
                new[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 })
                .DumpList()
                .ShouldBe(new[] { 0, 1, 2, 4, 5, 6, 44, 63, 87, 99, 283 });
        }

        private static int[] InsertionSortExec(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[i])
                    {
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }
            }

            return array;
        }

    }
}
