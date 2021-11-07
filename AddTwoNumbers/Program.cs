using System;

namespace AddTwoNumbers
{
    internal static class Program
    {
        private static void Main()
        {
            Test(new[] { 0, 1, 3, 4, 5 }, new[] { 1, 1, 9, 3, 4 }, new[] { 1, 2, 2, 8, 9 });
        }

        private static void Test(int[] a, int[] b, int[] expected)
        {
            var aNumber = new LinkedNumber(a);
            var bNumber = new LinkedNumber(b);
            var expectedNumber = new LinkedNumber(expected);
            var result = aNumber + bNumber;
            
            Console.WriteLine($"a: {aNumber}\nb: {bNumber}\nresult: {result}\nexpected: {expectedNumber}\n{result.Equals(expectedNumber)}\n");
        }
    }
}