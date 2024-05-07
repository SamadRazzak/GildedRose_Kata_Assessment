using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class AgedBrie : UpdatableItem
    {
        public AgedBrie(Item item) : base(item)
        {
        }
        public override void Update()
        {
            if (item.SellIn < 0 && item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.Quality < 50) item.Quality = item.Quality + 1;
        }
    }
}
