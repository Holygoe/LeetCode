using System;
using LeetCodeLibrary;

namespace UniqueBinarySearchTreesII
{
    /// <summary>
    /// https://leetcode.com/problems/unique-binary-search-trees-ii/
    /// </summary>
    internal static class Program
    {
        private static void Main()
        {
            var tree = TreeNode.GetTree(2, 1, null, 2, 4, 5, 5, null, null, 4, 2, 1);
            
            Console.WriteLine(tree);
        }
    }
}