public class RangeTests
{
    public static void Exec()
    {
        RangeList();

        Console.Read();
    }

    private static void RangeArray()
    {
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // array[new Range(2, new Index(3, fromEnd: true))]
        array[2..^3].ToStringJoin();

        array[..3].ToStringJoin();
        // array[Range.EndAt(new Index(3, fromEnd: true))]
        array[..^3].ToStringJoin();
        // array[Range.EndAt(new Index(1, fromEnd: true))]
        array[..^1].ToStringJoin();
        // array[Range.StartAt(2)]
        array[2..].ToStringJoin();
        // array[Range.All]
        array[..].ToStringJoin();
    }

    private static void RangeList()
    {
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToList();
        array.GetRange(2, 3).ToStringJoin();
        array.GetRange(0, 3).ToStringJoin();
    }
}
