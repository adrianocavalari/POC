using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Mosh
/// </summary>
namespace POCConsole.Course.DSA
{
    public class AvlTree
    {
        AvlNode root;

        public static void Exec()
        {
            var avlTree = new AvlTree();

            avlTree.Insert(30);
            avlTree.Insert(10);
            avlTree.Insert(20);
        }

        private class AvlNode
        {
            public int val;
            public int height;
            public AvlNode left;
            public AvlNode right;

            public AvlNode(int val)
            {
                this.val = val;
            }

            public override string ToString()
            {
                return $"Value= {this.val}";
            }
        }

        public void Insert(int val)
        {
            root = Insert(root, val);
        }

        private AvlNode Insert(AvlNode root, int val)
        {
            if (root == null)
                return new AvlNode(val);

            if (val < root.val)
                root.left = Insert(root.left, val);
            else
                root.right = Insert(root.right, val);

            SetHeight(root);

            return Balance(root);
        }

        private AvlNode Balance(AvlNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.left) < 0)
                {
                    root.left = LeftRotate(root.left);
                }
                return RightRotate(root);
            }
            else if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.right) > 0)
                {
                    root.right = RightRotate(root.right);
                }
                return LeftRotate(root);
            }

            return root;
        }

        private AvlNode LeftRotate(AvlNode root)
        {
            var newRoot = root.right;
            root.right = newRoot.left;
            newRoot.left = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private AvlNode RightRotate(AvlNode root)
        {
            var newRoot = root.left;
            root.left = newRoot.right;
            newRoot.right = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private bool IsLeftHeavy(AvlNode root)
        {
            return BalanceFactor(root) > 1;
        }

        private bool IsRightHeavy(AvlNode root)
        {
            return BalanceFactor(root) < -1;
        }

        private int BalanceFactor(AvlNode root)
        {
            return GetNodeHeight(root.left) - GetNodeHeight(root.right);

        }

        private int GetNodeHeight(AvlNode node)
        {
            return node == null ? -1 : node.height;
        }

        private void SetHeight(AvlNode root)
        {
            root.height = Math.Max(
                            GetNodeHeight(root.left),
                            GetNodeHeight(root.right)) + 1;
        }
    }
}
