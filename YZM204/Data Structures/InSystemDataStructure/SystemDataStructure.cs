using Array;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InSystemDataStructure
{
    public class SystemDataStructure<T>
        where T : IComparable
    {
        Array.Array<T> array;
        LinkedList<T> list;
        Stack<T> stack;
        Queue<T> queue;

        public SystemDataStructure()
        {
            list = new LinkedList<T>();
            array = new Array.Array<T>();
            stack = new Stack<T>();
            queue = new Queue<T>();
        }

        public void Add(T item)
        {
            array.Add(item);
            list.AddFirst(item);
            stack.Push(item);
            queue.Enqueue(item);
        }

        public T GetValue(string typeOfDataStructure)
        {
            if (typeOfDataStructure == "array")
                return array[0];
            if (typeOfDataStructure == "linkedlist")
                return list.First.Value;
            if (typeOfDataStructure == "stack")
                return stack.Pop();
            if (typeOfDataStructure == "queue")
                return queue.Dequeue();

            else
                return default;
        }

        public T GetValueIndex(int index, string typeOfDataStructure)
        {
            if (typeOfDataStructure == "array")
                return array[index];
            if (typeOfDataStructure == "linkedlist")
            {
                var curr = list.First;
                for (int i = 0; i < index; i++)
                    curr = curr.Next;
                return curr.Value;
            }
            if (typeOfDataStructure == "stack")
            {
                T data = default;
                for (int i = 0; i < index; i++)
                {
                    data = stack.Pop();
                }
                return data;
            }
            else
                return default;
        }

    }
}
