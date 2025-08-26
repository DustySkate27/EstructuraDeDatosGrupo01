using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Grupo_01.TP03.Scripts
{
    public class Item
    {
        public IItem item;

        public int id;

        public int price;

        public int rarity;

        public string type;

        public int storeQuantity;

        public int playerQuantity;

        public Item(int id, int price, int rarity, string type, int quantity)
        {
            this.id = id;
            this.price = price;
            this.rarity = rarity;
            this.type = type;
            this.storeQuantity = quantity;
            this.playerQuantity = 0;
        }
    }
}
