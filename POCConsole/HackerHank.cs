class Solution
{
    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null!;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null!;
            this.tail = null!;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
    {
        while (node != null)
        {
            Console.Write(node.data);

            node = node.next;

            if (node != null)
            {
                Console.Write(sep);
            }
        }
    }

    static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        if (head1 == null)
        {
            return head2;
        }

        if (head2 == null)
        {
            return head1;
        }

        Console.WriteLine($"Datas: {head1.data} - {head2.data}");

        SinglyLinkedListNode next1;
        SinglyLinkedListNode next2;

        if (head2.data > head1.data)
        {
            next1 = head1.next;
            next2 = head2;
        }
        else
        {
            next1 = head1;
            next2 = head2.next;
        }

        next1.next = mergeLists(next1, next2);
        return next1;
    }

    public static void Main(string[] args)
    {
        int tests = 1;

        for (int testsItr = 0; testsItr < tests; testsItr++)
        {
            SinglyLinkedList llist1 = new SinglyLinkedList();


            llist1.InsertNode(1);
            llist1.InsertNode(2);
            llist1.InsertNode(3);

            SinglyLinkedList llist2 = new SinglyLinkedList();

            llist2.InsertNode(3);
            llist2.InsertNode(4);

            SinglyLinkedListNode llist3 = mergeLists(llist1.head, llist2.head);

            PrintSinglyLinkedList(llist3, " ");
        }
    }
}
