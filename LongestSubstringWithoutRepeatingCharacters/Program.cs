using System;
using System.Collections;
using System.Collections.Generic;

namespace LongestSubstringWithoutRepeatingCharacters
{
    /// <summary>
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            Test("abcabcbb", 3);
            Test("bbbbb", 1);
            Test("pwwkew", 3);
            Test("", 0);
        }

        private static void Test(string s, int expected)
        {
            Console.WriteLine($"String: '{s}'");
            Console.WriteLine($"Expected: {expected}");

            var result = LengthOfLongestSubstring(s);
            Console.WriteLine($"Result: {result} is {result == expected}\n");
        }
        
        private static int LengthOfLongestSubstring(string s)
        {
            var set = new HashSet<char>();
            var queue = new Queue<char>();
            var maxLength = 0;
            
            foreach (var c in s)
            {
                if (set.Add(c))
                {
                    queue.Enqueue(c);
                    continue;
                }
                
                CheckSet(queue, ref maxLength);
                
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    set.Remove(current);

                    if (current == c) break;
                }
                
                queue.Enqueue(c);
                set.Add(c);
            }
            
            CheckSet(queue, ref maxLength);
            
            return maxLength;
        }

        private static void CheckSet(ICollection queue, ref int maxLength)
        {
            var currentLength = queue.Count;

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
            }
        }
    }
}