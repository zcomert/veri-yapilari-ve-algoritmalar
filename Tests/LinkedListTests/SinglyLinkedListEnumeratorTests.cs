using DataStructures.LinkedList.Singly;
using Xunit;

namespace LinkedListTests;
public class SinglyLinkedListEnumeratorTests
{
    [Fact]
    public void Enumerator_MoveNext_ShouldReturnTrueWhenListIsNotEmpty()
    {
        // Arrange
        var list = new SinglyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        var enumerator = new SinglyLinkedListEnumerator<int>(list.Head);


    }

    [Fact]
    public void Enumerator_MoveNext_ShouldReturnFalseWhenListIsEmpty()
    {
        // Arrange
        var list = new SinglyLinkedList<int>();
        var enumerator = new SinglyLinkedListEnumerator<int>(list.Head);
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

        // Assert
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


        // Assert

    }
}
