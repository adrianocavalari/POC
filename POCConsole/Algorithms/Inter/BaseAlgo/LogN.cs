using Shouldly;

namespace POCConsole.Inter.BaseAlgo
{
    //https://leetcode.com/problems/search-insert-position/

    public class LogN
    {
        public static void Exec()
        {
            SearchInsert(new[] { 1, 3, 5, 6 }, 5); //2
            SearchInsert(new[] { 1, 3, 5, 6 }, 2); //1
            SearchInsert(new[] { 1, 3, 5, 6 }, 7); //4
        }

        public static int SearchInsert(int[] nums, int target)
        {
            var low = 0;
            var high = nums.Length;

            while (low < high)
            {
                var mid = low + (high - low) / 2;
                if (nums[mid] >= target)
                    high = mid;
                else
                    low = mid + 1;
            }

            return low;
        }
    }
}
