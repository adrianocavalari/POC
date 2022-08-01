namespace POCConsole.Inter
{
    //https://hackernoon.com/the-ultimate-strategy-to-preparing-for-the-coding-interview-yxts3zbg
    //https://www.geeksforgeeks.org/two-pointers-technique/?ref=gcse
    //TODO - NOT WORKING

    public class Subsets
    {
        public static void Exec()
        {
            List<List<int>> result = Subsets.FindSubsets(new int[] { 1, 3 });
            Console.WriteLine("Here is the list of subsets: " + result);

            result = Subsets.FindSubsets(new int[] { 1, 5, 3 });
            Console.WriteLine("Here is the list of subsets: " + result);
        }

        public static List<List<int>> FindSubsets(int[] nums)
        {
            var subsets = new List<List<int>>();

            subsets.Add(new List<int>());

            for (int i = 0; i < nums.Length; i++)
            {
                var n = subsets.Count;

                for (int j = 0; j < n; j++)
                {
                    var set = new List<int>(subsets[i]);
                    set.Add(nums[i]);
                    subsets.Add(set);
                }

            }

            return subsets;
        }
    }
}
