using GildedRoseKata.Constants;

namespace GildedRoseKata;

public static class SellInCalculator
{
    public static int ComputeSellIn(Item item)
    {
        if (item.Name != ItemNames.Sulfuras)
        {
            return item.SellIn -= SellIn.DecrementValue;
        }

        return item.SellIn;
    }
}