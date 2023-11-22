using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            UpdateQuality(item);
        }
    }

    private static void UpdateQuality(Item item)
    {
        item.SellIn = SellInCalculator.ComputeSellIn(item);
        item.Quality = QualityCalculator.ComputeNewQuality(item);
    }
}