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
        public Knight(string name)
            : base(name)
        {
            this.Health = 300;
            this.LeftHand = new OneHandedWeapon("One-Handed Sword", 250, 10,50, 0);
            this.RightHand = new OneHandedWeapon("Wooden Shield", 0, 250, 50, 0);
            this.Inventory.Add(new Helm("Crown", 50, 500, 350, 1));
        }
        public override string ToString()
        {
            return string.Format("{0} - Knight Level {1}", Name, Level);
        }
    }
}
