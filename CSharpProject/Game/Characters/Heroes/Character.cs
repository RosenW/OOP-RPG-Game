using System;
using Game.Items;
using System.Collections.Generic;
using Game.Enemies;
using Game.Interfaces;

namespace Game.Characters
{
    abstract class Character : GameObject, IAttackable, IDie
    {

        public string Name { get { return this.name; } set { this.name = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1); } }
        public int Level { get; set; }
        public int Money { get; set; }
        public int Experience { get; set; }
        //public bool isAlive { get; set; }

        public Item LeftHand { get; set; }
        public Item RightHand { get; set; }
        public Item Chest { get; set; }
        public Item Helm { get; set; }
        public Item Legs { get; set; }

        Random rand = new Random();

        public List<Item> Inventory = new List<Item>();



        public Character(string name)
        {
            //this.isAlive = true;
            this.LeftHand = new OneHandedWeapon("Nothing", 0, 0, 0, 0);
            this.RightHand = new OneHandedWeapon("Nothing", 0, 0, 0, 0);
            this.Helm = new Helm("Nothing", 0, 0, 0, 1);
            this.Chest = new Chest("Nothing", 0, 0, 0, 2);
            this.Legs = new Legs("Nothing", 0, 0, 0, 3);
            this.Name = name;
            this.Level = 1;
            this.Experience = 0;
        }
        public void CheckInv()
        {
            Console.WriteLine("Inventory: ");
            Console.WriteLine("Gold: {0}", Money);
            for (int i = 0; i < Inventory.Count; i++)
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
            string[] lineArgs = line.Split(new char[] { ' ' });

            if (lineArgs[0].ToLower() == "equip")
            {
                Equip(Inventory[Int32.Parse(lineArgs[1])]);
            }
            else if (lineArgs[0].ToLower() == "sell")
            {
                SellItem(Int32.Parse(lineArgs[1]));
            }
            else
            {
                MainGameClass.Town(this);
            }

            //Console.Clear();
            //Console.SetCursorPosition(25, 0);
            //Console.WriteLine("Hello " + this.Name + " You are in town !");
            //CheckInv();
        }

