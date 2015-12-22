using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;
using Game.Items;
using Game.Misc;

namespace Game.Enemies
{
    class Enemy : GameObject, IDie
    {
        private Random rand;
        private int attack;
        private int defence;
        private int level;
        private NameLists lists = new NameLists();
        

        public List<Item> drop;
        public bool isAlive { get; set; }



        public int Attack
        {
            get
            {
                if (attack * level == 0)
                {
                    return attack;
                }
                return attack * level;
            }
            set
            {
                if (value < 1)
                {
                    this.attack = 1;
                }
                this.attack = value;
            }
        }
        public int Defence
        {
            get
            {
                if (defence * level == 0)
                {
                    return defence;
                }
                return defence * level;
            }
            set
            {
                if (value < 1)
                {
                    this.defence = 1;
                }
                this.defence = value;
            }
        }
        public int Level { get { return level; } set { this.level = value; } }
        public string Name { get { return name; } set { this.name = value; } }

        public Enemy(int attack, int defence, int level, int hp)
        {
            this.rand = new Random();
            this.drop = new List<Item>()
            {
                new OneHandedWeapon(lists.Prenames[rand.Next(0,lists.Prenames.Length-1)] + lists.WeaponNames[rand.Next(0,lists.WeaponNames.Length-1)],rand.Next(20,200),rand.Next(10,50),rand.Next(100,350),0),
                new Helm(lists.Prenames[rand.Next(0,lists.Prenames.Length-1)] + lists.HelmNames[rand.Next(0,lists.HelmNames.Length-1)],rand.Next(15,150),rand.Next(50,250),rand.Next(30,130),1),
                new Chest(lists.Prenames[rand.Next(0,lists.Prenames.Length-1)] + lists.ChestNames[rand.Next(0,lists.ChestNames.Length-1)],rand.Next(10,50),rand.Next(80,350),rand.Next(100,500),2),
                new Legs(lists.Prenames[rand.Next(0,lists.Prenames.Length-1)] + lists.LeggingNames[rand.Next(0,lists.LeggingNames.Length-1)], rand.Next(10,70),rand.Next(100,200),rand.Next(100,350),3)
            };
            this.Health = hp * level;
            this.Level = level;
            this.Attack = attack;
            this.Defence = defence;
            this.Name = lists.enemyNames[rand.Next(0, lists.enemyNames.Length-1)];
            this.isAlive = true;
        }
        public void checkIfDead()
        {
            if (Health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            isAlive = false;
        }
    }
}
