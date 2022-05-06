using System.Collections;

public class StaticTestsExec
{
    public static void Exec()
    {
        //Log.Instance = new DebugWriteLineLogger();
        //Log.Message("Logged");

        //Log.MessageDelegate = Console.Write;

        //Log.MessageDelegate("Logged");

        //Log.MessageAction = Console.Write;

        //Log.MessageAction("Logged");

        Log2.Message("Logged");
    }
}

public static class Log2
{
    static Log2()
    {

    }
    public static void Message(string message) { Console.Write(message); }
}

public static class Log
{
    public delegate void MessageLogger(string message);
    public static Logger? Instance { get; set; }

    public static MessageLogger MessageDelegate { get; set; }

    public static Action<string> MessageAction { get; set; }

    public static void Message(string message) { Instance?.Message(message); }
}

public abstract class Logger
{
    public abstract void Message(string message);
}
public class DebugWriteLineLogger : Logger
{
    public override void Message(string message)
    {
        Console.Write(message);
    }
}

public class StaticTests : TestBase
{
    public string SomeProp { get; set; }

    static StaticTests()
    {

    }

    public StaticTests(string SomeParam)
        : base("")
    {
        SomeProp = "";
    }

    public override string SomeParam(string SomeParam)
    {
        return SomeParam2(SomeParam);
    }
}