using System;
using System.Collections.Generic;
using Game.Characters;
using Game.Items;

namespace Game
{
    class MainGameClass
    {
        public static List<Character> listOfCreatedChars = new List<Character>();
        private static string line;

        static void Main(string[] args)
        {

            Start();

        }

        public static void Start()
        {

            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Welcome to (insert game name here)\n");
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
                try
                {
                    Town(listOfCreatedChars[Int32.Parse(line)]);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Start();
                    Console.WriteLine("Invalid command");
                }
               
            }
        }
        public static void Town(Character ch)
        {
            Console.Clear();
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Hello "+ch.Name+" You are in town !");
            Console.WriteLine("You can: \nCheck Inventory - I\nCheck character - C\nFight in a dungeon - D\nSave and exit - S");
            line = Console.ReadLine();
            if (line.ToLower() == "i")
            {
                ch.CheckInv();
            }
            if (line.ToLower() == "c")
            {
                ch.CheckChar();
            }
            if (line.ToLower() == "d")
            {
                ch.GoInADungeon();
            }
            else
            {
                Town(ch);
            }
        }
    }
}
