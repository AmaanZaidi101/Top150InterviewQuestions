using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    
 //Definition for a binary tree node.
 public class TreeNode {
     public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

    
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;
        public Node random;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}


    public class TreeFunctions
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {

            if (root == null)
                return new List<List<int>>().ToArray();

            int count = 1;
            List<List<int>> list = new List<List<int>>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            bool leftToRight = true;

            while (queue.Count > 0)
            {
                int c = 0;
                List<int> l = new List<int>();
                Stack<int> stack = new Stack<int>();

                while (count > 0 && queue.Count > 0)
                {
                    var node = queue.Dequeue();

                    if (leftToRight)
                        l.Add(node.val);
                    else
                        stack.Push(node.val);

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                        c++;
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                        c++;
                    }
                    count--;
                }
                count = c;

                if (leftToRight)
                    list.Add(l);
                else
                    list.Add(stack.ToList());

                leftToRight = !leftToRight;
            }

            return list.ToArray();
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Build(preorder, inorder);
        }

        private TreeNode Build(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0 || inorder.Length == 0)
                return null;
            var root = new TreeNode(preorder[0]); //first element in preorder is always the root

            int midIndex = Array.IndexOf(inorder, preorder[0]); //divides into left and right subtree
            int numElementsLeft = midIndex; //how many elements in left subtree - use them in preorder next
            int numElementsRight = preorder.Length - midIndex - 1; //how many elements in right subtree- use them in next preorder

            var leftPreOrder = new ArraySegment<int>(preorder, 1, numElementsLeft).ToArray(); //new preorder array excludes current root
            var rightPreOrder = new ArraySegment<int>(preorder, midIndex + 1, numElementsRight).ToArray();

            var leftInOrder = new ArraySegment<int>(inorder, 0, numElementsLeft).ToArray(); // left subtree
            var rightInOrder = new ArraySegment<int>(inorder, midIndex + 1, numElementsRight).ToArray(); //right subtree 

            root.left = Build(leftPreOrder, leftInOrder);
            root.right = Build(rightPreOrder, rightInOrder);

            return root;
        }
        public Node Connect(Node root)
        {
            if (root == null)
                return null;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            int height = 0;

            while (queue.Count > 0)
            {
                var count = Math.Pow(2, height);
                Node prev = null;
                while (count > 0)
                {
                    var node = queue.Dequeue();
                    if (prev != null)
                        prev.next = node;
                    prev = node;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                    count--;
                }
                prev.next = null;
                height++;
            }
            return root;
        }

        public int KthSmallest(TreeNode root, int k)
        {
            List<int> list = new List<int>();
            InOrderTraversal(root, list);
            return list.ElementAt(k - 1);
        }
        //can do iteratively using stack
        private void InOrderTraversal(TreeNode root, List<int> list)
        {
            if (root == null)
                return;
            InOrderTraversal(root.left, list);
            list.Add(root.val);
            InOrderTraversal(root.right, list);
        }
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return FindLCA(root, p, q);
            //works for bst not binary tree
            //var tmp = root;
            //while(tmp != null)
            //{
            //    if (p.val > tmp.val && q.val > tmp.val)
            //        tmp = tmp.right;
            //    else if (p.val < tmp.val && q.val < tmp.val)
            //        tmp = tmp.left;
            //    else //either this node is equal to p or q or p and q split at this node, in both cases this will be lca
            //        return tmp;
            //}
            //return root;
        }

        /*
         * if any node has p or q it will return itself, otherwise it will go left and right
         * if it receives not null from left and right then it is the LCA and will propogate itself up to the parent
         * if it recieves one not null it will propogate that up
         * otherwise it will propogate null upwards
        */
        private TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            if (root.val == p.val || root.val == q.val)
                return root;

            var left = FindLCA(root.left, p, q);
            var right = FindLCA(root.right, p, q);

            if (left != null && right != null)
                return root;
            if (left != null)
                return left;
            if (right != null)
                return right;
            return null;
        }

        public TreeNode CreateTreeForInorderSuccessor()
        {
            TreeNode root = new TreeNode(15)
            {
                left = new TreeNode(10)
                {
                    left = new TreeNode(8)
                    {
                        left = new TreeNode(6)
                    },
                    right = new TreeNode(12)
                    {
                        left = new TreeNode(11)
                    }
                },
                right = new TreeNode(20)
                {
                    left = new TreeNode(17)
                    {
                        left = new TreeNode(16)
                    },
                    right = new TreeNode(25)
                    {
                        right = new TreeNode(27)
                    }
                }
            };
            return root;
        }

        public TreeNode InOrderSuccessor(TreeNode root, TreeNode p)
        {
            var node = root;
            TreeNode parent = null;
            bool isLeftNode = false;
            TreeNode closestAncestor = null;
            while (node != null)
            {
                if (node.val > p.val)
                {
                    closestAncestor = node;
                    node = node.left;
                }
                else if (node.val < p.val)
                    node = node.right;
                else
                {
                    var tmp = node.right;
                    //if right subtree exists then return smallest element in right subtree
                    if (tmp != null)
                    {
                        while (tmp.left != null)
                            tmp = tmp.left;
                        return tmp;
                    }
                    else//return the closest ancestor for which node is in left subtree
                        return closestAncestor;
                }
            }
            return null;
        }
    }

    public class Codec
    {
        public TreeNode CreateTree()
        {
            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
                {
                    left = new TreeNode(4)
                    {
                        left = new TreeNode(6),
                        right = new TreeNode(7)
                    },
                    right = new TreeNode(5)
                }
            };
            return root;
        }

        


        //DFS
        public string serialize(TreeNode root)
        {
            if (root == null)
                return string.Empty;
            List<string> list = new List<string>();
            PreOrderTraversal(root, list);
            return string.Join(",", list);
        }

        private void PreOrderTraversal(TreeNode root, List<string> list)
        {
            if (root == null)
                list.Add("N");
            else
            {
                list.Add($"{root.val}");
                PreOrderTraversal(root.left, list);
                PreOrderTraversal(root.right, list);
            }
        }
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return null;
            var nodes = data.Split(",").ToList();
            int index = 0;
            return PreOrderTraversalDeserialize(nodes, ref index);
        }

        private TreeNode PreOrderTraversalDeserialize(List<string> nodes, ref int index)
        {
            if(index < nodes.Count)
            {
                if (nodes[index] == "N")
                {
                    index += 1;
                    return null;
                }
                var node = new TreeNode(int.Parse(nodes[index]));
                index += 1;
                node.left = PreOrderTraversalDeserialize(nodes, ref index);
                node.right = PreOrderTraversalDeserialize(nodes, ref index);

                return node;
            }
            return null;
        }

        // Encodes a tree to a single string.

        ////BFS
        //public string serialize(TreeNode root)
        //{
        //    if (root == null)
        //        return string.Empty;

        //    List<string> list = new List<string>();

        //    Queue<TreeNode> queue = new Queue<TreeNode>();
        //    queue.Enqueue(root);
        //    while(queue.Count > 0)
        //    {
        //        var node = queue.Dequeue();
        //        if (node == null)
        //            list.Add("N");
        //        else
        //        {
        //            list.Add($"{node.val}");
        //            queue.Enqueue(node.left);
        //            queue.Enqueue(node.right);
        //        }
        //    }

        //    return string.Join(",",list);
        //}

        //// Decodes your encoded data to tree.
        //public TreeNode deserialize(string data)
        //{
        //    if (string.IsNullOrWhiteSpace(data))
        //        return null;
        //    string[] nodes = data.Split(",");
        //    var root = new TreeNode(int.Parse(nodes[0]));
        //    Queue<TreeNode> queue = new Queue<TreeNode>();
        //    queue.Enqueue(root);
        //    int i = 1;
        //    while(i < nodes.Length)
        //    {
        //        var node = queue.Dequeue();
        //        if(nodes[i] != "N")
        //        {
        //            node.left = new TreeNode(int.Parse(nodes[i]));
        //            queue.Enqueue(node.left);
        //        }
        //        i++;
        //        if(nodes[i] != "N")
        //        {
        //            node.right = new TreeNode(int.Parse(nodes[i]));
        //            queue.Enqueue(node.right);
        //        }
        //        i++;
        //    }
        //    return root;
        //}

        private void ParseNode(TreeNode tmp, string[] dataSet, int parent)
        {
            int left = parent * 2 + 1;
            int right = parent * 2 + 2;
            if (left < dataSet.Length)
            {
                if (dataSet[left] == "null")
                    tmp.left = null;
                else
                {
                    tmp.left = new TreeNode(int.Parse(dataSet[left]));
                    ParseNode(tmp.left, dataSet, left);
                }
            }
            if (right < dataSet.Length)
            {
                if (dataSet[right] == "null")
                    tmp.right = null;
                else
                {
                    tmp.right = new TreeNode(int.Parse(dataSet[right]));
                    ParseNode(tmp.right, dataSet, right);
                }
            }
        }

        
    }
}
