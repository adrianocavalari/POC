using Shouldly;

namespace POCConsole.Array
{
    public class TestCode
    {
        public static void Exec()
        {
            //var array = new[] { -1, 3, 0, 0, 0, 0, 0 };

            //Merge(array, 2, new[] { 0, 0, 1, 2, 3 }, 5);


            var array = new[] { 3, 2, -1, 1, 5 };
            var array2 = new[] { 7, 8, 9, 11, 12 };
            var array3 = new[] { 3, 1, 4, -1 };
            var array4 = new[] { 3, -3, 6, 3 };
            var array5 = new[] { -10, -3, -100, -1000, -239, 1 };
            var array6 = new[] { 3, 1, 4, 5 };

            //var a = FirstMissingPositive(array);
            //var a2 = FirstMissingPositive(array2);
            //var a3 = FirstMissingPositive(array3);
            //var a4 = FirstMissingPositive(array4);
            //var a = FirstMissingPositive(array5);
            var a = FirstMissingPositiveCyclicSort(array6);

            //a.ShouldBe(2);
            //a2.ShouldBe(1);
        }

        static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // get positions
            int pos = m + n - 1;

            m--;
            n--;

            while (m >= 0 || n >= 0)
            {
                if (n < 0   // second arr is done
                        || (m >= 0 && nums1[m] > nums2[n]))
                {   // first arr is not done yet
                    nums1[pos--] = nums1[m--];
                }
                else
                {
                    nums1[pos--] = nums2[n--];
                }
            }
        }

        static int FirstMissingPositive(int[] nums)
        {
            var n = nums.Length;
            for (var i = 0; i < n; i++)
            {
                if (nums[i] <= 0 || nums[i] > n)
                {
                    nums[i] = n + 1;
                }
            }

            for (var i = 0; i < n; i++)
            {
                var j = Math.Abs(nums[i]) - 1;
                if (j < n && nums[j] > 0)
                {
                    nums[j] = Math.Abs(nums[j]) * -1;
                }
            }

            for (var i = 0; i < n; i++)
            {
                if (nums[i] > 0)
                {
                    return i + 1;
                }
            }

            return n + 1;
        }

        static int FirstMissingPositiveCyclicSort(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] > 0 
                    && nums[i] <= nums.Length 
                    && nums[i] != nums[nums[i] - 1])
                {
                    Swap(nums, i, nums[i] - 1);
                }
                else
                {
                    i++;
                }
            }
            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return nums.Length + 1;
        }

        static void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
