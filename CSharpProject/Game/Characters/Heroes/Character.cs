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
        public int neededXP { get; set; }
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
            this.neededXP = 100;
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
            Console.WriteLine("To sell all type \"sell all\"");
            Console.WriteLine("To close Inventory type \"close\"");
            Console.WriteLine("Where X is the number of the item");

            string line = Console.ReadLine();
            string[] lineArgs = line.Split(new char[] { ' ' });

            if (lineArgs[0].ToLower() == "equip")
            {
                try
                {
                    Equip(Inventory[Int32.Parse(lineArgs[1])]);
                }
                catch (Exception)
                {
                    Console.Clear();
                    this.CheckInv();
                }
               
            }
            else if (lineArgs[0].ToLower() == "sell")
            {
                if (lineArgs[1].ToLower() == "all")
                {
                    this.SellAll();
                }
                else
                {
                    try
                    {
                        SellItem(Int32.Parse(lineArgs[1]));
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        this.CheckInv();
                    }
                }
            }
            else
            {
                MainGameClass.Town(this,"");
            }
        }

        internal void Heal()
        {
            if (this.Money >= 1000)
            {
                this.Health = this.MaxHealth;
                this.Money -= 1000;
                MainGameClass.Town(this, "Health restored for 1000 gold !");
            }
            else
            {
                MainGameClass.Town(this, "Not enough gold !");
            }
            
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
                MainGameClass.Town(this,"");
            }
            if (lineArgs[0].ToLower() == "f")
            {
                Random rand = new Random();
                Enemy currentEnemy = new Enemy(rand.Next(30, 60), rand.Next(30, 60), Math.Abs(this.Level + rand.Next(-3, 2))+ 1, rand.Next(50, 150));
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
                    MainGameClass.Town(this,"");
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
                MainGameClass.Town(this,"");
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
            Console.WriteLine("You have gained {0} XP and {1} gold", gainedXP, goldDrop);
            Console.WriteLine("You picked up {0}", dropedItem.Name);
            this.Experience += gainedXP;
            this.Money += goldDrop;
            this.Inventory.Add(dropedItem);
            string leveledUp = this.chekIfLeveledUp();
            Console.ReadLine();
            MainGameClass.Town(this,leveledUp);
        }

        private string chekIfLeveledUp()
        {
            if (this.Experience >= this.neededXP)
            {
                this.Experience = 0;
                this.neededXP = (int)(neededXP*2.1);
                this.Level++;
                return "You have Leveled up !";
            }
            return "";
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
            Console.WriteLine("Experience: {0} / {1}",Experience,neededXP);
            Console.WriteLine("\"close\" to close");

            string line = Console.ReadLine();
            string[] lineArgs = line.Split(new char[] { ' ' });

            MainGameClass.Town(this,"");
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
                        if (LeftHand.Name != "Nothing")
                        {
                            Inventory.Add(LeftHand);
                        }
                        LeftHand = item;
                        Console.Clear();
                        Console.SetCursorPosition(30, 20);
                        Console.WriteLine(string.Format("Equiped {0} in left hand", item.Name));
                        Console.SetCursorPosition(0, 0);
                        Inventory.Remove(item);
                        this.CheckInv();
                    }
                    if (input == 2)
                    {
                        if (RightHand.Name != "Nothing")
                        {
                            Inventory.Add(RightHand);
                        }
                        RightHand = item;
                        Console.Clear();
                        Console.SetCursorPosition(30, 20);
                        Console.WriteLine(string.Format("Equiped {0} in right hand", item.Name));
                        Console.SetCursorPosition(0, 0);
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
                    Console.SetCursorPosition(30, 20);
                    Console.WriteLine("The helm is equiped!");
                    Console.SetCursorPosition(0, 0);
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
                    Console.SetCursorPosition(30, 20);
                    Console.WriteLine("The chest is equiped!");
                    Console.SetCursorPosition(0, 0);
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
                    Console.SetCursorPosition(30, 20);
                    Console.WriteLine("The leggings are equiped!");
                    Console.SetCursorPosition(0, 0);
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
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("Sold {0} for {1} gold\n", Inventory[i].Name, Inventory[i].Price);
            Console.SetCursorPosition(0, 0);
            Money += Inventory[i].Price;
            Inventory.Remove(Inventory[i]);
            this.CheckInv();
        }
        private void SellAll()
        {
            Console.Clear();
            int sum = 0;
            for (int i = 0; i < Inventory.Count; i++)
            {
                sum += Inventory[i].Price;
            }
            Inventory = new List<Item>();
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("Sold everything for {0} gold\n", sum);
            Console.SetCursorPosition(0, 0);
            Money += sum;
            this.CheckInv();
        }

        public virtual void Attack(Enemy target)
        {
            int totalItemPower = LeftHand.ItemPower + RightHand.ItemPower + Helm.ItemPower + Chest.ItemPower + Legs.ItemPower;
            int totalItemDefence = LeftHand.ItemDefense + RightHand.ItemDefense + Helm.ItemDefense + Chest.ItemDefense + Legs.ItemDefense;
            if (target.Defence > totalItemPower)
            {
                target.Health -= rand.Next(1, 5);
            }
            else
            {
                target.Health += (target.Defence - totalItemPower)/5;
            }
            if (totalItemDefence > target.Attack)
            {
                this.Health -= rand.Next(1, 5);
            }
            else
            {
                this.Health += (totalItemDefence - target.Attack)/5;
            }
        }

        public void Die()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 12);
            Console.WriteLine("YOU DIED");
            Console.SetCursorPosition(0, 0);
            Console.ReadLine();
            Console.Clear();
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

    }
}
