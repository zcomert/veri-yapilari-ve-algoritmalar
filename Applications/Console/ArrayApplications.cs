using DataStructures.Array;

public class ArrayApplications
{
    public static void ArraySample()
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
            Console.WriteLine(numbers.GetItem(i));
        }

        Console.WriteLine($"Number of items in array: {numbers.Count}");
    }

    public static void StaticArraySample()
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
}