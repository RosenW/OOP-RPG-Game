using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Characters
{
    class Knight : Character
    {
        private int hp;
        public Knight(string name)
            : base(name)
        {
            this.hp = 120;
        }
        public override string ToString()
        {
            return string.Format("{0} - Knight Level {1}",Name,Level);
        }
    }
}
