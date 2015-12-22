using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;

namespace Game
{
    abstract class GameObject
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        protected string name;
    }
}
