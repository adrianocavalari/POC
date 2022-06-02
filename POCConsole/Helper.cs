using System.Linq;

internal static class HelperExtensions
{
    internal static string Dump(this string message)
    {
        Console.WriteLine(message);
        return message;
    }

    //internal static string Dump(this int message)
    //{
    //    Console.WriteLine(message);
    //    return message.ToString();
    //}

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

    internal static object Dump(this object message)
    {
        if (message == null)
            return string.Empty;

        Console.WriteLine(message.ToString());
        return message;
    }

    internal static object Dump(this object message, string extra)
    {
        if (message == null)
            return string.Empty;

        Console.WriteLine($"{extra}{message}");
        return message;
    }

    internal static Array DumpList(this Array list)
    {
        if (list == null)
            return new object[0];

        for (int i = 0; i < list.Length; i++)
        {
            var last = i == list.Length - 1 ? "" : ", ";
            Console.Write($"{list.GetValue(i)}{last} ");
        }
        Console.WriteLine();

        return list;
    }
}