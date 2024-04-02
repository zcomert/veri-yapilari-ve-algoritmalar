using DataStructures.LinkedList.Singly;

public class LinkedListApplications
{
    public static void LinkedListSample()
    {
        var linkedlist = new SinglyLinkedList<String>();
        linkedlist.AddFirst("Esat");
        linkedlist.AddFirst("İrem");
        linkedlist.AddFirst("Rabia");
        linkedlist.AddFirst("Yuşa");
        linkedlist.AddFirst("İsmail");

        var c = linkedlist.Head;

        // while(c!=null){
        //     System.Console.WriteLine(c);
        //     c = c.Next;
        // }

        // foreach (var item in linkedlist)
        // {
        //     if(item.Contains("a"))
        //     {
        //         Console.WriteLine(item);
        //     } 
        // }

        linkedlist
            .Where(item => item.Contains("a"))
            .ToList()
            .ForEach(item => System.Console.WriteLine(item));
    }


    public static void LinkedListSample02()
    {
        var arr = new int[] { 53, 42, 52, 55, 26, 37, 27, 41, 5, 72 };
        var numbers = new SinglyLinkedList<int>(arr);

        foreach (var item in numbers)
        {
            System.Console.WriteLine(item);
        }
        var agg = numbers.Sum(n => n);
        System.Console.WriteLine($"sum: {agg}");

        foreach (var item in numbers)
        {
            if (item % 2 == 0)
            {
                System.Console.WriteLine(item);
            }
        }

        var doubleagg = numbers
            .Where(item => item % 2 == 0)
            .Sum(item => item);

        System.Console.WriteLine($"doubleagg: {doubleagg}");
    }
}
