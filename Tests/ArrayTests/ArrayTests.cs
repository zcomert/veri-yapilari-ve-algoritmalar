using Array;

namespace ArrayTests;

public class ArrayTests
{
    [Fact]
    public void Add_ShouldIncreaseLength_AndStoreItem()
    {
        var arr = new Array<int>();
        arr.Add(10);
        arr.Add(20);

        Assert.Equal(2, arr.Length);
        Assert.Equal(10, arr[0]);
        Assert.Equal(20, arr[1]);
    }

    [Fact]
    public void Add_ShouldResize_WhenCapacityExceeded()
    {
        var arr = new Array<int>(2);
        arr.Add(1);
        arr.Add(2);
        arr.Add(3); // Should trigger resize

        Assert.Equal(3, arr.Length);
        Assert.Equal(1, arr[0]);
        Assert.Equal(2, arr[1]);
        Assert.Equal(3, arr[2]);
    }

    [Fact]
    public void Remove_ShouldRemoveItem_AndShiftElements()
    {
        var arr = new Array<int>();
        arr.Add(1);
        arr.Add(2);
        arr.Add(3);

        bool removed = arr.Remove(2);

        Assert.True(removed);
        Assert.Equal(2, arr.Length);
        Assert.Equal(1, arr[0]);
        Assert.Equal(3, arr[1]);
    }

    [Fact]
    public void Remove_ShouldReturnFalse_WhenItemNotFound()
    {
        var arr = new Array<int>();
        arr.Add(1);
        arr.Add(2);

        bool removed = arr.Remove(3);

        Assert.False(removed);
        Assert.Equal(2, arr.Length);
    }

    [Fact]
    public void Indexer_ShouldGetAndSetItems()
    {
        var arr = new Array<string>();
        arr.Add("a");
        arr.Add("b");

        Assert.Equal("a", arr[0]);
        Assert.Equal("b", arr[1]);

        arr[1] = "c";
        Assert.Equal("c", arr[1]);
    }

    [Fact]
    public void Length_ShouldReturnNumberOfItems()
    {
        var arr = new Array<double>();
        Assert.Equal(0, arr.Length);

        arr.Add(1.1);
        arr.Add(2.2);

        Assert.Equal(2, arr.Length);
    }
    [Fact]
    public void Capacity_ShouldReflectInternalArraySize_AndGrowOnResize()
    {
        var arr = new Array<int>(2);
        // Baþlangýç kapasitesi 2 olmalý
        Assert.Equal(2, arr.Capacity);

        arr.Add(1);
        arr.Add(2);
        // Kapasite hala 2 olmalý (henüz resize olmadý)
        Assert.Equal(2, arr.Capacity);

        arr.Add(3); // Resize tetiklenir (2 -> 4)
        Assert.Equal(4, arr.Capacity);

        arr.Add(4);
        arr.Add(5); // Resize tetiklenir (4 -> 8)
        Assert.Equal(8, arr.Capacity);
    }
    [Fact]
    public void AddRange_ShouldAddAllItems_AndResizeIfNeeded()
    {
        var arr = new Array<int>(2);
        var itemsToAdd = new List<int> { 5, 10, 15, 20 };

        arr.AddRange(itemsToAdd);

        Assert.Equal(4, arr.Length);
        Assert.Equal(5, arr[0]);
        Assert.Equal(10, arr[1]);
        Assert.Equal(15, arr[2]);
        Assert.Equal(20, arr[3]);
        Assert.True(arr.Capacity >= 4); // Kapasite en az 4 olmalý (gerekirse daha fazla)
    }


}

