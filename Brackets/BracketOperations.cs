using Stack;
using Stack.ADT;

namespace Brackets
{
    public class BracketOperations
    {
        // String: void main(){int[] list = new int[4];}
        // Bool: True/False, Int: Number
        // { -> } - [ -> ] - ( -> )
        // Stack: Açma->Push / Kapatma -> Pop
        IStack<char> stack;
        Dictionary<char, char> brackets;

        public BracketOperations()
        {
            stack = new LinkedListStack<char>();
            brackets = new Dictionary<char, char>()
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' }
            };
        }

        public bool Checker(string code)
        {
            foreach (var item in code)
            {
                // Açma
                if (brackets.ContainsKey(item))
                    stack.Push(item);

                // Kapatma
                if (brackets.ContainsValue(item))
                {
                    if (stack.Count == 0)
                        return false;
                    else
                    {
                        var open = stack.Peek();
                        var close = brackets[open];
                        if (!close.Equals(item))
                            return false;
                        stack.Pop();
                    }
                }
            }

            if (stack.Count != 0)
                return false;
            return true;
        }

        public int CheckerAsNumber(string code)
        {
            int falseCount = 0;
            foreach (var item in code)
            {
                // Açma
                if (brackets.ContainsKey(item))
                    stack.Push(item);

                // Kapatma
                if (brackets.ContainsValue(item))
                {
                    if (stack.Count == 0)
                        falseCount++;
                    else
                    {
                        var open = stack.Peek();
                        var close = brackets[open];
                        if (!close.Equals(item))
                            falseCount++;
                        stack.Pop();
                    }
                }
            }

            return falseCount;
        }

        public Dictionary<char, int> CheckerAsArray(string code)
        {
            Dictionary<char, int> falseDict = new Dictionary<char, int>()
            {
                {'{', 0 },
                {'[', 0 },
                {'(', 0 },
                {')', 0 },
                {']', 0 },
                {'}', 0 }
            };

            foreach (var item in code)
            {
                // Açma
                if (brackets.ContainsKey(item))
                    stack.Push(item);

                // Kapatma
                if (brackets.ContainsValue(item))
                {
                    if (stack.Count == 0)
                        falseDict[item] = falseDict[item]++;
                    else
                    {
                        var open = stack.Peek();
                        var close = brackets[open];
                        if (!close.Equals(item))
                        {
                            falseDict[item] = falseDict[item]++;
                            falseDict[open] = falseDict[open]++;
                        }

                        stack.Pop();
                    }
                }
            }

            while (stack.Count > 0)
            {
                var item = stack.Pop();
                falseDict[item] = falseDict[item]++;
            }


            return falseDict;
        }
    }
}
