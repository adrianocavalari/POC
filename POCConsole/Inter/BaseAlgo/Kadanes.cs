using Shouldly;

namespace POCConsole.Inter.BaseAlgo
{
    //https://leetcode.com/problems/maximum-subarray/
    //with divide and conquer https://www.geeksforgeeks.org/maximum-subarray-sum-using-divide-and-conquer-algorithm/

    public class Kadanes
    {
        public static void Exec()
        {
            BruteForce(new[] { 2, -5, 10, -1, 4, -10 }).ShouldBe(13);
            BruteForce(new[] { -1, -2, -3, -4 }).ShouldBe(-1);
            KadanesAlgo(new[] { 2, -5, 10, -1, 4, -10 }).ShouldBe(13);
            KadanesAlgo(new[] { -1, -2, -3, -4 }).ShouldBe(-1);
        }

        public static int KadanesAlgo(int[] nums)
        {
            var max = int.MinValue;
            var sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum = Math.Max(nums[i], sum + nums[i]);
                max = Math.Max(max, sum);
            }

            return max;
        }

        // Brute force
        public static int BruteForce(int[] nums)
        {
            var max = nums[0];
            var sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum = nums[i];

                for (int j = i + 1; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum > max)
                        max = sum;
                }
            }

            return max;
        }
    }
}
