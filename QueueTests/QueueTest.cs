using Queue;
using Queue.ADT;

namespace QueueTests
{
    public class QueueTest
    {
        [Fact]
        public void QueueArray_Enqueue_Test()
        {
            IQueue<int> queue = new QueueArray<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(3, queue.Count);
            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void QueueArray_Dequeueu_Test()
        {
            IQueue<int> queue = new QueueArray<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var item = queue.Dequeu();
            var item2 = queue.Dequeu();

            Assert.Equal((int)1, item);
            Assert.Equal((int)2, item2);
            Assert.Equal(1, queue.Count);
            Assert.Equal(3, queue.Peek());
        }

        [Fact]
        public void QueueLinkedList_Enqueue_Test()
        {
            IQueue<int> queue = new QueueLinkedList<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(3, queue.Count);
            Assert.Equal(1, queue.Peek());
        }

        [Fact]
        public void QueueLinkedList_Dequeueu_Test()
        {
            IQueue<int> queue = new QueueLinkedList<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var item = queue.Dequeu();
            var item2 = queue.Dequeu();

            Assert.Equal((int)1, item);
            Assert.Equal((int)2, item2);
            Assert.Equal(1, queue.Count);
            Assert.Equal(3, queue.Peek());
        }
    }
}