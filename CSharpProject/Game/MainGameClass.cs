using System;
using System.Collections.Generic;
using Game.Characters;
using Game.Items;

namespace Game
{
    class MainGameClass
    {
        private static List<Character> listOfCreatedChars = new List<Character>();
        private static string line;

        static void Main(string[] args)
        {

            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Welcome to (insert game name here)\n");
            Start();

        }

        public static void Start()
        {
            Console.WriteLine("Choose a character to enter the game or create a new one !\n\n\"C\" - Create\nNumber - enter with selected character\n");
            Console.WriteLine("your characters: ");

            for (int i = 0; i < listOfCreatedChars.Count; i++)
            {
                Console.WriteLine(i + " - " + listOfCreatedChars[i]);
            }
            Console.WriteLine();

            line = Console.ReadLine();
            if (line.Substring(0).ToLower() == "c")
            {
                Console.Write("Choose Name: ");
                string tempName = Console.ReadLine();
                Console.WriteLine("Choose class: 1 - Knight, 2 - ???");
                int tempClass = Int32.Parse(Console.ReadLine());
                if (tempClass == 1)
                {
                    listOfCreatedChars.Add(new Knight(tempName));
                }
                Console.WriteLine();
                Console.Clear();
                Start();
            }
            else
            {
                Town(listOfCreatedChars[Int32.Parse(line)]);
            }
        }
        public static void Town(Character ch)
        {
            //////////////////////////////////////////////////////////////////////////// TEST
            ch.AddItem(new Item("Sword", 100, 240));
            //////////////////////////////////////////////////////////////////////////// TEST
            Console.Clear();
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Hello "+ch.Name+" You are in town !");
            Console.WriteLine("You can: \nCheck Inventory - I\nFight in a dungeon - D\nSave and exit - S");
            line = Console.ReadLine();
            if (line.Substring(0).ToLower() == "i")
            {
                ch.CheckInv();
            }
        }
    }
}
