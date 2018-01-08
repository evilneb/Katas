using System;

namespace LifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            WorldMaker bang = new WorldMaker();

            Organism[,] world = bang.MakeCritters(bang.SetPrimordialGoop());

            bool run = true;

            Console.Clear();

            bang.ShowWorld(world);

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Press a key to begin Life. ('Q' to end it)");

            while (run)
            {
                run = bang.RunLife(world);
            }
        }
    }
}