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
        public int Experience { get; set; }

        public Item LeftHand { get; set; }
        public Item RightHand { get; set; }
        public Item Chest { get; set; }
        public Item Helm { get; set; }
        public Item Legs { get; set; }

        public List<Item> Inventory = new List<Item>();

        private int totalItemPower;

        public Character(string name)
        {
            this.LeftHand = new OneHandedWeapon("Empty", 0, 0, 0, 0);
            this.RightHand = new OneHandedWeapon("Empty", 0, 0, 0, 0);
            this.Helm = new Helm("Empty", 0, 0, 0, 1);
            this.Chest = new Chest("Empty", 0, 0, 0, 2);
            this.Legs = new Legs("Empty", 0, 0, 0, 3);
            this.Name = name;
            this.Level = 0;
            this.Experience = 0;
        }
        public void CheckInv()
        {
            Console.WriteLine("Inventory: ");
            Console.WriteLine("Gold: {0}",Money);
            for(int i = 0; i < Inventory.Count; i++)
            {
                string str = string.Format("{0} - {1} - Power: {2}, Defense: {3}, Price: {4}",
                    i, Inventory[i].Name, Inventory[i].ItemPower, Inventory[i].ItemDefense, Inventory[i].Price);
                Console.WriteLine(str);
            }
            Console.WriteLine();
            Console.WriteLine("To equip type \"equip X\"");
            Console.WriteLine("To sell type \"sell X\"");
            Console.WriteLine("To close Inventory type \"close\"");
            Console.WriteLine("Where X is the number of the item");

            string line = Console.ReadLine();
            string[] lineArgs = line.Split(new char[] {' '});

            if (lineArgs[0].ToLower() == "equip")
            {
                Equip(Inventory[Int32.Parse(lineArgs[1])]);
            }
            else if (lineArgs[0].ToLower() == "sell")
            {
                SellItem(Int32.Parse(lineArgs[1]));
            }
            else if (lineArgs[0].ToLower() == "close")
            {
                MainGameClass.Town(this);
            }
            //Console.Clear();
            //Console.SetCursorPosition(25, 0);
            //Console.WriteLine("Hello " + this.Name + " You are in town !");
            CheckInv();
        }

        private void Equip(Item item)
        {
            switch (item.Type)
            {
                case 0:
                    Console.WriteLine("In which hand would you like to equip {0} ?\nLeft hand - 1\nRight hand - 2", item.Name);
                    int input = Int32.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        LeftHand = item;
                        Console.WriteLine(string.Format("Equiped {0} in left hand",item.Name));
                        Inventory.Remove(item);
                        
                    }
                    if (input == 2)
                    {
                        RightHand = item;
                        Console.WriteLine(string.Format("Equiped {0} in right hand", item.Name));
                        Inventory.Remove(item);
                    }
                    break;
            }
        }

        public void AddItem(Item i)
        {
            Inventory.Add(i);
        }
        private void SellItem(int i)
        {
            Console.WriteLine("Sold {0} for {1} gold\n",Inventory[i].Name,Inventory[i].Price);
            Money += Inventory[i].Price;
            Inventory.Remove(Inventory[i]);
        }
    }
}
