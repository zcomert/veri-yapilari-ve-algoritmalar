using LinkedList;

var linkedList = new SinglyLinkedList<String>();
linkedList.AddFirst("Zeki");
linkedList.AddFirst("Veysel");
linkedList.AddFirst("Kadir");
linkedList.AddFirst("Emre");
linkedList.AddFirst("Hakan");

foreach (var item in linkedList)
{
    Console.WriteLine(item);
}