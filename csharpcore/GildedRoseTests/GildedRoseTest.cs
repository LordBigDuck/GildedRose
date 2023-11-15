using System.Collections.Generic;
using FluentAssertions;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    [TestCase(1, 0)]
    [TestCase(-1, 1)]
    public void AllItems_QualityNeverDropsBelowZero(int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = "test", SellIn = sellIn, Quality = quality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.SellIn.Should().Be(sellIn - 1);
        itemToTest.Quality.Should().Be(0);
    }

    [Test]
    [TestCase(1)]
    [TestCase(8)]
    [TestCase(-5)]
    public void AllItems_SellInDropByOne(int sellIn)
    {
        var items = new List<Item> { new Item { Name = "test", SellIn = sellIn, Quality = 10 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.SellIn.Should().Be(sellIn - 1);
    }

    [Test]
    [TestCase(1, 10)]
    [TestCase(8, 5)]
    public void NormalItems_QualityDegradeByOneBeforeSellInIsZero(int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = "test", SellIn = sellIn, Quality = quality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.SellIn.Should().Be(sellIn - 1);
        itemToTest.Quality.Should().Be(quality - 1);
    }

    [Test]
    [TestCase(-2, 8)]
    [TestCase(0, 5)]
    public void NormalItems_QualityDegradeBy2AfterSellInDate(int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = "test", SellIn = sellIn, Quality = quality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.SellIn.Should().Be(sellIn - 1);
        itemToTest.Quality.Should().Be(quality - 2);
    }

    [Test]
    [TestCase(ItemNames.AgedBrie, 10, 50)]
    [TestCase(ItemNames.TAFKAL80ETCBackstagePass, 8, 49)]
    [TestCase(ItemNames.TAFKAL80ETCBackstagePass, 4, 48)]
    
    public void IncreasingQualityItems_QualityNeverExceedFifty(string itemName, int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.SellIn.Should().Be(sellIn - 1);
        itemToTest.Quality.Should().Be(Quality.MaxQuality);
    }

    [Test]
    public void Sulfuras_QualityNeverDecrease()
    {
        var items = new List<Item> { new Item { Name = ItemNames.Sulfuras, SellIn = 10, Quality = Quality.SulfurasQuality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.Quality.Should().Be(Quality.SulfurasQuality);
    }
    
    [Test]
    public void Sulfuras_SellInNeverDecrease()
    {
        var items = new List<Item> { new Item { Name = ItemNames.Sulfuras, SellIn = 10, Quality = 10 } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.SellIn.Should().Be(10);
    }

    [Test]
    [TestCase(10, 5)]
    [TestCase(6, 5)]
    [TestCase(8, 5)]
    public void BackstagePass_QualityIncreaseByTwoBetwenSixAndTenDaysBeforeSellIn(int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = ItemNames.TAFKAL80ETCBackstagePass, SellIn = sellIn, Quality = quality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.Quality.Should().Be(quality + 2);
    }
    
    [Test]
    [TestCase(5, 5)]
    [TestCase(4, 5)]
    [TestCase(1, 5)]
    public void BackstagePass_QualityIncreaseByThreeFiveDaysBeforeSellIn(int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = ItemNames.TAFKAL80ETCBackstagePass, SellIn = sellIn, Quality = quality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.Quality.Should().Be(quality + 3);
    }
    
    [Test]
    [TestCase(0, 5)]
    [TestCase(0, 8)]
    public void BackstagePass_QualityDropToZeroAfterSellIn(int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = ItemNames.TAFKAL80ETCBackstagePass, SellIn = sellIn, Quality = quality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.Quality.Should().Be(0);
    }

    [Test]
    [TestCase(0, 10)]
    [TestCase(1, 10)]
    [TestCase(2, 10)]
    public void Conjured_QualityDropsByTwoBeforeSellIn(int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = ItemNames.Conjured, SellIn = sellIn, Quality = quality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.Quality.Should().Be(quality - 2);
    }
    
    [Test]
    [TestCase(-1, 10)]
    [TestCase(-2, 10)]
    public void Conjured_QualityDropsByFourAfterSellIn(int sellIn, int quality)
    {
        var items = new List<Item> { new Item { Name = ItemNames.Conjured, SellIn = sellIn, Quality = quality } };
        var sut = new GildedRose(items);
        
        sut.UpdateQuality();

        var itemToTest = items[0];
        itemToTest.Quality.Should().Be(quality - 4);
    }
}
