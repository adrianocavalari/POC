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
}