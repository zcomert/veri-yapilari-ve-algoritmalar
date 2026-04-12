int a = 5;
int b = a;
a = a + 1;
Console.WriteLine(a); // 6
Console.WriteLine(b); // 5

List<int> list1 = new List<int>() { 1, 2, 3 };
List<int> list2 = list1;
list2.Add(55);
Console.WriteLine(list1.Count); // 3 4
Console.WriteLine(list2.Count); // 4 4 