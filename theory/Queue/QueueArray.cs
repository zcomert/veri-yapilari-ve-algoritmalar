using Array;
using Queue.ADT;

namespace Queue
{
    public class QueueArray<T> : IQueue<T>
        where T : IComparable
    {
        Array<T> array;
        public QueueArray()
        {
            array = new Array<T>();
        }

        public int Count => array.Length;

        public bool IsEmpty => array.Length == 0;

        public void Clear()
        {
            array = new Array<T>();
        }

        public T Dequeu() => array.RemoveAt(0);

        public void Enqueue(T item) => array.Add(item);

        public T Peek() => array[0];
    }
}
