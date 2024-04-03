using System.Collections;

namespace DataStructures.LinkedList.Doubly
{
    public class DbLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DbNode<T> Head { get; set; }
        private DbNode<T> Tail { get; set; }
        public DbNode<T> Curr { get; set; }

        public DbLinkedListEnumerator()
        {

        }

        public DbLinkedListEnumerator(DbNode<T> head, DbNode<T> tail)
        {
            this.Head = head;
            this.Tail = tail;
            Curr = null;
        }

        public T Current => Curr != null ? Curr.Value : default;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
            Tail = null;
        }

        public bool MoveNext()
        {
            if (Head is null)
                return false;

            if (Curr is null)
            {
                Curr = Head;
                return true;
            }

            if (Curr.Next is not null)
            {
                Curr = Curr.Next;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            Head = null;
            Tail = null;
            Curr = null;
        }
    }
}