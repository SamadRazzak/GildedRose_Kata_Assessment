using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public const string AgedBrie = "Aged Brie";
        public const string BackStagePass = "Backstage passes to a TAFKAL80ETC concert";
        public const string SulfurusHand = "Sulfuras, Hand of Ragnaros";
        public const string Conjured = "Conjured";
        public const string Normal = "Normal";

        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }
       
        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                UpdatableItem updatableItem = item.Name switch
                {
                    AgedBrie =>  new AgedBrie(item),
                    BackStagePass => new BackStagePass(item),
                    SulfurusHand => new Sulfurus(item),
                    Conjured => new Conjured(item),
                    _ => new Normal(item)
                };

                updatableItem.Update();
            }
        }        
    }
}
