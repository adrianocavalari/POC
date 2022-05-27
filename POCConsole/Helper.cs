internal static class HelperExtensions
{
    internal static string Dump(this string message)
    {
        Console.WriteLine(message);
        return message;
    }

    internal static string Dump(this int message)
    {
        Console.WriteLine(message);
        return message.ToString();
    }

    internal static string ToStringJoin(this int[] list)
    {
        var result = string.Join(", ", list);
        Console.WriteLine(result);
        return result;
    }

    internal static string ToStringJoin(this List<int> list)
    {
        var result = string.Join(", ", list);
        Console.WriteLine(result);
        return result;
    }

    internal static void Swap(this int[] nums, int i, int j)
    {
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}