using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items;
        public static void Main(string[] args) 
        { 
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                    {
                                    new subItem ("+5 Dexterity Vest", 10, 20),
                                    new subItem ("Aged Brie", 2, 0, isAgedBrie: true),
                                    new subItem ("Elixir of the Mongoose", 5, 7),
                                    new subItem ("Sulfuras, Hand of Ragnaros", 0, 80, isLegendary: true),
                                    new subItem("Sulfuras, Hand of Ragnaros", -1, 80, isLegendary: true),
                                    new subItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, isBackstagePass: true),
                                    new subItem("Backstage passes to a TAFKAL80ETC concert", 10, 49, isBackstagePass: true),
                                    new subItem("Backstage passes to a TAFKAL80ETC concert", 5, 49, isBackstagePass: true),
                                    // this conjured item does not work properly yet
                                    new subItem("Conjured Mana Cake", 3, 6, isConjured: true)
                                    }
                          };
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
        
        [Obsolete("This method is deprecated, please use UpdateQuality() instead.")]
        public void OldUpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                        if (Items[i].Name == "Conjured Mana Cake")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        public void UpdateQuality()
        {
            foreach (subItem item in Items)
            {
                item.updateItem();
            }
        }        
    }



    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

    public class subItem : Item
    {
        public bool isLegendary { get; set; }

        public bool isConjured { get; set; }

        public bool isBackstagePass { get; set; }

        public bool isAgedBrie { get; set; }

        public subItem(string Name, int SellIn, int Quality, bool isLegendary = false, bool isConjured = false, bool isBackstagePass = false, bool isAgedBrie = false)
        {
            this.Name = Name;
            this.SellIn = SellIn;
            this.Quality = Quality;
            this.isLegendary = isLegendary;
            this.isConjured = isConjured;
            this.isBackstagePass = isBackstagePass;
            this.isAgedBrie = isAgedBrie;
        }
        
        public void updateItem()
        {
            if (this.isLegendary) return;

            updateSellIn();         
            
            if (this.isConjured)
            {
                if (this.SellIn > 0)
                    this.Quality -= 2;
                else
                    this.Quality -= 4;
                qualityWithinLimits();
                return;
            }
            
            if (this.isAgedBrie)
            {
                if (this.SellIn >= 0)
                    this.Quality += 1;
                else
                    this.Quality += 2;
                qualityWithinLimits();
                return;
            }

            if (this.isBackstagePass)
            {
                if (this.SellIn >= 10)
                    this.Quality += 1;
                else if (this.SellIn >= 5)
                    this.Quality += 2;
                else if (this.SellIn >= 0)
                    this.Quality += 3;
                else
                    this.Quality = 0;
                qualityWithinLimits();
                return;
            }

            

            this.Quality -= 1;
            qualityWithinLimits();
            
        }

        public void updateSellIn()
        {
            if (this.isLegendary) return;
            this.SellIn -= 1;
        }

        public void qualityWithinLimits()
        {
            if (this.Quality < 0)
                this.Quality = 0;
            if (this.Quality > 50)
                this.Quality = 50;
        }
        
    }
}