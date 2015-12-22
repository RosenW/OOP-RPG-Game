using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Items;

namespace Game.Characters
{
    class Dwarf : Character
    {
        public Dwarf(string name)
            : base(name)
        {
            this.MaxHealth = 300;
            this.Health = 300;
            this.LeftHand = new OneHandedWeapon("Big Axe", 200, 0,50, 0);
            this.Chest = new Chest("Iron Chest", 10, 210, 100, 2);
            this.Inventory.Add(new OneHandedWeapon("OP Shotgun", 1000, 0, 350, 0));
        }
        public override string ToString()
        {
            return string.Format("{0} - Dwarf Level {1}", Name, Level);
        }
    }
}
