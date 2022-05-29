namespace POCConsole.ArrayTests
{
    public class MyQueue
    {
        public static void Exec()
        {
            Queue<int> list = new();

            list.Enqueue(10);
            list.Enqueue(20);
            list.Enqueue(30);
            list.Enqueue(40);
            list.Enqueue(50);
            Reverse(list);

            Console.WriteLine(String.Join(", ", list));
        }

        static void Reverse(Queue<int> list)
        {
            if (list.Count == 0)
            {
                return;
            }

            var stack = new Stack<int>();

            while (list.Count != 0)
            {
                stack.Push(list.Dequeue());
            }

            while (stack.Count != 0)
            {
                list.Enqueue(stack.Pop());
            }
        }
    }
}
