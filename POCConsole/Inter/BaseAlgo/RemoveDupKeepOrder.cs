using Shouldly;

namespace POCConsole.Inter.BaseAlgo
{
    public class RemoveDupKeepOrder
    {
        public static void Exec()
        {
            Test(new[] { 1, 1, 2 }, new[] { 1, 2 });
            Test(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new[] { 0, 1, 2, 3, 4 });
        }

        public static void Test(int[] nums, int[] expectedNums)
        {
            int k = RemoveDuplicates(nums); ; // Calls your implementation

            k.ShouldBe(expectedNums.Length);
            for (int i = 0; i < k; i++)
            {
                nums[i].ShouldBe(expectedNums[i]);
            }
        }

        // Function to find the next permutation
        // of the given integer array
        public static int RemoveDuplicates(int[] nums)
        {
            var count = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    count++;
                else
                    nums[i - count] = nums[i];
            }

            return nums.Length - count;
        }
    }
}
