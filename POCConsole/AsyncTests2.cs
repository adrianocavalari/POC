using System.Diagnostics;

public class AsyncTests2
{
    public async Task Exec()
    {
        var watch = Stopwatch.StartNew();
        var task1 = await Task1();
        var task2 = await Task2();
        var task3 = await Task3();

        Console.WriteLine($"Done in {watch.ElapsedMilliseconds}ms");

        Console.WriteLine($"{task1} - {task2} - {task3}");
    }

    public async Task ExecTaskAfter()
    {
        var watch = Stopwatch.StartNew();
        var task1Task = Task1();
        var task2Task = Task2();
        var task3Task = Task3();

        var task1 = await task1Task;
        var task2 = await task2Task;
        var task3 = await task3Task;

        Console.WriteLine($"Done in {watch.ElapsedMilliseconds}ms");

        Console.WriteLine($"{task1} - {task2} - {task3}");
    }

    public async Task ExecTaskWaitAll()
    {
        var watch = Stopwatch.StartNew();
        var task1Task = Task1();
        var task2Task = Task2();
        var task3Task = Task3();

        Task.WaitAll(task1Task, task2Task, task2Task);

        var task1 = await task1Task;
        var task2 = await task2Task;
        var task3 = await task3Task;

        Console.WriteLine($"Done in {watch.ElapsedMilliseconds}ms");

        Console.WriteLine($"{task1} - {task2} - {task3}");
    }

    public async Task ExecTaskWhenAll()
    {
        var watch = Stopwatch.StartNew();
        var task1Task = Task1();
        var task2Task = Task2();
        var task3Task = Task3();

        await Task.WhenAll(task1Task, task2Task, task2Task);

        var task1 = await task1Task;
        var task2 = await task2Task;
        var task3 = await task3Task;

        Console.WriteLine($"Done in {watch.ElapsedMilliseconds}ms");

        Console.WriteLine($"{task1} - {task2} - {task3}");
    }

    public async Task ExecTaskWhenAllReturn()
    {
        var watch = Stopwatch.StartNew();
        var task1Task = Task1();
        var task2Task = Task2();
        var task3Task = Task3();

        var newTask = await Task.WhenAll(task1Task, task2Task, task3Task);

        Console.WriteLine($"Done in {watch.ElapsedMilliseconds}ms");

        Console.WriteLine($"{newTask[0]} - {newTask[1]} - {newTask[2]}");
    }

    private async Task<string> Task1()
    {
        await Task.Delay(1000);
        return "1";
    }

    private async Task<string> Task2()
    {
        //throw new Exception("Error Task2");
        await Task.Delay(1000);
        return "2";
    }

    private async Task<string> Task3()
    {
        //throw new Exception("Error Task3");
        await Task.Delay(1000);
        return "3";
    }

    public class MyClass
    {

    }
}
