namespace POCConsole
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int key)
        {
            this.data = key;
            this.left = null;
            this.right = null;
        }
    }

    public class GFG
    {
        // Function to Build Tree
        public Node buildTree(string str)
        {
            // Corner Case
            if (str.Length == 0 || str[0] == 'N')
                return null;

            // Creating vector of strings from input
            // string after spliting by space
            var ip = str.Split(' ');



            Node root = new Node(int.Parse(ip[0]));


            // Push the root to the queue
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            // Starting from the second element
            int i = 1;
            while (queue.Count != 0 && i < ip.Length)
            {

                // Get and remove the front of the queue
                Node currNode = queue.Peek();
                queue.Dequeue();

                // Get the current node's value from the string
                string currVal = ip[i];

                // If the left child is not null
                if (currVal != "N")
                {

                    // Create the left child for the current node
                    currNode.left = new Node(int.Parse(currVal));

                    // Push it to the queue
                    queue.Enqueue(currNode.left);
                }

                // For the right child
                i++;
                if (i >= ip.Length)
                    break;
                currVal = ip[i];

                // If the right child is not null
                if (currVal != "N")
                {

                    // Create the right child for the current node
                    currNode.right = new Node(int.Parse(currVal));

                    // Push it to the queue
                    queue.Enqueue(currNode.right);
                }
                i++;
            }

            return root;
        }

        void inorder(Node root)
        {
            if (root == null) return;
            inorder(root.left);
            Console.Write(root.data + " ");
            inorder(root.right);
        }

        //static void Main(string[] args)
        //{
        //    int testcases;// Taking testcase as input
        //    testcases = Convert.ToInt32(Console.ReadLine());
        //    while (testcases-- > 0)// Looping through all testcases
        //    {
        //        var gfg = new GFG();
        //        var str = Console.ReadLine().Trim();
        //        var root = gfg.buildTree(str);
        //        Solution obj = new Solution();
        //        var res = obj.isBST(root);
        //        Console.WriteLine(res ? 1 : 0);
        //    }

        //}
    }


    //User function Template for C#

    /*  A binary tree Node
        class Node
        {
            public int data;
            public Node left;
            public Node right;

            public Node(int key)
            {
                this.data = key;
                this.left = null;
                this.right = null;
            }
        }
    */

    public class SolutionBST
    {

        //Function to check whether a Binary Tree is BST or not.
        public bool isBST(Node root)
        {
            return isBST(root, null, null);
        }

        public bool isBST(Node root, Node max = null, Node min = null)
        {
            if (root == null)
                return true;

            Console.WriteLine($"root: {root.data} - max: {max?.data} - min: {min?.data}");

            if (max != null && max.data > root.data)
                return false;

            if (min != null && min.data < root.data)
                return false;

            return isBST(root.left, max, root) && isBST(root.right, root, min);
        }
    }
}
