using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    class OneHandedWeapon : Item
    {
        public OneHandedWeapon(string name, int power, int defense, int price, int type)
            : base(name,power,defense,price, type)
        {
                
        }
    }
}
