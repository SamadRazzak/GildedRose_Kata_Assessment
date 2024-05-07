using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public abstract class UpdatableItem
    {
        protected Item item;

        public UpdatableItem(Item item)
        {
            this.item = item;
        }

        public abstract void Update();
    }
}
