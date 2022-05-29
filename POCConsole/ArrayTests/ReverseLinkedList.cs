namespace POCConsole.ArrayTests
{
    public class ReverseLinkedList
    {
        public static void Exec()
        {
            LinkedList<int> list = new();

            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            list.AddLast(50);
            //Reverse(list);

            var ret = FindKths(list, -1);
        }

        static void Reverse(LinkedList<int> list)
        {
            if (list.First == null)
            {
                return;
            }

            var head = list.First;
            while (head.Next != null)
            {
                var next = head.Next;
                list.Remove(next);
                list.AddFirst(next.Value);
            }
        }

        static int FindKths(LinkedList<int> list, int k)
        {
            if (list.Count == 0 
                || list.First == null 
                || k > list.Count 
                || k <= 0)
            {
                return -1;
            }

            var head = list.First;
            var kth = list.First;

            for (int i = 0; i < k - 1; i++)
            {
                kth = kth.Next;
            }

            while (kth != list.Last)
            {
                head = head.Next;
                kth = kth.Next;
            }

            return head.Value;
        }
    }
}
