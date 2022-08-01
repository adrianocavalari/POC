using Shouldly;

namespace POCConsole.Course.MCI
{
    //O(N^2)
    public class SelectionSort
    {
        public static void Exec()
        {
            SelectionSortExec(
                new[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 })
                .DumpList()
                .ShouldBe(new[] { 0, 1, 2, 4, 5, 6, 44, 63, 87, 99, 283 });
        }

        private static int[] SelectionSortExec(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var min = i;
                var temp = array[i];
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                array[i] = array[min];
                array[min] = temp;
            }

            return array;
        }

    }
}
