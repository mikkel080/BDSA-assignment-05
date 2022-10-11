namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void TestTheTruth()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void DexterityVest_Quality_should_Be_20()
    {
        var item = new subItem("+5 Dexterity Vest", 10, 20);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        item.Quality.Should().Be(20);
    }

    [Fact]
    public void DexterityVest_UpdateQuality_should_Be_19()
    {
        var item = new subItem("+5 Dexterity Vest", 10, 20);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        program.UpdateQuality();
        item.Quality.Should().Be(19);
    }

    [Fact]
    public void Aged_Brie_Quality_should_Be_0()
    {
        var item = new subItem("Aged Brie", 2, 0, isAgedBrie: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        item.Quality.Should().Be(0);
    }

    [Fact]
    public void Aged_Brie_UpdateQuality1_should_Be_1()
    {
        var item = new subItem("Aged Brie", 2, 0, isAgedBrie: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        program.UpdateQuality();
        item.Quality.Should().Be(1);
    }

    [Fact]
    public void Aged_Brie_UpdateQuality3_should_Be_4()
    {
        var item = new subItem("Aged Brie", 2, 0, isAgedBrie: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        program.UpdateQuality();
        program.UpdateQuality();
        program.UpdateQuality();
        item.Quality.Should().Be(4);
    }

    [Fact]
    public void Aged_Brie_UpdateQuality100_should_Be_50()
    {
        var item = new subItem("Aged Brie", 2, 0, isAgedBrie: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        for (var i = 0; i < 100; i++)
        {
            program.UpdateQuality();
        }
        
        item.Quality.Should().Be(50);
    }

    [Fact]
    public void Aged_Brie_SellIn3_UpdateQuality100_should_Be_50()
    {
        var item = new subItem("Aged Brie", 3, 0, isAgedBrie: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        for (var i = 0; i < 100; i++)
        {
            program.UpdateQuality();
        }
        
        item.Quality.Should().Be(50);
    }

    [Fact]
    public void Sulfuras_QualityUpdate30_should_Be_80()
    {
        var item = new subItem("Sulfuras, Hand of Ragnaros", 0, 80, isLegendary: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        for (var i = 0; i < 30; i++)
        {
            program.UpdateQuality();
        }

        item.Quality.Should().Be(80);
        item.SellIn.Should().Be(0);
    }

    [Fact]
    public void Sulfuras_SellInUpdate_should_Be_negative1()
    {
        var item = new subItem("Sulfuras, Hand of Ragnaros", -1, 80, isLegendary: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        program.UpdateQuality();

        item.Quality.Should().Be(80);
        item.SellIn.Should().Be(-1);
    }

    
    [Fact]
    public void Conjured_Mana_Cake_Quality_Should_Be_6()
    {
        var item = new subItem("Conjured Mana Cake", 3, 6, isConjured: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        item.Quality.Should().Be(6);
    }

    [Fact]
    public void Conjured_Mana_Cake_UpdateQuality_Should_Be_4()
    {
        var item = new subItem("Conjured Mana Cake", 3, 6, isConjured: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        program.UpdateQuality();
        // item.Quality.Should().Be(5); Was the old version
        item.Quality.Should().Be(4);
    }

    public void Higher_Qual_Conjured_Mana_Cake_UpdateQuality_Should_Be_4()
    {
        var item = new subItem("Conjured Mana Cake", 3, 20, isConjured: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        for (var i = 0; i < 4; i++)
        {
            program.UpdateQuality();
        }
        // item.Quality.Should().Be(5); Was the old version
        item.Quality.Should().Be(10);
    }

    [Fact]
    public void Backstage_Pass_Quality_Should_Be_20()
    {
        var item = new subItem("Backstage passes to a TAFKAL80ETC concert", 11, 20, isBackstagePass: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        item.Quality.Should().Be(20);
    }

    [Fact]
    public void Backstage_Pass_UpdateQuality1_Should_Be_21()
    {
        var item = new subItem("Backstage passes to a TAFKAL80ETC concert", 11, 20, isBackstagePass: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        program.UpdateQuality();
        item.Quality.Should().Be(21);
    }


    [Fact]
    public void Backstage_Pass_UpdateQuality2_Should_Be_23()
    {
        var item = new subItem("Backstage passes to a TAFKAL80ETC concert", 11, 20, isBackstagePass: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        for (var i = 0; i < 2; i++)
        {
            program.UpdateQuality();
        }
        item.Quality.Should().Be(23);
    }

    [Fact]
    public void Backstage_Pass_UpdateQuality7_Should_Be_34()
    {
        var item = new subItem("Backstage passes to a TAFKAL80ETC concert", 11, 20, isBackstagePass: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        for (var i = 0; i < 7; i++)
        {
            program.UpdateQuality();
        }
        item.Quality.Should().Be(34);
    }

    [Fact]
    public void Backstage_Pass_UpdateQuality13_Should_Be_0()
    {
        var item = new subItem("Backstage passes to a TAFKAL80ETC concert", 11, 20, isBackstagePass: true);
        var items = new List<Item> { item };
        var program = new Program { Items = items };
        for (var i = 0; i < 13; i++)
        {
            program.UpdateQuality();
        }
        item.Quality.Should().Be(0);
    }

    [Fact]
    public void All_Should_Be_Quality()
    {
        var items = new List<Item>
        {
            new subItem("+5 Dexterity Vest", 10, 20),
            new subItem("Aged Brie", 2, 0, isAgedBrie: true),
            new subItem("Elixir of the Mongoose", 5, 7),
            new subItem("Sulfuras, Hand of Ragnaros", 0, 80, isLegendary: true),
            new subItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, isBackstagePass: true),
            new subItem("Conjured Mana Cake", 3, 6, isConjured: true)
        };

        var program = new Program { Items = items };
        items[0].Quality.Should().Be(20);
        items[1].Quality.Should().Be(0);
        items[2].Quality.Should().Be(7);
        items[3].Quality.Should().Be(80);
        items[4].Quality.Should().Be(20);
        items[5].Quality.Should().Be(6);
    }

    [Fact]
    public void All_Should_Be_UpdatedQuality1()
    {        
        var items = new List<Item>
        {
            new subItem("+5 Dexterity Vest", 10, 20),
            new subItem("Aged Brie", 2, 0, isAgedBrie: true),
            new subItem("Elixir of the Mongoose", 5, 7),
            new subItem("Sulfuras, Hand of Ragnaros", 0, 80, isLegendary: true),
            new subItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, isBackstagePass: true),
            new subItem("Conjured Mana Cake", 3, 6, isConjured: true)
        };

        var program = new Program { Items = items };
        program.UpdateQuality();
        items[0].Quality.Should().Be(19);
        items[1].Quality.Should().Be(1);
        items[2].Quality.Should().Be(6);
        items[3].Quality.Should().Be(80);
        items[4].Quality.Should().Be(21);
        items[5].Quality.Should().Be(4);
    }

    public void All_Should_Be_UpdatedQuality100()
    {
        
        var items = new List<Item>
        {
            new subItem("+5 Dexterity Vest", 10, 20),
            new subItem("Aged Brie", 2, 0, isAgedBrie: true),
            new subItem("Elixir of the Mongoose", 5, 7),
            new subItem("Sulfuras, Hand of Ragnaros", 0, 80, isLegendary: true),
            new subItem("Backstage passes to a TAFKAL80ETC concert", 15, 20, isBackstagePass: true),
            new subItem("Conjured Mana Cake", 3, 6, isConjured: true)
        };

        var program = new Program { Items = items };
        for (var i = 0; i < 100; i++)
        {
            program.UpdateQuality();
        }
        items[0].Quality.Should().Be(0);
        items[1].Quality.Should().Be(50);
        items[2].Quality.Should().Be(0);
        items[3].Quality.Should().Be(80);
        items[4].Quality.Should().Be(0);
        items[5].Quality.Should().Be(0);
    }
}