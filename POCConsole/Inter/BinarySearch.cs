using Shouldly;

namespace POCConsole.Inter
{
    //https://hackernoon.com/the-ultimate-strategy-to-preparing-for-the-coding-interview-yxts3zbg
    //https://www.geeksforgeeks.org/binary-search/

    public class BinarySearch
    {
        public static void Exec()
        {
            //var array = FindMax(new int[] { 1, 3, 8, 12, 4, 2 });
            //var array2 = FindMax(new int[] { 3, 8, 3, 1 });
            //var arra3 = FindMax(new int[] { 1, 3, 8, 12 });
            //var arra4 = FindMax(new int[] { 10, 9, 8 });

            var arrayFindKey = FindKey(new int[] { 1, 2, 3, 4, 8, 12 }, 2);
        }

        public static int FindMax(int[] arr)
        {
            int start = 0, end = arr.Length - 1;
            while (start < end)
            {
                int mid = (start + end) / 2;
                if (arr[mid] > arr[mid + 1])
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            // at the end of the while loop, 'start == end'
            return arr[start];
        }

        public static int FindKey(int[] arr, int k)
        {
            int start = 0, end = arr.Length - 1;
            while (start < end)
            {
                int mid = (start + end) / 2;
                if (arr[mid] > k)
                {
                    end = mid;
                }
                else if (arr[mid] == k)
                {
                    return ++mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            // at the end of the while loop, 'start == end'
            return -1;
        }
    }
}
