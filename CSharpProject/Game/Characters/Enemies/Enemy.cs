using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;
using Game.Items;

namespace Game.Enemies
{
    class Enemy : GameObject, IDie
    {
        private int attack;
        private int defence;
        private int level;
        public List<Item> drop;
        private Random rand;
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
                if (value<1)
                {
                    this.attack = 1;
                }
                this.attack = value;
            }
        }
        public int Defence
        {
            get {
                if (defence * level == 0)
                {
                    return defence;
                }
                return defence * level;
            }
            set
            {
                if (value<1)
                {
                    this.defence = 1;
                }
                this.defence = value;
            }
        }
        public int Level { get { return level; } set { this.level = value; } }
        public string Name { get { return name; } set { this.name = value; } }

        public Enemy(int attack,int defence,int level, string name, int hp)
        {
            this.rand = new Random();
            this.drop = new List<Item>()
            {
                new OneHandedWeapon("Sword",rand.Next(20,200),rand.Next(10,50),rand.Next(100,350),0),
                new Helm("Helm",rand.Next(15,150),rand.Next(50,250),rand.Next(30,130),1),
                new Chest("Chest",rand.Next(10,50),rand.Next(80,350),rand.Next(100,500),2),
                new Legs("Leggings", rand.Next(10,70),rand.Next(100,200),rand.Next(100,350),3)         
            };
            this.Health = hp*level;
            this.Level = level;
            this.Attack = attack;
            this.Defence = defence;
            this.Name = name;
            this.isAlive = true;
        }
        public void checkIfDead()
        {
            if (Health<=0)
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
