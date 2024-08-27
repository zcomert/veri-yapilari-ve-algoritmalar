using DataStructures.Trees.BinaryTree;

public static class BSTApplication
{
    public static void Run()
    {
        // Bu şekilde bir ikili ağaç (binary tree) oluşturalım. 

        //         1 
        //      /     \ 
        //     10      20 
        //    /  \    /  \
        //   40  60  23   50



        var bt = new BinaryTree<int>(new List<int>() { 1, 10, 20, 40, 60, 23, 50 });

        System.Console.WriteLine(bt.Root.Left.Left);

        foreach (var item in bt)
        {
            System.Console.WriteLine(item);
        }
    }
}