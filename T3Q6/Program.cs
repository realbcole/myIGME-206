using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3Q6
{
    //Class: Program
    //Author: Brandon Cole
    //Purpose: Make btree with provided numbers, read them into list, make balanced btree with list
    //Restrictions: None
    class Program
    {


        public static List<int> nodeList = new List<int>();

        //Method: Main
        //Purpose: Make btree with provided numbers, read them into list, make balanced btree with list
        //Restrictions: None
        static void Main(string[] args)
        {
            BTree node = null;
            BTree root = null;
            node = new BTree(1, null);
            root = node;
            node = new BTree(5, root);
            node = new BTree(15, root);
            node = new BTree(20, root);
            node = new BTree(21, root);
            node = new BTree(22, root);
            node = new BTree(23, root);
            node = new BTree(24, root);
            node = new BTree(25, root);
            node = new BTree(30, root);
            node = new BTree(35, root);
            node = new BTree(37, root);
            node = new BTree(40, root);
            node = new BTree(55, root);
            node = new BTree(60, root);
            
            BTree.TraverseAscending(root);

            BTree root2 = null;
            int min = 0;
            int max = nodeList.Count - 1;

            int mid = (min + max) / 2;
            root2 = new BTree(nodeList[mid], null); // root of balanced tree
            root2.ltChild = ListToTree(min, mid - 1, root2);
            root2.gteChild = ListToTree(mid + 1, max, root2);

        }

        static BTree ListToTree(int min, int max, BTree root)
        {
            if (min > max)
            {
                return null;
            }

            int mid = (min + max) / 2;
            int i = 0;
            BTree node = new BTree(nodeList[mid], root);
            
            node.ltChild = ListToTree(min, mid - 1, root);
            node.gteChild = ListToTree(mid + 1, max, root);

            return node;
        }
    }


    public class BTree
    {
        //////////////////////////////////////////////////////////
        ///  The most important 3 fields of any Binary Search Tree

        // the "less than" branch off of this node
        public BTree ltChild;

        // the "greater than or equal to" branch off of this node
        public BTree gteChild;

        // the data contained in this node
        public object data;
        //////////////////////////////////////////////////////////


        // a boolean to indicate if this is actual data or seed data to prime the tree
        public bool isData;



        //////////////////////////////////////////////////////////
        // overload all operators to compare BTree nodes by int or string data
        public static bool operator ==(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data == (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data == (string)b.data);
                }
            }
            catch
            {
                returnVal = (a == (object)b);
            }

            return (returnVal);
        }

        public static bool operator !=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data != (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data != (string)b.data);
                }
            }
            catch
            {
                returnVal = (a != (object)b);
            }

            return (returnVal);
        }

        public static bool operator <(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data < (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) < 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data > (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) > 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data >= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) >= 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator <=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data <= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) <= 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        // The constructor which will add the new node to an existing tree
        // if a non-null root is passed in
        // isData defaults to true, but can be set to false if seed data is being added to prime the tree
        public BTree(object nData, BTree root, bool isData = true)
        {
            this.ltChild = null;
            this.gteChild = null;
            this.data = nData;
            this.isData = isData;

            // if a tree exists to add this node to
            if (root != null)
            {
                AddChildNode(this, root);
            }
        }
        //////////////////////////////////////////////////////////
        ///
          //////////////////////////////////////////////////////////
        /// Recursive AddChildNode method adds BTree nodes to an existing tree
        public static void AddChildNode(BTree newNode, BTree treeNode)
        {
            // if the new node >= the tree node (use the operator overrides)
            if (newNode >= treeNode)
            {
                // if there is not a child node greater than this tree node (ie. gteChild == null)
                if (treeNode.gteChild == null)
                {
                    // set this node's "greater than or equal to" child to this new node
                    treeNode.gteChild = newNode;
                }
                else
                {
                    // otherwise recursively add the new node to the "greater than or equal to" branch
                    AddChildNode(newNode, treeNode.gteChild);
                }
            }
            else
            {
                // the new node < this tree node
                // if there is not a child node less than this tree node (ie. ltChild == null)
                if (treeNode.ltChild == null)
                {
                    // set this node's "less than" child to this new node
                    treeNode.ltChild = newNode;
                }
                else
                {
                    // otherwise recursively add the new node to the "less than" branch
                    AddChildNode(newNode, treeNode.ltChild);
                }
            }
        }
        //////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////
        // Delete a node from a tree or branch
        public static BTree DeleteNode(BTree nodeToDelete, BTree treeNode)
        {
            // base case: we reached the end of the branch
            if (treeNode == null)
            {
                return treeNode;
            }

            // traverse the tree to find the target node
            if (nodeToDelete < treeNode)
            {
                treeNode.ltChild = DeleteNode(nodeToDelete, treeNode.ltChild);
            }
            else if (nodeToDelete > treeNode)
            {
                treeNode.gteChild = DeleteNode(nodeToDelete, treeNode.gteChild);
            }
            else
            {
                // this is the node to be deleted  

                // case #1: treeNode has no children
                // case #2: treeNode has one child
                // set treeNode to it's non-null child (if there is one)
                if (treeNode.ltChild == null)
                {
                    return treeNode.gteChild;
                }
                else if (treeNode.gteChild == null)
                {
                    return treeNode.ltChild;
                }

                // case #3: treeNode has two children
                // Get the in-order successor (smallest value  
                // in the "greater than or equal to" branch)  

                // step to the next greater value
                BTree nextValNode = treeNode.gteChild;

                // while not at the end of the branch
                while (nextValNode != null)
                {
                    // replace this "deleted" node with the next sequential data value
                    treeNode.data = nextValNode.data;

                    // walk to next lower value
                    nextValNode = nextValNode.ltChild;
                }

                // delete the in-order successor (which was copied to the "deleted" node)
                nodeToDelete.data = treeNode.data;
                DeleteNode(nodeToDelete, treeNode.gteChild);
            }

            return treeNode;
        }


        //////////////////////////////////////////////////////////
        // Print the tree in ascending order
        public static void TraverseAscending(BTree node)
        {
            if (node != null)
            {
                // handle "less than" children
                TraverseAscending(node.ltChild);

                //handle current node
                Program.nodeList.Add((int)node.data);
                
                // handle "greater than or equal to children"
                TraverseAscending(node.gteChild);
            }
        }

    }
}
