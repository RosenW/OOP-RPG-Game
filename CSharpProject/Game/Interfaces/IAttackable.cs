using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Enemies;

namespace Game.Interfaces
{
    interface IAttackable
    {
        void Attack(Enemy target);
    }
}
