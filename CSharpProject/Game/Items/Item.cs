using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    class Item
    {
        public string Name { get; set; }
        public int ItemPower { get; set; }
        public int Price { get; set; }
        public Item(string name, int power, int price)
        {
            this.Name = name;
            this.ItemPower = power;
            this.Price = price;
        }
    }
}
