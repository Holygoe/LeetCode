using System;
using BenchmarkDotNet.Attributes;

namespace UniqueBinarySearchTrees
{
    internal static class Program
    {
        private static void Main()
        {
            //BenchmarkRunner.Run<Benchmarks>();

            Test(1, 1);
            Test(2, 2);
            Test(3, 5);
            Test(4, 14);
            Test(5, 42);
            Test(6, 132);
            Test(7, 429);
        }

        private static void Test(int input, int expected)
        {
            var solutions = new Solutions();
            var result = solutions.NumTreesNonAlloc(input);
            
            Console.WriteLine($"Input: {input}, result: {result}, expect: {expected} — {result == expected}");
        }
    }

    [MemoryDiagnoser]
    public class Benchmarks
    {
        private const int Min = 1, Max = 30;
        
        [Benchmark]
        public int NumTrees()
        {
            var solutions = new Solutions();
            
            for (var i = Min; i < Max; i++)
            {
                solutions.NumTrees(i);
            }
        
            return 0;
        }
        
        [Benchmark]
        public void NumTreesNonAlloc()
        {
            var solutions = new Solutions();
            
            for (var i = Min; i < Max; i++)
            {
                solutions.NumTreesNonAlloc(i);
            }
        }
        
        [Benchmark]
        public void NumTreesStackAlloc()
        {
            var solutions = new Solutions();
            
            for (var i = Min; i < Max; i++)
            {
                solutions.NumTreesStackAlloc(i);
            }
        }
    }
}