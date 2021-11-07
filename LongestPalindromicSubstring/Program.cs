using System;

namespace LongestPalindromicSubstring
{
    internal static class Program
    {
        private static void Main()
        {
            Test("babad", "bab");
            Test("cbbd", "bb");
            Test("a", "a");
            Test("ccc", "ccc");
        }

        private static void Test(string input, string expectation)
        {
            var result = LongestPalindrome(input);
            Console.WriteLine($"Input: '{input}', result: '{result}', expect: '{expectation} — {result == expectation}");
        }
        
        private static string LongestPalindrome(string s)
        {
            var sLength = s.Length;
            
            if (sLength == 0) return "";
            
            (int start, int legth) bestResult = (0, 1);

            var minorSLength = sLength - 1; 
            
            for (var i = 0; i < minorSLength; i++)
            {
                var maxPossibleLength = (sLength - i) * 2 + 1;

                if (maxPossibleLength < bestResult.legth) break;

                LookForPalindromeInPoint(s, i, sLength, 1, 0, ref bestResult);
                LookForPalindromeInPoint(s, i, sLength, 0, 1, ref bestResult);
            }

            return s.Substring(bestResult.start, bestResult.legth);
        }

        private static void LookForPalindromeInPoint(
            string s, 
            int i,
            int sLength,
            int startArm, 
            int addArm,
            ref (int start, int length) bestResult)
        {
            int arm;

            for (arm = startArm; i - arm >= 0 && i + arm < sLength - addArm; arm++)
            {
                var left = i - arm;
                var right = i + arm + addArm;

                if (s[left] != s[right]) break;
            }

            arm--;
            var length = arm * 2 + addArm + 1;

            if (length > bestResult.length)
            {
                bestResult = (i - arm, length);
            }
        }
    }
}