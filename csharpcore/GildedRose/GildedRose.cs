﻿using System.Collections.Generic;

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
        for (var i = 0; i < _items.Count; i++)
        {
            if (_items[i].Name != ItemNames.AgedBrie && _items[i].Name != ItemNames.TAFKAL80ETCBackstagePass)
            {
                if (_items[i].Quality > Quality.Min)
                {
                    if (_items[i].Name != ItemNames.Sulfuras)
                    {
                        _items[i].Quality = _items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (_items[i].Quality < Quality.Max)
                {
                    _items[i].Quality = _items[i].Quality + 1;

                    if (_items[i].Name == ItemNames.TAFKAL80ETCBackstagePass)
                    {
                        if (_items[i].SellIn < 11)
                        {
                            if (_items[i].Quality < Quality.Max)
                            {
                                _items[i].Quality = _items[i].Quality + 1;
                            }
                        }

                        if (_items[i].SellIn < 6)
                        {
                            if (_items[i].Quality < Quality.Max)
                            {
                                _items[i].Quality = _items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (_items[i].Name != ItemNames.Sulfuras)
            {
                _items[i].SellIn = _items[i].SellIn - 1;
            }

            if (_items[i].SellIn < 0)
            {
                if (_items[i].Name != ItemNames.AgedBrie)
                {
                    if (_items[i].Name != ItemNames.TAFKAL80ETCBackstagePass)
                    {
                        if (_items[i].Quality > 0)
                        {
                            if (_items[i].Name != ItemNames.Sulfuras)
                            {
                                _items[i].Quality = _items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        _items[i].Quality = _items[i].Quality - _items[i].Quality;
                    }
                }
                else
                {
                    if (_items[i].Quality < Quality.Max)
                    {
                        _items[i].Quality = _items[i].Quality + 1;
                    }
                }
            }
        }
    }
}