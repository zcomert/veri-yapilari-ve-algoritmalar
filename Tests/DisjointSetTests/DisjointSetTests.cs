using DisjointSet;

namespace DisjointSetTests;

public class DisjointSetTests
{
    [Fact]
    public void DefaultConstructor_ShouldCreateEmptySet()
    {
        var disjointSet = new DisjointSet<int>();

        Assert.Equal(0, disjointSet.Count);
        Assert.Empty(disjointSet);
    }

    [Fact]
    public void CollectionConstructor_ShouldCreateSingletonSets_ForAllItems()
    {
        var disjointSet = new DisjointSet<int>(new[] { 1, 2, 3 });

        Assert.Equal(3, disjointSet.Count);
        Assert.Equal(1, disjointSet.FindSet(1));
        Assert.Equal(2, disjointSet.FindSet(2));
        Assert.Equal(3, disjointSet.FindSet(3));
    }

    [Fact]
    public void MakeSet_ShouldIncreaseCount_AndCreateSelfRootedNode()
    {
        var disjointSet = new DisjointSet<string>();

        disjointSet.MakeSet("A");

        Assert.Equal(1, disjointSet.Count);
        Assert.Equal("A", disjointSet.FindSet("A"));
    }

    [Fact]
    public void MakeSet_ShouldThrow_WhenValueAlreadyExists()
    {
        var disjointSet = new DisjointSet<int>();
        disjointSet.MakeSet(1);

        var exception = Assert.Throws<Exception>(() => disjointSet.MakeSet(1));

        Assert.Equal("The value has already been defined.", exception.Message);
    }

    [Fact]
    public void FindSet_ShouldThrow_WhenValueDoesNotExist()
    {
        var disjointSet = new DisjointSet<int>();

        var exception = Assert.Throws<Exception>(() => disjointSet.FindSet(100));

        Assert.Equal("The value is not in this set!", exception.Message);
    }

    [Fact]
    public void Union_ShouldThrowArgumentNullException_WhenAnyArgumentIsNull()
    {
        var disjointSet = new DisjointSet<string>(new[] { "A", "B" });

        Assert.Throws<ArgumentNullException>(() => disjointSet.Union(null!, "B"));
        Assert.Throws<ArgumentNullException>(() => disjointSet.Union("A", null!));
    }

    [Fact]
    public void Union_ShouldMergeTwoSingletonSets()
    {
        var disjointSet = new DisjointSet<int>(new[] { 1, 2 });

        disjointSet.Union(1, 2);

        var root1 = disjointSet.FindSet(1);
        var root2 = disjointSet.FindSet(2);

        Assert.Equal(root1, root2);
        Assert.Equal(1, root1);
    }

    [Fact]
    public void Union_ShouldDoNothing_WhenValuesAlreadyInSameSet()
    {
        var disjointSet = new DisjointSet<int>(new[] { 1, 2, 3 });
        disjointSet.Union(1, 2);

        var rootBefore = disjointSet.FindSet(1);

        disjointSet.Union(1, 2);

        Assert.Equal(rootBefore, disjointSet.FindSet(1));
        Assert.Equal(rootBefore, disjointSet.FindSet(2));
    }

    [Fact]
    public void Union_ShouldPreserveHigherRankRoot_AndUseFirstRootWhenRanksAreEqual()
    {
        var disjointSet = new DisjointSet<int>(new[] { 1, 2, 3, 4, 5 });
        disjointSet.Union(1, 2);
        disjointSet.Union(3, 4);
        disjointSet.Union(3, 5);

        disjointSet.Union(1, 3);

        var commonRoot = disjointSet.FindSet(1);

        Assert.Equal(1, commonRoot);
        Assert.Equal(commonRoot, disjointSet.FindSet(2));
        Assert.Equal(commonRoot, disjointSet.FindSet(3));
        Assert.Equal(commonRoot, disjointSet.FindSet(4));
        Assert.Equal(commonRoot, disjointSet.FindSet(5));
    }

    [Fact]
    public void Union_ShouldAllowTransitiveConnectivity()
    {
        var disjointSet = new DisjointSet<int>(new[] { 1, 2, 3, 4 });

        disjointSet.Union(1, 2);
        disjointSet.Union(2, 3);

        Assert.Equal(disjointSet.FindSet(1), disjointSet.FindSet(3));
        Assert.NotEqual(disjointSet.FindSet(1), disjointSet.FindSet(4));
    }

    [Fact]
    public void GetEnumerator_ShouldReturnAllInsertedValues()
    {
        var disjointSet = new DisjointSet<int>(new[] { 5, 10, 15 });

        var values = disjointSet.ToList();

        Assert.Equal(3, values.Count);
        Assert.Contains(5, values);
        Assert.Contains(10, values);
        Assert.Contains(15, values);
    }
}
