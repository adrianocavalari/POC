using Shouldly;

namespace POCConsole.Inter
{
    public class SlidingWindow
    {
        public static void Exec()
        {
            var max = FindMaxSubarray(new int[] { 4, 2, 1, 7, 8, 1, 2, 8, 1, 0 }, 3);

            max.ShouldBe(16);
        }

        private static int FindMaxSubarray(int[] array, int k)
        {
            var maxValue = int.MinValue;
            var sum = 0;
            var kAdjusted = k - 1;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];

                if (i >= kAdjusted)
                {
                    maxValue = Math.Max(maxValue, sum);
                    sum -= array[i - (kAdjusted)];
                }
            }

            return maxValue;
        }
    }
}
