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

        [Fact]
        public void Merge_Two_Non_Empty_Lists_Test()
        {
            var list1 = new SinglyLinkedList<int>();
            list1.AddLast(1);
            list1.AddLast(2);
            list1.AddLast(3); // list1: 1 -> 2 -> 3 (Count: 3)

            var list2 = new SinglyLinkedList<int>();
            list2.AddLast(4);
            list2.AddLast(5);
            list2.AddLast(6); // list2: 4 -> 5 -> 6 (Count: 3)

            list1.Merge(list2); // list1: 1 -> 2 -> 3 -> 4 -> 5 -> 6 (Count: 6)

            Assert.Equal(6, list1.Count);
            Assert.Equal(1, list1.Head.Item);
            Assert.Equal(2, list1.Head.Next.Item);
            Assert.Equal(3, list1.Head.Next.Next.Item);
            Assert.Equal(4, list1.Head.Next.Next.Next.Item);
            Assert.Equal(5, list1.Head.Next.Next.Next.Next.Item);
            Assert.Equal(6, list1.Head.Next.Next.Next.Next.Next.Item);
            Assert.Null(list1.Head.Next.Next.Next.Next.Next.Next);

            // Ensure list2 remains intact as its nodes are now part of list1
            Assert.Equal(3, list2.Count);
            Assert.Equal(4, list2.Head.Item);
            Assert.Equal(5, list2.Head.Next.Item);
            Assert.Equal(6, list2.Head.Next.Next.Item);
        }

        [Fact]
        public void Merge_With_Empty_OtherList_Test()
        {
            var list1 = new SinglyLinkedList<int>();
            list1.AddLast(1);
            list1.AddLast(2); // list1: 1 -> 2 (Count: 2)

            var list2 = new SinglyLinkedList<int>(); // list2: empty (Count: 0)

            list1.Merge(list2); // list1: 1 -> 2 (Count: 2)

            Assert.Equal(2, list1.Count);
            Assert.Equal(1, list1.Head.Item);
            Assert.Equal(2, list1.Head.Next.Item);
            Assert.Null(list1.Head.Next.Next);

            // Ensure list2 remains empty
            Assert.Equal(0, list2.Count);
            Assert.Null(list2.Head);
        }

        [Fact]
        public void Merge_With_ThisList_Empty_Test()
        {
            var list1 = new SinglyLinkedList<int>(); // list1: empty (Count: 0)

            var list2 = new SinglyLinkedList<int>();
            list2.AddLast(4);
            list2.AddLast(5); // list2: 4 -> 5 (Count: 2)

            list1.Merge(list2); // list1: 4 -> 5 (Count: 2)

            Assert.Equal(2, list1.Count);
            Assert.Equal(4, list1.Head.Item);
            Assert.Equal(5, list1.Head.Next.Item);
            Assert.Null(list1.Head.Next.Next);

            // Ensure list2 remains intact as its nodes are now part of list1
            Assert.Equal(2, list2.Count);
            Assert.Equal(4, list2.Head.Item);
            Assert.Equal(5, list2.Head.Next.Item);
        }

        [Fact]
        public void Merge_Both_Lists_Empty_Test()
        {
            var list1 = new SinglyLinkedList<int>(); // list1: empty (Count: 0)
            var list2 = new SinglyLinkedList<int>(); // list2: empty (Count: 0)

            list1.Merge(list2); // list1: empty (Count: 0)

            Assert.Equal(0, list1.Count);
            Assert.Null(list1.Head);

            // Ensure list2 remains empty
            Assert.Equal(0, list2.Count);
            Assert.Null(list2.Head);
        }
    }
}