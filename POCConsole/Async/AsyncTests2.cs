using System.Diagnostics;

public class AsyncTests2
{
    const bool throwError = true;

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

    public async Task ExecTaskWhenAllExceptions()
    {
        var watch = Stopwatch.StartNew();
        var task1Task = Task1();
        var task2Task = Task2();
        var task3Task = Task3();
        var newTask = Task.WhenAll(task1Task, task2Task, task3Task);

        try
        {
            var result = await newTask;
            Console.WriteLine($"Done in {watch.ElapsedMilliseconds}ms");

            Console.WriteLine($"{result[0]} - {result[1]} - {result[2]}");

        }
        catch (Exception e)
        {
            throw newTask.Exception ?? e;
        }
    }

    public async Task ExecTaskWhenAllExceptionsClass()
    {
        var watch = Stopwatch.StartNew();
        var task1Task = Task1();
        var task2Task = Task2();
        var task3Task = Task3();
        var newTask = TaskEx.WhenAll(task1Task, task2Task, task3Task);

        try
        {
            var result = await newTask;
            Console.WriteLine($"Done in {watch.ElapsedMilliseconds}ms");

            Console.WriteLine($"{result[0]} - {result[1]} - {result[2]}");

        }
        catch (Exception e)
        {
            throw newTask.Exception ?? e;
        }
    }

#pragma warning disable CS0162 // Unreachable code detected
    private async Task<string> Task1()
    {
        if (throwError)
            throw new Exception("Error Task1");

        await Task.Delay(1000);
        return "1";
    }

    private async Task<string> Task2()
    {
        if (throwError)
            throw new Exception("Error Task2");

        await Task.Delay(1000);
        return "2";
    }

    private async Task<string> Task3()
    {
        if (throwError)
            throw new Exception("Error Task3");

        await Task.Delay(1000);
        return "3";
    }
#pragma warning restore CS0162 // Unreachable code detected

    public class TaskEx
    {
        public static async Task<T[]> WhenAll<T>(params Task<T>[] tasks)
        {
            var allTasks = Task.WhenAll(tasks);

            try
            {
                return await allTasks;
            }
            catch (Exception e)
            {
                throw allTasks.Exception ?? e;
            }
        }
    }
}
