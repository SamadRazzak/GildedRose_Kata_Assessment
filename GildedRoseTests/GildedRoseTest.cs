using Xunit;
using System.Collections.Generic;
using GildedRoseKata;


namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        #region  Normal
        [Fact]
        // - At the end of each day, our system lowers the value of SellIn for every item
        public void Normal_UpdateQuality_Should_ReduceSellInTo4WhenInitialzedAs5()
        {
            // Given the item has sellIn of 5
            Item fooItem = CreateItem("Normal", 5, 5);
            var test = CreateGildedRose(fooItem);

            // When the Quality Update occurs
            test.UpdateQuality();

            // Then the sellIn is 4
            Assert.Equal(4, fooItem.SellIn);
        }

        [Fact]
        // - At the end of each day, our system lowers the value of Quality for every item
        public void Normal_UpdateQuality_Should_ReduceQualityTo4WhenInitialzedAs5()
        {
            // Given the item has a quality of 5
            var fooItem = CreateItem(GildedRose.Normal, 5, 5);
            var test = CreateGildedRose(fooItem);

            // When the Quality Update occurs
            test.UpdateQuality();

            // Then the quality value is 4
            Assert.Equal(4, fooItem.Quality);
        }

        [Fact]
        // - Once the sell-by date has passed, Quality degrades twice as fast
        public void Normal_UpdateQuality_Should_ReduceQualityBy2WhenSellInIsLessThanOrEqualToZero()
        {
            // Given the sell-by date has passed
            var zeroSellInItem = CreateItem(GildedRose.Normal, 3, -2);
            var test = CreateGildedRose(zeroSellInItem);

            // When the Quality Update occurs
            test.UpdateQuality();

            // Then the quality degraded twice as fast
            Assert.Equal(1, zeroSellInItem.Quality);
        }

        [Fact]
        // - The Quality of an item is never negative
        public void Normal_UpdateQuality_Should_KeepZeroQuality_When_QualityIsAlreadyZero()
        {
            // Given the quality of an item is 0
            var zeroQualityItem = CreateItem(GildedRose.Normal, 0, 0);
            var test = CreateGildedRose(zeroQualityItem);

            // When the Quality Update occurs
            test.UpdateQuality();

            // Then the quality is still 0
            Assert.Equal(0, zeroQualityItem.Quality);
        }

        #endregion Normal

        #region AgedBrie

        [Fact]
        //- "Aged Brie" actually increases in Quality the older it gets
        public void AgedBrie_UpdateQuality_Should_IncreseQualityByOne()
        {
            // Given the item name is "Aged Brie" and it's quality is 1
            var agedBrieItem = CreateItem(GildedRose.AgedBrie, 2, 5);
            var test = CreateGildedRose(agedBrieItem);

            // When the Quality Update occurs
            test.UpdateQuality();

            // Then the quality of the aged brie should be 2
            Assert.Equal(3, agedBrieItem.Quality);
        }

        [Fact]
        // - The Quality of an item is never more than 50
        public void AgedBrie_UpdateQuality_Should_KeepQualityAt50QualityIsAlready50()
        {
            // Given the quality of an item is already 50
            var agedBrieItem = CreateItem(GildedRose.AgedBrie, 50, 6);
            var test = CreateGildedRose(agedBrieItem);

            // When the Quality Update occurs
            test.UpdateQuality();

            // Then the quality of the item should remain 50
            Assert.Equal(50, agedBrieItem.Quality);
        }

        #endregion Aged Brie

        #region Sulfuras

        [Fact]
        //- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        public void Sulfuras_UpdateQuality_Should_KeepQualityAt10QualityIsAlready10()
        {
            // Given the item is named "Sulfuras" and has a quality of 10
            var sulfurasItem = CreateItem(GildedRose.SulfurusHand, 10, 6);
            var test = CreateGildedRose(sulfurasItem);

            // When the quality update occurs
            test.UpdateQuality();

            // Then the quality of the Sulfuras is still 10
            Assert.Equal(10, sulfurasItem.Quality);
        }

        [Fact]
        //- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        public void Sulfuras_UpdateQuality_Should_KeepSellInAt10SellInIsAlready10()
        {
            // Given the item is named "Sulfuras" and has a quality of 10
            var sulfurasItem = CreateItem(GildedRose.SulfurusHand, 5, 10);
            var test = CreateGildedRose(sulfurasItem);

            // When the quality update occurs
            test.UpdateQuality();

            // Then the quality of the Sulfuras is still 10
            Assert.Equal(10, sulfurasItem.SellIn);
        }

        #endregion Sulfuras

        #region BackStagePasses

        [Theory]
        [InlineData(20)]
        [InlineData(11)]
        /*- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches; 
         Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
         but Quality drops to 0 after the concert */
        public void BackStagePass_UpdateQuality_Should_IncreseQualityByOne(int sellIn)
        {
            // Given the item is Backstage Passes and the Sell In value is greater than 10
            var backstagePassesItem = CreateItem(GildedRose.BackStagePass, 10, sellIn);
            var test = CreateGildedRose(backstagePassesItem);

            // When the quality update occurs
            test.UpdateQuality();

            // Then the quality of the Backstage Passes increases by 1
            Assert.Equal(11, backstagePassesItem.Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(8)]
        [InlineData(6)]
        /*- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches; 
         Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
         but Quality drops to 0 after the concert */
        public void BackStagePass_UpdateQuality_Should_IncreseQualityByTwoAndSellInIsLessThan11ButGreaterThan5(int sellIn)
        {
            // Given the item is Backstage Passes and the Sell In value is greater than 10
            var backstagePassesItem = CreateItem(GildedRose.BackStagePass, 10, sellIn);
            var test = CreateGildedRose(backstagePassesItem);

            // When the quality update occurs
            test.UpdateQuality();

            // Then the quality of the Backstage Passes increases by 1
            Assert.Equal(12, backstagePassesItem.Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(1)]
        [InlineData(3)]
        /*- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches; 
         Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
         but Quality drops to 0 after the concert */
        public void BackStagePass_UpdateQuality_Should_IncreseQualityByThreeAndSellInIsLessThan6ButGreaterThan1(int sellIn)
        {
            // Given the item is Backstage Passes and the Sell In value is greater than 10
            var backstagePassesItem = CreateItem(GildedRose.BackStagePass, 10, sellIn);
            var test = CreateGildedRose(backstagePassesItem);

            // When the quality update occurs
            test.UpdateQuality();

            // Then the quality of the Backstage Passes increases by 1
            Assert.Equal(13, backstagePassesItem.Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        /*- "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches; 
         Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
         but Quality drops to 0 after the concert */
        public void BackStagePass_Quality_Should_DecreaseQualityTo0AndSellInIsLessThanOrEqualTo0(int sellIn)
        {
            // Given the item is Backstage Passes and the Sell In value is greater than 10
            var backstagePassesItem = CreateItem(GildedRose.BackStagePass, 10, sellIn);
            var test = CreateGildedRose(backstagePassesItem);

            // When the quality update occurs
            test.UpdateQuality();

            // Then the quality of the Backstage Passes increases by 1
            Assert.Equal(0, backstagePassesItem.Quality);
        }

        #endregion BackStagePasses

        #region Conjured

        [Fact]
        // - "Conjured" items degrade in Quality twice as fast as normal items
        public void Conjured_Quality_Should_DecreaseQualityBy2()
        {
            // Given the item is "Conjured" and it's quality is 4
            var conjuredItem = CreateItem(GildedRose.Conjured, 4, 5);
            var test = CreateGildedRose(conjuredItem);            

            // When the quality update occurs
            test.UpdateQuality();

            // Then the quality of the "Conjured" item is 2
            Assert.Equal(2, conjuredItem.Quality);
        }

        [Fact]
        // - "Conjured" items decrease sellin by one
        public void Conjured_Quality_Should_DecreaseSellInBy1()
        {
            // Given the item is "Conjured" and it's sellin is 4
            var conjuredItem = CreateItem(GildedRose.Conjured, 5, 4);
            var test = CreateGildedRose(conjuredItem);            

            // When the quality update occurs
            test.UpdateQuality();

            // Then the SellIn of the "Conjured" item is 3
            Assert.Equal(3, conjuredItem.SellIn);
        }

        #endregion Conjured

        private static Item CreateItem(string name, int quality, int sellIn) =>
            new Item { Name = name, Quality = quality, SellIn = sellIn };

        private static GildedRose CreateGildedRose(Item newItem) =>
            new GildedRose(new List<Item> { newItem });

    }
}
