using DataStructures.Array;

var names = new StaticArray<String>();

names.SetItem(0,"Enes");
names.SetItem(1,"Emre");
names.SetItem(2,"Gülsüm");
names.SetItem(3,"Peri");
// names.SetItem(4,"Emircan");

for (int i = 0; i < names.Length; i++)
{
    System.Console.WriteLine(names.GetItem(i));
}

Console.ReadLine();