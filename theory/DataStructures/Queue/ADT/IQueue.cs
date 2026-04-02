namespace Queue.ADT
{
    public interface IQueue<T>
    {
        public void Enqueue(T item);
        public T Dequeu();
        public T Peek();
        public void Clear();
        public int Count { get; }
        public bool IsEmpty { get; }
    }
}
