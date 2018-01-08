using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LifeGame
{
    public class WorldMaker
    {
        public WorldMaker()
        {
        }

        //Takes input line-by-line, and converts them into a list of character arrays for later use.
        public List<char[]> SetPrimordialGoop()
        {
            string line;

            List<char[]> lat = new List<char[]>();

            Console.WriteLine();
            Console.WriteLine("Please enter lines of characters as creatures on one latitude of the world, separated by spaces. Press 'Enter' to input the next line. Enter 'F' to finish designing.");
            Console.WriteLine();
            Console.WriteLine("Design the Primordial Goop, please:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            

            bool run = true;
            while (run)
            {
                line = Console.ReadLine();
                if (line.ToLower() == "f")
                {
                    run = false;
                }
                else
                {
                    lat.Add(line.ToCharArray());
                    run = true;
                }
            }

            return lat;
        }

        //Takes the Primordial Goop list and uses its quanity of members and max length member to determine the
        //necessary size for the 2d array. The array is created, populating only the inner indices with objects, leaving a border of nulls.
        //The inner part of the array is populated with objects, using the value from the char[] as their Body, and filling in
        //blank indices with !Alive objects.
        public Organism[,] MakeCritters(List<char[]> chosen)
        {
            int x = chosen.Max(arr => arr.Length) + 2;

            int y = chosen.Count() + 2;

            Organism[,] goop = new Organism[y, x];

            //previously, designed so that the whole 2d array was created with !Alive objects,
            //then going through again to give them Body correlating with entered text.
            //This way, the program only loops through the entire array once.
            for (int i = 1; i < y - 1; i++)
            {
                if (chosen[i - 1].Length > 0)
                {
                    for (int j = 1; j <= chosen[i - 1].Length; j++)
                    {
                        if (chosen[i - 1][j - 1] != ' ')
                        {
                            goop[i, j] = new Organism()
                            {
                                Body = chosen[i - 1][j - 1]
                            };
                        }
                        else
                            goop[i, j] = new Organism();

                    }
                    for (int j = chosen[i - 1].Length + 1; j < x - 1; j++)
                    {
                        goop[i, j] = new Organism();
                    }
                }
                else
                {
                    for (int j = 1; j < x - 1; j++)
                    {
                        goop[i, j] = new Organism();
                    }
                }
            }
            return goop;
        }

        //Prints the current state.
        public void ShowWorld(Organism[,] goop)
        {
            int y = goop.GetLength(0);
            int x = goop.GetLength(1);

            for (int i = 1; i < y - 1; i++)
            {
                for (int j = 1; j < x - 1; j++)
                {
                    Console.Write(goop[i, j].Body.ToString());
                }
                Console.WriteLine();
            }
        }

        //Maps another 2d array, representing one object's "neighbors" (3x3), over each object in the main array. 
        //Since the objects being mapped are inside the null border, instead of checking for every condition where
        //an index is 0 or arr.GetLength - 1, and preventing it from looking outside the array bounds, it can just
        //filter out null members in the collection. It uses this mapped array to collect the Alive objects, storing
        //their Body characters for counting and randomized population mechanics later on.
        public void CountNeighbors(Organism[,] goop)
        {
            int y = goop.GetLength(0);
            int x = goop.GetLength(1);

            for (int i = 1; i < y - 1; i++)
            {
                for (int j = 1; j < x - 1; j++)
                {
                    Organism[,] neighborhood = new Organism[3, 3]
                    {
                        { goop[i - 1, j - 1] , goop[i - 1, j], goop[i - 1, j + 1] },
                        { goop[i, j - 1], null, goop[i, j + 1] },
                        { goop[i + 1, j - 1], goop[i + 1, j], goop[i + 1, j + 1] }
                    };

                    goop[i, j].Neighbors = new List<char>(from Organism n in neighborhood
                                                          where n != null
                                                          && n.Alive
                                                          select n.Body);
                }
            }
        }

        //Facilitates the repetitive counting, state changing, and printing of the world's Life with boolean return values.
        public bool RunLife(Organism[,] goop)
        {
            string input = Console.ReadLine();
            Console.Clear();

            if (input.ToLower() == "q")
                return false;

            CountNeighbors(goop);

            foreach (Organism o in goop)
            {
                if (o != null)
                {
                    o.ChangeState();
                }
            }

            ShowWorld(goop);

            return true;
        }
    }
}
