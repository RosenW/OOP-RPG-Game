using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Enemies
{
    class Enemy
    {
        private int attack;
        private int defence;
        private int level;
        private string name;

        public int Attack
        {
            get { return attack * level; }
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
            get { return defence * level; }
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

        public Enemy(int attack,int defence,int level, string name)
        {
            this.Level = level;
            this.Attack = attack;
            this.Defence = defence;
            this.Name = name;
        }
    }
}
