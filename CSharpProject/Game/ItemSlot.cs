using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ItemSlot
    {
        public int AttackValue { get; set; }
        public int DefenseValue { get; set; }

        public ItemSlot(int attackV = 0, int defenseV = 0)
        {
            this.AttackValue = attackV;
            this.DefenseValue = defenseV;
        }
    }
}
