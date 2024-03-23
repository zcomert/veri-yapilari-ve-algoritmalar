using DataStructures.LinkedList.Singly;
using Xunit;

namespace Tests.LinkedListTests;
public class SinglyLinkedListEnumeratorTests
{
    [Fact]
    public void Enumerator_MoveNext_ShouldReturnTrueWhenListIsNotEmpty()
    {
        // Arrange
        var list = new SinglyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);

        // var enumerator = list.GetEnumerator();
        var enumerator = new SinglyLinkedListEnumerator<int>(list.Head);

        Assert.True(enumerator.MoveNext());
        Assert.Equal(1, enumerator.Current); // Curr.Value
    }

    [Fact]
    public void Enumerator_MoveNext_ShouldReturnFalseWhenListIsEmpty()
    {
        // Arrange
        var list = new SinglyLinkedList<int>();
        var enumerator = new SinglyLinkedListEnumerator<int>(list.Head);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void Enumerator_Reset_ShouldResetCurrentToNull()
    {
        // Arrange
        var list = new SinglyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        var enumerator = new SinglyLinkedListEnumerator<int>(list.Head);

        // Act
        enumerator.MoveNext();
        var item = enumerator.Current;
        enumerator.Reset();
        Assert.Throws<NullReferenceException>(() => enumerator.Current);

        // Assert
        Assert.Equal(1, item);
        Assert.Equal(null, enumerator.Curr);
    }

    [Fact]
    public void Enumerator_Dispose_ShouldSetHeadToNull()
    {
        // Arrange
        var list = new SinglyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        var enumerator = new SinglyLinkedListEnumerator<int>(list.Head);

        // Act
        enumerator.Dispose();

        // Assert
        Assert.Null(enumerator.Head);
    }

    [Fact]
    public void Enumerator_Current_ShouldReturnCurrentValue()
    {
        // Arrange
        var list = new SinglyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        var enumerator = new SinglyLinkedListEnumerator<int>(list.Head);

        // Act
        enumerator.MoveNext();
        var item = enumerator.Current;
        enumerator.MoveNext();
        var item2 = enumerator.Current;
        enumerator.MoveNext();

        // Assert
        Assert.Equal(1, item);
        Assert.Equal(2, item2);
        Assert.Equal(2, enumerator.Curr.Value);
    }
}
