using System;
using System.Collections.Generic;
using System.Text;

namespace LifeGame
{
    public class Organism
    {

        public Organism()
        {
            Body = ' ';
        }

        public bool Alive { get { if (Body != ' ') return true; else return false; } }

        public char Body { get; set; }

        public List<char> Neighbors { get; set; }

        public int NeighborCount { get { return Neighbors.Count; } }

        //Checks conditions relating to the object's boolean state and NeighborCount property, and changes accordingly.
        public void ChangeState()
        {
            if (Alive && NeighborCount < 2)
            {
                Body = ' ';
            }
            else if (Alive && NeighborCount > 3)
            { 
                Body = ' ';
            }
            else if (!Alive && NeighborCount == 3)
            {
                Random r = new Random();
                int randomBody = r.Next(0, NeighborCount - 1);

                Body = Neighbors[randomBody];
            }
        }
    }
}
