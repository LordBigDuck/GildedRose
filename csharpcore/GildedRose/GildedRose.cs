using System;
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
            item.Quality = GetNewQuality(item);
            
            if (item.Name != ItemNames.Sulfuras)
            {
                item.SellIn -= SellIn.DecrementValue;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != ItemNames.AgedBrie)
                {
                    if (item.Name != ItemNames.TAFKAL80ETCBackstagePass)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != ItemNames.Sulfuras)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < Quality.Max)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }

    private static int GetTotalQualityToDecrease(Item item)
    {
        if (item.Quality > Quality.Min)
        {
            if (item.Name != ItemNames.Sulfuras)
            {
                return 1;
            }
        }
    
        return 0;
    }
    
    private static int GetNewQuality(Item item)
        => item.Name switch
        {
            ItemNames.Sulfuras => item.Quality + 0,
            ItemNames.AgedBrie => item.Quality + GetQualityIncrementOfBasicItem(item),
            ItemNames.TAFKAL80ETCBackstagePass => item.Quality + GetTotalQualityToIncreaseOfBackstagePass(item),
    
            _ => item.Quality - GetTotalQualityToDecrease(item)
        };

    private static int GetQualityIncrement(int quality, int toAdd)
        => quality + toAdd > Quality.Max
            ? Quality.Max - quality
            : toAdd;

    private static int GetQualityIncrementOfBasicItem(Item item)
        => GetQualityIncrement(item.Quality, Quality.BaseIncrement);
    
    private static int GetTotalQualityToIncreaseOfBackstagePass(Item item)
    {
        if (!item.Name.Equals(ItemNames.TAFKAL80ETCBackstagePass, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new Exception("Wrong item");
        }
    
        var total = Quality.BaseIncrement;
        if (item.SellIn <= 10)
        {
            total += 1;
            if (item.SellIn <= 5)
            {
                total += 1;
            }
        }

        return GetQualityIncrement(item.Quality, total);
    }
}