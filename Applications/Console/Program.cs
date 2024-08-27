using DataStructures.Trees.AVL;

var avltree = new AVLTree<int>();

var numbers = new int[] { 10, 20, 30, 40, 50 };

foreach (var item in numbers)
{
    avltree.Insert(item);
}

// AVL ağacındaki tüm elemanları ekrana yazdırma
// avltree.InOrderTraversal(value => Console.WriteLine(value));

System.Console.WriteLine(avltree?.root?.Value);                 // 20
System.Console.WriteLine(avltree?.root?.Left?.Value);           // 10 
System.Console.WriteLine(avltree?.root?.Right?.Value);          // 40
System.Console.WriteLine(avltree?.root?.Right?.Left?.Value);    // 30 
System.Console.WriteLine(avltree?.root?.Right?.Right?.Value);   // 50

Console.ReadKey();



