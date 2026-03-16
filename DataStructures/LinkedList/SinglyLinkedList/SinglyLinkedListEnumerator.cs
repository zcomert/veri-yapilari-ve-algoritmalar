
using System.Collections;

namespace LinkedList.SinglyLinkedList;

public class SinglyLinkedListEnumerator<T> : IEnumerator<T>
{
    private SinglyLinkedListNode<T> _head;
    private SinglyLinkedListNode<T> _current;
    public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
    {
        _head = head;
        _current = null; // Başlangıçta null, ilk MoveNext çağrısında head'e gider
    }
    public T Current => _current.Item;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        // Dispose edilecek kaynak yok
    }

    public bool MoveNext()
    {
        if (_current == null)
        {
            // İlk çağrı - head'e git
            _current = _head;
        }
        else
        {
            // Sonraki elemana geç
            _current = _current.Next;
        }

        return _current != null;
    }

    public void Reset()
    {
        _current = null; // Başlangıç pozisyonuna dön
    }
}