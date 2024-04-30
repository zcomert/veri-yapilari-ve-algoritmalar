// Bu şekilde bir ikili ağaç (binary tree) oluşturalım. 

//         1 
//      /     \ 
//     10      20 
//    /  \    /  \
//   40  60  23   50

using DataStructures.Trees.BinaryTree;

var root = new Node<int>(1);

root.Left = new Node<int>(10);  
root.Right = new Node<int>(20);

root.Left.Left = new Node<int>(40);
root.Left.Right = new Node<int>(60);

root.Right.Left = new Node<int>(23);
root.Right.Right = new Node<int>(50);