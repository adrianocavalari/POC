namespace POCConsole.ArrayTests
{
    public class StackTests
    {
        public static void Exec()
        {
            Console.WriteLine($"abcd - reversed - {Reverse("abcd")}");

            var balanced = "()";

            Console.WriteLine($"{balanced} - reversed - {IsBalanced(balanced)}");

            var balanced2 = "(wefewfewf)";

            Console.WriteLine($"{balanced2} - reversed - {IsBalanced(balanced2)}");

            var balanced3 = "([wefewfewf)";

            Console.WriteLine($"{balanced3} - reversed - {IsBalanced(balanced3)}");

            var balanced4 = "([wefewfewf])";

            Console.WriteLine($"{balanced4} - reversed - {IsBalanced(balanced4)}");


            MyStack myStack = new MyStack();

            myStack.Push(1);
            myStack.Push(2);

            myStack.Pop();

            var a = myStack.Peek();

            var b = myStack.IsEmpty();
        }

        static string Reverse(string str)
        {
            Stack<char> stack = new();

            foreach (var item in str)
            {
                stack.Push(item);
            }

            if (stack.Count == 0)
            {
                return string.Empty;
            }

            var reversed = "";
            while (stack.Count != 0)
            {
                reversed = $"{reversed}{stack.Pop()}";
            }

            return reversed;
        }

        static string IsBalanced(string text)
        {
            Stack<char> stack = new();
            var elements = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
           };

            foreach (var item in text)
            {
                if (elements.ContainsKey(item))
                {
                    stack.Push(elements[item]);
                }
                else if (item == stack.Peek())
                {
                    if (stack.Count != 0)
                        stack.Pop();
                }
            }

            return stack.Count == 0 ? "Balanced" : "Unbalanced";
        }
    }

    public class MyStack
    {
        private int[] array = new int[0];
        private int count;

        public void Push(int value)
        {
            Array.Resize(ref array, count + 1);

            array[count++] = value;
        }

        public void Pop()
        {
            if (count > 0)
                Array.Resize(ref array, count--);
        }

        public int Peek()
        {
            if (count > 0)
                return array[count - 1];

            return 0;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }
    }
}
