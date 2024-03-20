using DataStructures.LinkedList.Singly;

var linkedList = new SinglyLinkedList<int>(new int[]{1,2,3,4,5,6});
var curr = linkedList.GetEnumerator();

while(curr.MoveNext()){
    System.Console.WriteLine(curr.Current);
}