using LinkedList.DoublyLinkedList;
using Queue.ADT;

namespace Queue
{
    public class QueueLinkedList<T> : IQueue<T>
    {
        private DoublyLinkedList<T> linkedList;

        public QueueLinkedList()
        {
            linkedList = new DoublyLinkedList<T>();
        }

        public int Count => linkedList.Count;

        public bool IsEmpty => linkedList.Count == 0;

        public void Clear()
        {
            linkedList = new DoublyLinkedList<T>();
        }

        public T Dequeu()
        {
            if (IsEmpty)
                throw new Exception("Queue is empty!");
            var item = linkedList.RemoveFirst();
            return item;
        }

        public void Enqueue(T item) => linkedList.AddLast(item);


        public T Peek()
        {
            if (IsEmpty)
                throw new Exception("Queue is empty!");
            return linkedList.Head.Item;
        }
    }
}
