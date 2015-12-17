using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    abstract class Item
    {
        public string Name { get; set; }
        public int ItemPower { get; set; }
        public int ItemDefense { get; set; }
        public int Price { get; set; }
        public int Type { get; set; }

        public Item(string name, int power,int defense, int price, int type)
        {
            this.Name = name;
            this.ItemPower = power;
            this.ItemDefense = defense;
            this.Price = price;
            this.Type = type;
        }
        public override string ToString()
        {
            return string.Format("{0} - Attack value: {1} Defence value: {2}",Name,ItemPower,ItemDefense);
        }
    }
}
