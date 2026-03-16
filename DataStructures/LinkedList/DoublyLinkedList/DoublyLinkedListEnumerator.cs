using System.Collections;

namespace LinkedList.DoublyLinkedList;

public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
{
    private DoublyLinkedListNode<T>? _head;
    private DoublyLinkedListNode<T>? _current;
    
    public DoublyLinkedListEnumerator(DoublyLinkedListNode<T>? head)
    {
        _head = head;
        _current = null;
    }

    public T? Current => _current != null ? _current.Item : default;

    object? IEnumerator.Current => Current;

    public void Dispose()
    {
        // Dispose edilecek kaynak yok
    }

    public bool MoveNext()
    {
        if (_current == null)
        {
            _current = _head;
        }
        else
        {
            _current = _current.Next;
        }

        return _current != null;
    }

    public void Reset()
    {
        _current = null;
    }
}
