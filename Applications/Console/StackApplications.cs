public static class StackApplications
{
    public static void ReverseExample()
    {
        var stack = new DataStructures.Stack.Stack<char>();

        foreach (var ch in "akif silan")
        {
            stack.Push(ch);
        }

        var temp = stack.Count;

        for (var i = 0; i < temp; i++)
        {
            System.Console.WriteLine(stack.Pop());
        }
    }
}