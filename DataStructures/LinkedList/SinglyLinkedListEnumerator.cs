
using System.Collections;

namespace LinkedList;

public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
{
    private Node<T> _head;
    private Node<T> _current;
    public SinglyLinkedListEnumerator(Node<T> head)
    {
        _head = head;
        _current = head;
    }
    public T Current => _current.Item;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        
    }

    public bool MoveNext()
    {
        if(_current.Next is not null)
        {
            _current = _current.Next;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        _current = _head;
    }
}