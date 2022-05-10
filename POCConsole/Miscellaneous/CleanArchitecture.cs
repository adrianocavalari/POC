public class CleanArchitecture
{
    public static void Exec()
    {
        var application = (string? text, Func<string, bool> store) =>
        {
            return text switch
            {
                null => false,
                { Length: < 5 } => false,
                _ => store(text)
            };
        };

        var infrastructure = (string text) =>
        {
            var path = Path.Combine(Path.GetTempPath(), "my-text.txt");
            Console.WriteLine($"Storing at {path}");
            File.WriteAllText(path, text);
            return true;
        };

        var console = (Func<string, bool> store) =>
        {
            Console.WriteLine("What message do you want to store?");
            var text = Console.ReadLine();
            return application(text, store);
        };

        var result = console(infrastructure);
        Console.WriteLine($"Storing at {result}");


        Console.ReadKey();
    }

    public static void Exec2()
    {
        var application = (string? text, Func<string, bool> store) =>
        {
            return text switch
            {
                null => false,
                { Length: < 5 } => false,
                _ => store(text)
            };
        };

        var infrastructure = (string text) =>
        {
            var path = Path.Combine(Path.GetTempPath(), "my-text.txt");
            Console.WriteLine($"Storing at {path}");
            File.WriteAllText(path, text);
            return true;
        };

        var console = (Func<string, bool> store, Func<string?, Func<string, bool>, bool> app) =>
        {
            Console.WriteLine("What message do you want to store?");
            var text = Console.ReadLine();
            return app(text, store);
        };

        var result = console(infrastructure, application);
        Console.WriteLine($"Storing at {result}");

        Console.ReadKey();
    }
}
