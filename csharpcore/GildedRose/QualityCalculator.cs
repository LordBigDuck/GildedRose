using System;
using GildedRoseKata.Constants;

namespace GildedRoseKata;

public static class QualityCalculator
{
    public static int ComputeNewQuality(Item item)
        => item.Name switch
        {
            ItemNames.Sulfuras => item.Quality,
            ItemNames.AgedBrie => ComputeBasicItemIncreasingQuality(item, Quality.BaseIncrement, Quality.Max),
            ItemNames.TAFKAL80ETCBackstagePass => ComputeBackstagePassQuality(item, Quality.Max),
            ItemNames.Conjured => ComputeBasicItemQuality(item, Quality.ConjuredIncrement, Quality.Min),
    
            _ => ComputeBasicItemQuality(item, Quality.BaseIncrement, Quality.Min)
        };
    
    private static int ComputeBasicItemIncreasingQuality(Item item, int increment, int maxQuality)
    {
        increment = item.SellIn < 0 ? increment * 2 : increment;
        return item.Quality + GetQualityIncrement(item.Quality, increment, maxQuality);
    }
        
    private static int ComputeBasicItemQuality(Item item, int decrement, int minQuality)
    {
        decrement = item.SellIn < 0 ? decrement * 2 : decrement;
        return item.Quality - GetQualityDecrement(item.Quality, decrement, minQuality);
    }
    
    private static int ComputeBackstagePassQuality(Item item, int maxQuality)
    {
        if (!item.Name.Equals(ItemNames.TAFKAL80ETCBackstagePass, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new Exception("Wrong item");
        }

        if (item.SellIn < 0)
        {
            return 0;
        }
    
        var increment = 1;
        if (item.SellIn < 10)
        {
            increment += 1;
            if (item.SellIn < 5)
            {
                increment += 1;
            }
        }

        return ComputeBasicItemIncreasingQuality(item, increment, maxQuality);
    }
    
    private static int GetQualityIncrement(int quality, int toAdd, int maxQuality)
        => quality + toAdd > maxQuality
            ? maxQuality - quality
            : toAdd;
    
    private static int GetQualityDecrement(int quality, int toSubstract, int minQuality)
        => quality - toSubstract < minQuality
            ? quality
            : toSubstract;
}