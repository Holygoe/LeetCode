using System;

namespace RegularExpressionMatching
{
    internal static class Program
    {
        private static void Main()
        {
            Test();
        }

        private static void Test()
        {
            var count = Tests.Ss.Length;
            var solution = new Solution();

            for (var i = 0; i < count; i++)
            {
                var result = solution.IsMatch(Tests.Ss[i], Tests.Ps[i]);
                
                Console.WriteLine($"s '{Tests.Ss[i]}', p '{Tests.Ps[i]}, result: {result}', expects: {Tests.Expects[i]}");
            }
        }
    }

    public class Tests
    {
        public static readonly string[] Ss = { "aa", "aa", "ab", "aab", "mississippi", "aaa", "aaa" };
        
        public static readonly string[] Ps = { "a", "a*", ".*", "c*a*b", "mis*is*p*.", "a*a", "ab*a*c*a" };

        public static readonly bool[] Expects = { false, true, true, true, false, true, true };
    }
}