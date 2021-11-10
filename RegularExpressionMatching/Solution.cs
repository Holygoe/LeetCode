using System;
using System.Collections.Generic;

namespace RegularExpressionMatching
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            return IsMatching(s, 0, p, 0);
        }

        private static bool IsMatching(string s, int i, string p, int j)
        {
            if (j >= p.Length) return i >= s.Length;
            
            var firstMatch = i < s.Length && (p[j] == s[i] || p[j] == '.');

            if (p.Length >= j + 2 && p[j + 1] == '*')
            {
                return IsMatching(s, i, p, j + 2) || firstMatch && IsMatching(s, i + 1, p, j);
            }

            return firstMatch && IsMatching(s, i + 1, p, j + 1);
        }
        
        public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            CountFruit(a, apples);
            CountFruit(b, oranges);
            
            void CountFruit(int fruitTree, List<int> fruits)
            {
                var count = 0;
            
                foreach(var fruit in fruits)
                {
                    var position = fruitTree + fruit;
                    
                    if (position >= s && position <= t)
                    {
                        count++;
                    }
                }
                
                Console.WriteLine(count);
            }
        }
    }
}