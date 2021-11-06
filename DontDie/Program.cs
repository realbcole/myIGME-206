using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontDie
{
    //Class: Program
    //Author: Brandon Cole
    //Purpose: Adjacency matrix and adjacency list to represent a graph
    //Restrictions: None
    class Program
    {
        static (int, string)[,] mGraph = new (int, string)[,]
        {
                       //A//                 //B//          //C//        //D//        //E//         //F//        //G//        //H//
             /*A*/ {  (0, "east or north"), (-1, "north"), (-1, "not"), (-1, "not"),  (-1, "not"),  (-1, "not"), (-1, "not"), (-1, "not") },
             /*B*/ {  (2, "south"),         (-1, "north"), (-1, "not"), (3, "west"),  (-1, "not"),  (-1, "not"), (-1, "not"), (-1, "not") },
             /*C*/ {  (-1, "not"),          (2, "south"),  (-1, "not"), (5, "south"), (-1, "not"),  (-1, "not"), (-1, "not"), (-1, "not") },
             /*D*/ {  (-1, "not"),          (3, "east"),   (-1, "not"), (-1, "not"),  (-1, "not"),  (-1, "not"), (-1, "not"), (-1, "not") },
             /*E*/ {  (-1, "not"),          (-1, "not"),   (-1, "not"), (2, "north"), (-1, "not"),  (-1, "not"), (-1, "not"), (-1, "not") },
             /*F*/ {  (-1, "not"),          (-1, "not"),   (-1, "not"), (4, "east"),  (3, "south"), (-1, "not"), (-1, "not"), (-1, "not") },
             /*G*/ {  (-1, "not"),          (-1, "not"),   (-1, "not"), (-1, "not"),  (-1, "not"),  (1, "east"), (-1, "not"), (-1, "not") },
             /*H*/ {  (-1, "not"),          (-1, "not"),   (20, "east"),(-1, "not"),  (-1, "not"),  (-1, "not"), (2, "south"),(-1, "not") },
        };

        static (int, string)[][] lGraph = new (int, string)[][]
        {
           /*A*/ new (int,string)[] { (0, "east"), (0, "north"), (2, "south") }, // A, A, B
           /*B*/ new (int,string)[] { (2, "south"), (3, "east") }, // C, D
           /*C*/ new (int,string)[] { (2, "north"), (20, "south") }, //B, H
           /*D*/ new (int,string)[] { (3, "east"), (5, "south"), (4, "east"), (2, "north") }, //B, C, F, E
           /*E*/ new (int,string)[] { (3, "south")}, //F,
           /*F*/ new (int,string)[] { (1, "east") }, //G
           /*G*/ new (int,string)[] { (0, "north"), (2, "south") }, //E, H
        };
        static void Main(string[] args)
        {
        }

    }
}
