using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class Conjured : UpdatableItem
    {
        public Conjured(Item item) : base(item) { }

        public override void Update()
        {
            item.Quality -= 2;
            item.SellIn--;
        }
    }
}
