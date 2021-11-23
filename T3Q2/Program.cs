using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3Q2
{
    //Class: Node
    //Author: Brandon Cole
    //Purpose: Node class for dijkstras shortest path algorithm
    //Restrictions: None
    public class Node : IComparable<Node>
    {
        public int curState;

        public List<Edge> neighbors = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node( int curState)
        {
            this.curState = curState;
            this.minCostToStart = int.MaxValue;
        }
        public void AddEdge(int cost, Node neighbor)
        {
            Edge e = new Edge(cost, neighbor);
            neighbors.Add(e);
        }

        public int CompareTo(Node other)
        {
            return this.minCostToStart.CompareTo(other.minCostToStart);
        }
    }
    //Class: Node
    //Author: Brandon Cole
    //Purpose: edge class for dijkstras shortest path algorithm
    //Restrictions: None
    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node neighborNode;

        public Edge( int cost, Node neighborNode)
        {
            this.cost = cost;
            this.neighborNode = neighborNode;
        }

        public int CompareTo(Edge other)
        {
            return this.cost.CompareTo(other.cost);
        }
    }
    //Class: Program
    //Author: Brandon Cole
    //Purpose: Represent graph, perform depth first search, and dijkstra's shortest path algorithm, represent graph as linked list
    //Restrictions: None
    class Program
    {
        static int[,] mGraph = new int[,] // cost
       {
                              //RED//  //DARKBLUE//  //GREY//   //LTBLUE//  //YELLOW/    //ORANGE//  //PINK//  //GREEN//
             /*RED*/        {  (-1),     (1),         (5),      (-1),        (-1),        (-1),      (-1),      (-1)  },
             /*DARKBLUE*/   {  (-1),    (-1),        (-1),      (1),         (8),         (-1),      (-1),      (-1)  },
             /*GREY*/       {  (-1),    (-1),        (-1),      (0),         (-1),        (1),       (-1),       (-1) },
             /*LTBLUE*/     {  (-1),    (1),         (0),       (-1),        (-1),        (-1),      (-1),     (-1)   },
             /*YELLOW*/     {  (-1),    (-1),        (-1),      (-1),        (-1),        (-1),      (-1),     (6)    },
             /*ORANGE*/     {  (-1),    (-1),        (-1),      (-1),        (-1),        (-1),      (1),       (-1)  },
             /*PINK*/       {  (-1),    (-1),        (-1),      (-1),        (1),         (-1),      (-1),     (-1)   },
             /*GREEN*/      {  (-1),    (-1),        (-1),      (-1),        (-1),        (-1),      (-1),      (-1)  },
       };

        static (string, int)[][] lGraph = new (string, int)[][] // (color, cost)
        {
           /*RED*/    new (string, int)[] { ("Dark Blue", 1), ("Grey", 5) }, 
           /*DKBLUE*/ new (string, int)[] { ("Light Blue", 1), ("Yellow", 8) }, 
           /*GREY*/   new (string, int)[] { ("Light Blue", 0), ("Orange", 1) }, 
           /*LTBLUE*/ new (string, int)[] { ("Dark Blue", 1), ("Grey", 0) }, 
           /*YELLOW*/ new (string, int)[] { ("Green", 6) }, 
           /*ORANGE*/ new (string, int)[] { ("Pink", 1) }, 
           /*PINK*/   new (string, int)[] { ("Yellow", 1) }, 
           /*GREEN*/  null
        };

        static int[][] neighborsGraph = new int[][] //neighbors
        {
           /*RED*/    new int[] { 1, 2 }, 
           /*DKBLUE*/ new int[] { 3, 4 }, 
           /*GREY*/   new int[] { 3, 5 }, 
           /*LTBLUE*/ new int[] { 1, 2 }, 
           /*YELLOW*/ new int[] { 7 }, 
           /*ORANGE*/ new int[] { 6 }, 
           /*PINK*/   new int[] { 4 }, 
           /*GREEN*/  null
        };

        static int[][] cGraph = new int[][] // costs
        {
           /*RED*/    new int[] { 1, 5 }, 
           /*DKBLUE*/ new int[] { 1, 8 }, 
           /*GREY*/   new int[] { 0, 1 }, 
           /*LTBLUE*/ new int[] { 1, 0 }, 
           /*YELLOW*/ new int[] { 6 }, 
           /*ORANGE*/ new int[] { 1 }, 
           /*PINK*/   new int[] { 1 }, 
           /*GREEN*/  null
        };

        static List<Node> nodeList = new List<Node>();


        ////////////////////////////////////////////////
        /// LINKED LIST VERSION OF DIGRAPH /////////////
        ////////////////////////////////////////////////
        
        static LinkedList<Node> linkedGame = new LinkedList<Node>();


        //Method: Main
        //Purpose: DFS and Dijkstra and linked list
        //Restrictions: None
        static void Main(string[] args)
        {

            // DFS 

            Console.WriteLine("Depth First Search: \n");
            int curState = 0;
            DFS(curState);

            Console.WriteLine("\nDijkstra's shortest path algorithm: \n");

            // DIJKSTRA
            Node node;
            int i = 0;
            for ( i = 0; i < lGraph.Length; i++)
            {
                node = new Node(i);
                nodeList.Add(node);
            }

            for (i = 0; i < lGraph.Length; i++)
            {
                int[] neighborsList = neighborsGraph[i];
                int[] costList = cGraph[i];
                if (neighborsList != null)
                {
                    for (int j = 0; j < neighborsList.Length; ++j)
                    {
                        nodeList[i].AddEdge(costList[j], nodeList[neighborsList[j]]);

                    }
                }

                nodeList[i].neighbors.Sort();
              
            }

            List<Node> shortestPath = GetShortestPathDijkstra();
            foreach (Node n in shortestPath)
            {
                string sState = NState2SState(n.curState);
                Console.WriteLine(sState);
            }


            // LINKED LIST

            Console.WriteLine("\nLinked List:\n");

            Node redNode = new Node(0);
            Node darkBlueNode = new Node(1);
            Node greyNode = new Node(2);
            Node lightBlueNode = new Node(3);
            Node yellowNode = new Node(4);
            Node orangeNode = new Node(5);
            Node pinkNode = new Node(6);
            Node greenNode = new Node(7);
            redNode.AddEdge(5, greyNode);
            redNode.AddEdge(1, darkBlueNode);
            darkBlueNode.AddEdge(8, yellowNode);
            darkBlueNode.AddEdge(1, lightBlueNode);
            greyNode.AddEdge(0, lightBlueNode);
            greyNode.AddEdge(1, orangeNode);
            lightBlueNode.AddEdge(1, darkBlueNode);
            lightBlueNode.AddEdge(0, greyNode);
            yellowNode.AddEdge(6, greenNode);
            orangeNode.AddEdge(1, pinkNode);
            pinkNode.AddEdge(1, yellowNode);

            linkedGame.AddLast(redNode);
            linkedGame.AddLast(darkBlueNode);
            linkedGame.AddLast(greyNode);
            linkedGame.AddLast(lightBlueNode);
            linkedGame.AddLast(yellowNode);
            linkedGame.AddLast(orangeNode);
            linkedGame.AddLast(pinkNode);
            linkedGame.AddLast(greenNode);


            foreach (Node n in linkedGame)
            {
                Console.WriteLine(NState2SState(n.curState));
            }
           
        }
        
        static public List<Node> GetShortestPathDijkstra()
        {
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(nodeList[7]);
            BuildShortestPath(shortestPath, nodeList[7]);
            shortestPath.Reverse();
            return shortestPath;
        }

        static public void BuildShortestPath(List<Node> list, Node node)
        {
            if( node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);

            BuildShortestPath(list, node.nearestToStart);
        }

        static public void DijkstraSearch()
        {
            Node start = nodeList[0];

            start.minCostToStart = 0;
            List<Node> queue = new List<Node>();

            queue.Add(start);

            do
            {
                queue.Sort();

                Node node = queue.First();

                queue.Remove(node);

                foreach (Edge neighbor in node.neighbors)
                {
                    Node childNode = neighbor.neighborNode;
                    if (childNode.visited)
                    {
                        continue;
                    }

                    if( childNode.minCostToStart == int.MaxValue || 
                        node.minCostToStart + neighbor.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + neighbor.cost;
                        childNode.nearestToStart = node;
                        if(!queue.Contains(childNode))
                        {
                            queue.Add(childNode);
                        }
                    }
                }

                node.visited = true;

                if(node == nodeList[7])
                {
                    return;
                }

            } while ( queue.Any());
        }


        //////////////////////////////////////
        /// DEPTH FIRST SEARCH //////////////
        ////////////////////////////////////
        static void DFS(int curState)
        {
            bool[] visited = new bool[lGraph.Length];

            DFSUtil(curState, ref visited);
        }

        static void DFSUtil(int curState, ref bool[] visited)
        {
            visited[curState] = true;

            string sState = NState2SState(curState);
            Console.WriteLine(sState + " ");

            int[] thisStateNeighbors = neighborsGraph[curState];
            if (thisStateNeighbors != null)
            {
                foreach (int n in thisStateNeighbors)
                {
                    if (!visited[n])
                    {
                        DFSUtil(n, ref visited);
                    }
                }
            }


        }

        static string NState2SState(int nState)
        {
            if (nState == 0)
            {
                return "Red";
            }
            else if(nState == 1)
            {
                return "Dark Blue";
            }
            else if (nState == 2)
            {
                return "Grey";
            }
            else if (nState == 3)
            {
                return "Light Blue";
            }
            else if (nState == 4)
            {
                return "Yellow";
            }
            else if (nState == 5)
            {
                return "Orange";
            }
            else if (nState == 6)
            {
                return "Pink";
            }
            else
            {
                return "Green";
            }
        }
    }
}
