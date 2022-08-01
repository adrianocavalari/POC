namespace POCConsole.Inter
{
    //https://hackernoon.com/the-ultimate-strategy-to-preparing-for-the-coding-interview-yxts3zbg
    //https://www.geeksforgeeks.org/two-pointers-technique/?ref=gcse

    public class TwoPointers
    {
        public static void Exec()
        {
            int[] result = Search(new int[] { 1, 2, 3, 4, 6 }, 6);
            Console.WriteLine("Pair with target sum: [" + result[0] + ", " + result[1] + "]");

            result = Search(new int[] { 2, 5, 9, 11 }, 11);
            Console.WriteLine("Pair with target sum: [" + result[0] + ", " + result[1] + "]");

            Console.ReadLine();
        }

        public static int[] Search(int[] arr, int targetSum)
        {
            var start = 0;
            var end = arr.Length - 1;

            while (start < end)
            {
                if (arr[start] + arr[end] == targetSum)
                {
                    return new[] { start, end };
                }
                else if (arr[start] + arr[end] < targetSum)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }

            return new[] { -1, -1 };
        }
    }
}
