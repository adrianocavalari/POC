using Shouldly;

namespace POCConsole.Course.MCI
{
    //O(N^2)
    public class BubbleSort
    {
        public static void Exec()
        {
            BubbleSortExec(
                new[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 })
                .DumpList()
                .ShouldBe(new[] { 0, 1, 2, 4, 5, 6, 44, 63, 87, 99, 283 });
        }

        private static int[] BubbleSortExec(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;
        }

    }
}
