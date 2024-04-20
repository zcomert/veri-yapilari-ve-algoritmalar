using DataStructures.LinkedList.Doubly;

namespace Tests.LinkedListTests
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void Constructor_Default_HeadAndTailAreNull()
        {
            var linked = new DoublyLinkedList<String>();

            Assert.Equal(null, linked.Head);
            Assert.Equal(null, linked.Tail);
        }

        [Fact]
        public void Constructor_WithCollection_InitializesListCorrectly()
        {
            var linked = new DoublyLinkedList<char>("hello");

            Assert.Equal('h', linked.Head.Value);
            Assert.Equal('o', linked.Tail.Value);
        }

        [Fact]
        public void AddFirst_EmptyList_AddsFirstNode()
        {
            var linked = new DoublyLinkedList<char>();
            linked.AddFirst('a');

            Assert.Equal('a', linked.Head.Value);
        }

        [Fact]
        public void AddFirst_NotEmptyList_AddsFirstNode()
        {
            var linked = new DoublyLinkedList<char>("hello");
            linked.AddFirst('a');

            Assert.Equal('a', linked.Head.Value);
        }

        [Fact]
        public void AddLast_EmptyList_AddsLastNode()
        {
            var linked = new DoublyLinkedList<char>();
            linked.AddLast('a');

            Assert.Equal('a', linked.Tail.Value);
        }

        [Fact]
        public void AddLast_NotEmptyList_AddsLastNode()
        {
            var linked = new DoublyLinkedList<char>("hello");
            linked.AddLast('a');

            Assert.Equal('a', linked.Tail.Value);
        }

        [Fact]
        public void RemoveFirst_SingleNodeList_RemovesSingleNode()
        {
            var linked = new DoublyLinkedList<char>("h");
            var item = linked.RemoveFirst();

            Assert.True(item.Equals('h'));
        }

        [Fact]
        public void RemoveFirst_MultipleNodesList_RemovesFirstNode()
        {
            var linked = new DoublyLinkedList<char>("hello");
            var item = linked.RemoveFirst();
            var item2 = linked.RemoveFirst();

            Assert.True(item.Equals('h'));
            Assert.True(item2.Equals('e'));
        }

        [Fact]
        public void RemoveLast_SingleNodeList_RemovesSingleNode()
        {
            var linked = new DoublyLinkedList<char>("h");
            var item = linked.RemoveLast();

            Assert.True(item.Equals('h'));
        }

        [Fact]
        public void RemoveLast_MultipleNodesList_RemovesLastNode()
        {
            var linked = new DoublyLinkedList<char>("hello");
            var item = linked.RemoveLast();
            var item2 = linked.RemoveLast();

            Assert.True(item.Equals('o'));
            Assert.True(item2.Equals('l'));
        }
    }
}
