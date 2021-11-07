using System;
using System.Collections.Generic;

namespace TwoSum
{
    internal static class Program
    {
        private static void Main()
        {
            MakeTaskCondition(10, out var nums, out var target, out var output);
            PrintTask(nums, target);
            
            var resolve = TwoSum(nums, target);
            PrintResolve(null, resolve);

            var hashResolve = TwoSumByHash(nums, target);
            PrintResolve("Hash", hashResolve);
        }

        private static void PrintResolve(string name, int[] resolve)
        {
            Console.WriteLine($"Output {name} {resolve[0]}, {resolve[1]}");
        }
        
        private static void MakeTaskCondition(int size, out int[] nums, out int target, out int[] output)
        {
            nums = new int[size];
            const int minValue = 1, maxValue = 10;

            var random = new Random();
            
            for (var i = 0; i < size; i++)
            {
                nums[i] = random.Next(minValue, maxValue);
            }

            var left = random.Next(size - 1);
            var right = random.Next(left + 1, size);
            
            target = nums[left] + nums[right];
            output = new[] { left, right };
        }

        private static void PrintTask(int[] num, int target)
        {
            Console.Write($"Input [{num[0]}");

            for (var i = 1; i < num.Length; i++)
            {
                Console.Write($", {num[i]}");
            }
            
            Console.WriteLine($"] target {target}");
        }
        
        private static int[] TwoSum(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            throw new Exception("There is no resolves");
        }
        
        private static int[] TwoSumByHash(int[] nums, int target)
        {
            var dict = new Dictionary<int, List<int>>(nums.Length);

            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.TryGetValue(nums[i], out var list))
                {
                    list.Add(i);
                }
                else
                {
                    dict.Add(nums[i], new List<int> { i });
                }
            }

            for (var i = 0; i < nums.Length - 1; i++)
            {
                var diff = target - nums[i];

                if (!dict.TryGetValue(diff, out var list)) continue;
                
                foreach (var j in list)
                {
                    if (i == j) continue;

                    return new[] { i, j };
                }
            }

            throw new Exception("There is no resolves");
        }
    }
}