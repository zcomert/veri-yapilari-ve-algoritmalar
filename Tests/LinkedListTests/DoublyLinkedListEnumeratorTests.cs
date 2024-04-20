
using DataStructures.LinkedList.Doubly;

namespace Tests.LinkedListTests;
public class DbLinkedListEnumeratorTests
{
    [Fact]
    public void Constructor_WithoutParameters_HeadAndTailAreNull()
    {
        var linked = new DoublyLinkedList<int>();

        Assert.Equal(null, linked.Head);
        Assert.Equal(null, linked.Tail);
    }

    [Fact]
    public void Constructor_WithParameters_SetsHeadAndTail()
    {
        var linked = new DoublyLinkedList<int>(new int[] { 0, 1, 2, 3, 4 });
        var enumerator = linked.GetEnumerator();

        Assert.Equal(0, linked.Head.Value);
        Assert.Equal(4, linked.Tail.Value);
    }

    [Fact]
    public void Current_WhenCurrIsNull_ReturnsDefault()
    {
        var linked = new DoublyLinkedList<int>(new int[] { 6, 0, 1, 2, 3, 4 });
        var enumerator = linked.GetEnumerator();

        Assert.Equal(0, enumerator.Current);
    }

    [Fact]
    public void MoveNext_WhenHeadIsNull_ReturnsFalse()
    {
        var linked = new DoublyLinkedList<int>();
        var enumerator = linked.GetEnumerator();

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void MoveNext_WhenCurrIsNull_SetsCurrToHeadAndReturnsTrue()
    {
        var linked = new DoublyLinkedList<int>(new int[] { 0 });
        var enumerator = linked.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal(0, enumerator.Current);
    }

    [Fact]
    public void MoveNext_WhenCurrIsNotNullAndNextIsNotNull_SetsCurrToNextAndReturnsTrue()
    {
        var linked = new DoublyLinkedList<int>(new int[] { 0, 5 });
        var enumerator = linked.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal(0, enumerator.Current);
        Assert.True(enumerator.MoveNext());
        Assert.Equal(5, enumerator.Current);
    }

    [Fact]
    public void MoveNext_WhenCurrIsNotNullAndNextIsNull_ReturnsFalse()
    {
        var linked = new DoublyLinkedList<int>(new int[] { 0 });
        var enumerator = linked.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void Reset_SetsHeadTailAndCurrToNull()
    {
        var linked = new DoublyLinkedList<int>(new int[] { 6 });
        var enumerator = linked.GetEnumerator();

        Assert.True(enumerator.MoveNext());
        Assert.Equal(6, enumerator.Current);

        enumerator.Reset();
        Assert.Equal(0,enumerator.Current);
    }
}
