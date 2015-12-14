using System;
using Game.Items;
using System.Collections.Generic;

namespace Game.Characters
{
    abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Money { get; set; }
        public List<Item> Inventory = new List<Item>();
        private int totalItemPower;
        public Character(string name)
        {
            this.Name = name;
            this.Level = 0;
        }
        public void CheckInv()
        {
            Console.WriteLine("Inventory: ");
            for(int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine(i + " - " + Inventory[i].Name + " - Power: " + Inventory[i].ItemPower + ", Price: " + Inventory[i].Price);
            }
            Console.WriteLine();
            Console.WriteLine("To equip type \"equip X\"");
            Console.WriteLine("To sell type \"sell X\"");
            Console.WriteLine("To close Inventory type \"close\"");
            Console.WriteLine("Where X is the number of the item");

            string line = Console.ReadLine();
            string[] lineArgs = line.Split(new char[] {' '});

            if (lineArgs[0].Substring(0).ToLower() == "e")
            {
                // TO DO;
            }
            else if (lineArgs[0].ToLower() == "sell")
            {
                SellItem(Int32.Parse(lineArgs[1]));
            }
            else if (lineArgs[0].ToLower() == "close")
            {
                MainGameClass.Town(this);
            }
            Console.Clear();
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Hello " + this.Name + " You are in town !");
            CheckInv();
        }
        public void AddItem(Item i)
        {
            Inventory.Add(i);
        }
        private void SellItem(int i)
        {
            Money += Inventory[i].Price;
            Inventory.Remove(Inventory[i]);
        }
    }
}
