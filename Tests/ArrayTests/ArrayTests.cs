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
        arr.Add(3);

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
        Assert.Equal(2, arr.Capacity);

        arr.Add(1);
        arr.Add(2);
        Assert.Equal(2, arr.Capacity);

        arr.Add(3);
        Assert.Equal(4, arr.Capacity);

        arr.Add(4);
        arr.Add(5);
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
        Assert.True(arr.Capacity >= 4);
    }

    [Fact]
    public void AddRange_ShouldHandleEmptyCollection()
    {
        var arr = new Array<int>(2);

        arr.AddRange(System.Array.Empty<int>());

        Assert.Equal(0, arr.Length);
        Assert.Equal(2, arr.Capacity);
    }

    [Fact]
    public void Insert_Test()
    {
        var arr = new Array<int>();
        arr.Add(1);
        arr.Add(2);
        arr.Add(3);

        arr.Insert(1, 10);

        Assert.Equal(4, arr.Length);
        Assert.Equal(1, arr[0]);
        Assert.Equal(10, arr[1]);
        Assert.Equal(2, arr[2]);
        Assert.Equal(3, arr[3]);
    }

    [Fact]
    public void Insert_ShouldSupportBeginning_AndEndPositions()
    {
        var arr = new Array<int>();
        arr.Add(2);
        arr.Add(3);

        arr.Insert(0, 1);
        arr.Insert(arr.Length, 4);

        Assert.Equal(4, arr.Length);
        Assert.Equal(1, arr[0]);
        Assert.Equal(2, arr[1]);
        Assert.Equal(3, arr[2]);
        Assert.Equal(4, arr[3]);
    }

    [Fact]
    public void Insert_ShouldThrow_WhenIndexIsOutOfRange()
    {
        var arr = new Array<int>();
        arr.Add(1);

        Assert.Throws<IndexOutOfRangeException>(() => arr.Insert(-1, 0));
        Assert.Throws<IndexOutOfRangeException>(() => arr.Insert(2, 0));
    }

    [Fact]
    public void IndexOf_Test()
    {
        var arr = new Array<int>();
        arr.Add(1);
        arr.Add(2);
        arr.Add(3);

        var index = arr.IndexOf(2);
        var index2 = arr.IndexOf(15);

        Assert.Equal(1, index);
        Assert.Equal(-1, index2);
    }

    [Fact]
    public void IndexOf_ShouldReturnFirstMatch_ForDuplicateValues()
    {
        var arr = new Array<int>();
        arr.AddRange(new[] { 4, 7, 7, 9 });

        var index = arr.IndexOf(7);

        Assert.Equal(1, index);
    }

    [Fact]
    public void Contains_Test()
    {
        var arr = new Array<int>();
        arr.Add(1);
        arr.Add(2);
        arr.Add(3);

        var condition = arr.Contains(2);
        var condition2 = arr.Contains(15);

        Assert.True(condition);
        Assert.False(condition2);
    }

    [Fact]
    public void Remove_ShouldRemoveFirstMatchingItem()
    {
        var arr = new Array<int>();
        arr.AddRange(new[] { 1, 2, 2, 3 });

        var removed = arr.Remove(2);

        Assert.True(removed);
        Assert.Equal(3, arr.Length);
        Assert.Equal(1, arr[0]);
        Assert.Equal(2, arr[1]);
        Assert.Equal(3, arr[2]);
    }

    [Fact]
    public void RemoveAt_Test()
    {
        var arr = new Array<int>();
        arr.AddRange(new[] { 1, 2, 3 });

        arr.RemoveAt(0);

        Assert.Equal(2, arr[0]);
        Assert.Equal(3, arr[1]);
        Assert.Equal(2, arr.Length);
        Assert.Throws<IndexOutOfRangeException>(() => arr.RemoveAt(-1));
        Assert.Throws<IndexOutOfRangeException>(() => arr.RemoveAt(4));
    }

    [Fact]
    public void RemoveAt_ShouldReturnRemovedValue()
    {
        var arr = new Array<int>();
        arr.AddRange(new[] { 10, 20, 30 });

        var removed = arr.RemoveAt(1);

        Assert.Equal(20, removed);
        Assert.Equal(2, arr.Length);
        Assert.Equal(10, arr[0]);
        Assert.Equal(30, arr[1]);
    }

    [Fact]
    public void IEnumerable_Test()
    {
        var arr = new Array<int>(8);
        arr.Add(1);
        arr.Add(2);
        arr.Add(3);

        var newArr = new Array<int>(arr.Length);
        foreach (var item in arr)
            newArr.Add(item);

        Assert.Equal(1, newArr[0]);
        Assert.Equal(2, newArr[1]);
        Assert.Equal(3, newArr[2]);
        Assert.Equal(3, newArr.Length);
    }

    [Fact]
    public void IEnumerable_ShouldIterateOnlyAddedItems()
    {
        var arr = new Array<int>(8);
        arr.Add(5);
        arr.Add(10);

        var values = arr.ToList();

        Assert.Equal(2, values.Count);
        Assert.Equal(5, values[0]);
        Assert.Equal(10, values[1]);
    }

    [Fact]
    public void Sort_Test()
    {
        var arr = new Array<int>();
        arr.Add(2);
        arr.Add(1);
        arr.Add(0);
        arr.Add(4);

        var newArray = arr.Sort();

        Assert.Equal(0, newArray[0]);
        Assert.Equal(1, newArray[1]);
        Assert.Equal(2, newArray[2]);
        Assert.Equal(4, newArray[3]);
    }

    [Fact]
    public void Sort_ShouldHandleDuplicateValues()
    {
        var arr = new Array<int>();
        arr.AddRange(new[] { 3, 1, 3, 2 });

        var sorted = arr.Sort();

        Assert.Equal(1, sorted[0]);
        Assert.Equal(2, sorted[1]);
        Assert.Equal(3, sorted[2]);
        Assert.Equal(3, sorted[3]);
    }
}
