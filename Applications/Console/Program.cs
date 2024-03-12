using DataStructures.Array;
using DataStructures.LinkedList.Singly;

var linkedlist = new SinglyLinkedList<String>();
linkedlist.AddFirst("Esat");
linkedlist.AddFirst("İrem");
linkedlist.AddFirst("Rabia");
linkedlist.AddFirst("Yuşa");
linkedlist.AddFirst("İsmail");

var c = linkedlist.Head;

while(c!=null){
    System.Console.WriteLine(c);
    c = c.Next;
}

// foreach (var item in linkedlist)
// {
//     System.Console.WriteLine(item);
// }













static void StaticArraySample()
{
    var names = new StaticArray<String>();

    names.SetItem(0, "Enes");
    names.SetItem(1, "Emre");
    names.SetItem(2, "Gülsüm");
    names.SetItem(3, "Peri");
    // names.SetItem(4,"Emircan");

    for (int i = 0; i < names.Length; i++)
    {
        System.Console.WriteLine(names.GetItem(i));
    }

    Console.ReadLine();
}

static void ArraySample()
{
    var numbers = new DataStructures.Array.Array<int>();
    numbers.Add(10);
    numbers.Add(20);
    numbers.Add(30);
    numbers.Add(40);
    numbers.Add(50);
    numbers.Add(60);
    numbers.Add(70);
    numbers.Add(80);
    // numbers.Add(90);

    numbers.RemoveAt(7);

    for (int i = 0; i < numbers.Length; i++)
    {
        System.Console.WriteLine(numbers.GetItem(i));
    }

    System.Console.WriteLine($"Number of items in array: {numbers.Count}");
}