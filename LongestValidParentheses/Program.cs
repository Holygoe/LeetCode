const string s = ")()())";
var solution = new Solution();
var result = solution.LongestValidParentheses(s);
Console.WriteLine(result);

public class Solution
{
    public int LongestValidParentheses(string s)
    {
        var maxFoundLength = 0;
        var wellFormedLength = 0;
        var braces = new Stack<int>();
        
        foreach(var c in s)
        {
            if (c == '(')
            {
                wellFormedLength++;
                braces.Push(wellFormedLength);
                continue;
            }

            if (braces.Count == 0)
            {
                wellFormedLength = 0;
                continue;
            }

            wellFormedLength++;
            braces.Pop();

            if (braces.Count == 0)
            {
                if (wellFormedLength > maxFoundLength)
                {
                    maxFoundLength = wellFormedLength;
                }
                
                continue;
            }

            var lastOpeningBrace = braces.Peek();
            var candidate = wellFormedLength - lastOpeningBrace;
            
            if (candidate > maxFoundLength)
            {
                maxFoundLength = candidate;
            }
        }

        return maxFoundLength;
    }
}