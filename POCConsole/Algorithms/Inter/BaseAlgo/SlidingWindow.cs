using Shouldly;

namespace POCConsole.Inter
{
    public class SlidingWindow
    {
        public static void Exec()
        {
            FindMaxSubarray(new int[] { 4, 2, 1, 7, 8, 1, 2, 8, 1, 0 }, 3).ShouldBe(16);
            //ContainsNearbyDuplicate(new[] { 1, 2, 3, 1 }, 3).ShouldBeTrue();
            //ContainsNearbyDuplicate(new[] { 1, 0, 1, 1 }, 1).ShouldBeTrue();
            //ContainsNearbyDuplicate(new[] { 1, 2, 3, 1, 2, 3 }, 2).ShouldBeFalse();
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

        //https://leetcode.com/problems/contains-duplicate-ii/
        private static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            //var hash = new HashSet<int>();
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (i > k) hash.Remove(nums[i - k - 1]);

            //    if (!hash.Add(nums[i])) return true;
            //}
            //return false;


            var lastK = new HashSet<int>();
            int left = 0;
            int right = 0;
            while (right < nums.Length)
            {
                if (right - left > k)         //window size greater than k, remove oldest element and advance left pointer
                    lastK.Remove(nums[left++]);

                //already present in the set(Add method to Set interface has a boolean return parameter) ? return true, else    advance right pointer
                if (lastK.Add(nums[right++]) == false)
                    return true;
            }
            return false;
        }
    }
}
