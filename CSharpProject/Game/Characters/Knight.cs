using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Items;

namespace Game.Characters
{
    class Knight : Character
    {
        private int hp;
        public Knight(string name)
            : base(name)
        {
            this.hp = 120;
            this.LeftHand = new OneHandedWeapon("One-Handed Sword", 100, 10,50, 0);
            this.RightHand = new OneHandedWeapon("Keen Shield", 0, 250, 50, 0);
        }
        public override string ToString()
        {
            return string.Format("{0} - Knight Level {1}", Name, Level);
        }
    }
}
