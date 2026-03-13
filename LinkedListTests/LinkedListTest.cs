using LinkedList;

namespace LinkedListTests
{
    public class LinkedListTest
    {
        [Fact]
        public void Add_First_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);

            Assert.Equal(3, linkedList.Head.Item);
            Assert.Equal(2, linkedList.Head.Next.Item);
            Assert.Equal(1, linkedList.Head.Next.Next.Item);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void Add_Last_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.Equal(1, linkedList.Head.Item);
            Assert.Equal(2, linkedList.Head.Next.Item);
            Assert.Equal(3, linkedList.Head.Next.Next.Item);
            Assert.Equal(3, linkedList.Count);
        }

        [Fact]
        public void Add_After_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            var node = new SinglyLinkedListNode<int>(2);
            // var node = linkedList.Head.Next;
            linkedList.AddAfter(node, 5);

            Assert.Equal(1, linkedList.Head.Item);
            Assert.Equal(2, linkedList.Head.Next.Item);
            Assert.Equal(5, linkedList.Head.Next.Next.Item);
            Assert.Equal(3, linkedList.Head.Next.Next.Next.Item);
            Assert.Equal(4, linkedList.Count);
        }

        [Fact]
        public void Add_Before_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            var node = new SinglyLinkedListNode<int>(2);
            // var node = linkedList.Head.Next;
            linkedList.AddBefore(node, 5);

            Assert.Equal(1, linkedList.Head.Item);
            Assert.Equal(5, linkedList.Head.Next.Item);
            Assert.Equal(2, linkedList.Head.Next.Next.Item);
            Assert.Equal(3, linkedList.Head.Next.Next.Next.Item);
            Assert.Equal(4, linkedList.Count);
        }

        [Fact]
        public void Remove_First_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            Assert.Throws<Exception>(() => linkedList.RemoveFirst());

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.Equal(3, linkedList.Count);

            var item = linkedList.RemoveFirst();

            Assert.Equal(2, linkedList.Head.Item);
            Assert.Equal(3, linkedList.Head.Next.Item);
            Assert.Equal(1, item);
            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void Remove_Last_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            Assert.Throws<Exception>(() => linkedList.RemoveLast());
            
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            Assert.Equal(3, linkedList.Count);

            var item = linkedList.RemoveLast();

            Assert.Equal(1, linkedList.Head.Item);
            Assert.Equal(2, linkedList.Head.Next.Item);
            Assert.Equal(3, item);
            Assert.Equal(2, linkedList.Count);
        }

        [Fact]
        public void Remove_Test()
        {
            var linkedList = new SinglyLinkedList<int>();

            var node = new SinglyLinkedListNode<int>(3);
            Assert.Throws<Exception>(() => linkedList.Remove(node));

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            Assert.Equal(4, linkedList.Count);

            var item = linkedList.Remove(node);

            Assert.Equal(1, linkedList.Head.Item);
            Assert.Equal(2, linkedList.Head.Next.Item);
            Assert.Equal(4, linkedList.Head.Next.Next.Item);
            Assert.Equal(3, item);
            Assert.Equal(3, linkedList.Count);

            item = linkedList.Remove(new SinglyLinkedListNode<int>(4));
            Assert.Equal(1, linkedList.Head.Item);
            Assert.Equal(2, linkedList.Head.Next.Item);
            Assert.Equal(4, item);
            Assert.Equal(2, linkedList.Count);
        }
    }
}