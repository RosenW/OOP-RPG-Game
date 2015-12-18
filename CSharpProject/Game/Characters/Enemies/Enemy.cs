using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game.Enemies
{
    class Enemy : GameObject, IDie
    {
        private int attack;
        private int defence;
        private int level;
        private string name;
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
