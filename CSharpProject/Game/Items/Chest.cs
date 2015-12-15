using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    class Chest : Item
    {
        public Chest(string name, int power, int defense, int price, int type)
            : base(name,power,defense,price, type)
        {

        }
    }
}
