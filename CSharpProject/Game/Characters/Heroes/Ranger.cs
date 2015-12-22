using Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Characters.Heroes
{
    class Ranger : Character
    {
        public Ranger(string name)
             : base(name) 
        {
            this.MaxHealth = 200;
            this.Health = 200;
            this.LeftHand = new OneHandedWeapon("Elvish Crossbow", 150, 0,50, 0);
            this.RightHand = new OneHandedWeapon("Demon Dagger", 50, 50, 50, 0);
            this.Inventory.Add(new Helm("OP Head item", 300, 500, 350, 1));
        }
    public override string ToString()
    {
        return string.Format("{0} - Ranger Level {1}", Name, Level);
    }
}
}