        internal void GoInADungeon()
        {
            Console.Clear();
            Console.SetCursorPosition(25, 0);
            Console.WriteLine(" You are in a dungeon !");
            Console.WriteLine("You can: \nFight monster - F\nGo back to town - T");
            string line = Console.ReadLine();
            string[] lineArgs = line.Split(new char[] { ' ' });

            if (lineArgs[0].ToLower() == "t")
            {
                MainGameClass.Town(this);
            }
            if (lineArgs[0].ToLower() == "f")
            {
                Random rand = new Random();
                Enemy currentEnemy = new Enemy(rand.Next(30, 60), rand.Next(30, 60), Math.Abs(this.Level + rand.Next(-3, 2))+ 1, "a skeleton", rand.Next(50, 150));
                Console.WriteLine("you have encountered {0} (level {3}) with {1} attack and {2} defence", currentEnemy.Name, currentEnemy.Attack, currentEnemy.Defence, currentEnemy.Level);
                Console.WriteLine("fight - F");
                Console.WriteLine("run - R");
                string subLine = Console.ReadLine();
                if (subLine.ToLower() == "f")
                {
                    Fight(currentEnemy);
                }
                else
                {
                    MainGameClass.Town(this);
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid command");
                GoInADungeon();
            }

        }

        public void Fight(Enemy enemy)
        {
            Console.Clear();
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Fighting {0}\n", enemy.Name);
            Console.WriteLine("attack - enter");
            Console.WriteLine("flee - F");
            Console.WriteLine("Health: {0}", this.Health);
            Console.WriteLine("Enemy health: {0}", enemy.Health);
            string subSubLine = Console.ReadLine();
            if (subSubLine.ToLower() == "f")
            {
                MainGameClass.Town(this);
            }
            else
            {
                Attack(enemy);
                this.CheckIfDead();
                enemy.checkIfDead();
                if (enemy.isAlive)
                {
                    Fight(enemy);
                }
                else
                {
                    Loot(enemy);
                }

            }

        }

        private void Loot(Enemy e)
        {
            int gainedXP = rand.Next(10, 100) * e.Level;
            int goldDrop = rand.Next(50, 150) * e.Level;
            Item dropedItem = e.drop[rand.Next(0, 4)];
            Console.WriteLine("you have killed {0}", e.Name);
            Console.WriteLine("You have gained {0}XP and {1} gold", gainedXP, goldDrop);
            Console.WriteLine("You picked up {0}", dropedItem.Name);
            this.Experience += gainedXP;
            this.Money += goldDrop;
            this.Inventory.Add(dropedItem);
            Console.ReadLine();
            MainGameClass.Town(this);

        }

        internal void CheckChar()
        {
            Console.WriteLine("Left hand: " + LeftHand);
            Console.WriteLine("Right hand: " + RightHand);
            Console.WriteLine("Head: " + Helm);
            Console.WriteLine("Chest: " + Chest);
            Console.WriteLine("Legs: " + Legs);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Level: " + Level);
            Console.WriteLine("Experience: " + Experience);
            Console.WriteLine("\"close\" to close");

            string line = Console.ReadLine();
            string[] lineArgs = line.Split(new char[] { ' ' });

            MainGameClass.Town(this);
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
                        Inventory.Add(LeftHand);
                        LeftHand = item;
                        Console.Clear();
                        Console.WriteLine(string.Format("Equiped {0} in left hand", item.Name));
                        Inventory.Remove(item);
                        this.CheckInv();
                    }
                    if (input == 2)
                    {
                        Inventory.Add(RightHand);
                        RightHand = item;
                        Console.Clear();
                        Console.WriteLine(string.Format("Equiped {0} in right hand", item.Name));
                        Inventory.Remove(item);
                        this.CheckInv();
                    }
                    break;
                case 1:
                    if (Helm.Name != "Nothing")
                    {
                        Inventory.Add(Helm);
                    }
                    Helm = item;
                    Console.Clear();
                    Console.WriteLine("The helm is equiped!");
                    Inventory.Remove(item);
                    this.CheckInv();
                    break;
                case 2:
                    if (Chest.Name != "Nothing")
                    {
                        Inventory.Add(Chest);
                    }
                    Chest = item;
                    Console.Clear();
                    Console.WriteLine("The chest is equiped!");
                    Inventory.Remove(item);
                    this.CheckInv();
                    break;
                case 3:
                    if (Legs.Name != "Nothing")
                    {
                        Inventory.Add(Legs);
                    }
                    Legs = item;
                    Console.Clear();
                    Console.WriteLine("The leggings are equiped!");
                    Inventory.Remove(item);
                    this.CheckInv();
                    break;


            }
        }

        public void AddItem(Item i)
        {
            Inventory.Add(i);
        }
        private void SellItem(int i)
        {
            Console.Clear();
            Console.WriteLine("Sold {0} for {1} gold\n", Inventory[i].Name, Inventory[i].Price);
            Money += Inventory[i].Price;
            Inventory.Remove(Inventory[i]);
            this.CheckInv();
            //this.Die();
        }

        public virtual void Attack(Enemy target)
        {
            int totalItemPower = LeftHand.ItemPower + RightHand.ItemPower + Helm.ItemPower + Chest.ItemPower + Legs.ItemPower;
            int totalItemDefence = LeftHand.ItemDefense + RightHand.ItemDefense + Helm.ItemDefense + Chest.ItemDefense + Legs.ItemDefense;
            if (target.Defence > totalItemPower)
            {
                target.Health -= rand.Next(5, 15);
            }
            else
            {
                target.Health += (target.Defence - totalItemPower);
            }
            if (totalItemDefence > target.Attack)
            {
                this.Health -= rand.Next(5, 15);
            }
            else
            {
                this.Health += (totalItemDefence - target.Attack);
            }
        }

        public void Die()
        {
            Console.Clear();
            Console.WriteLine("YOU DIED"); ////TO DO
            MainGameClass.listOfCreatedChars.Remove(this);
            MainGameClass.Start();
        }
        public void CheckIfDead()
        {
            if (Health <= 0)
            {
                Die();
            }
        }
        //public void Leveling(Character ch)
        //{
            
        //}
    }
}
