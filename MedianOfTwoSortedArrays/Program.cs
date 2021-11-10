using System;
using System.Text;

namespace MedianOfTwoSortedArrays
{
    internal static class Program
    {
        private static void Main()
        {
            Test(new []{1, 3}, new []{2}, 2);
            Test(new []{1, 2}, new []{3, 4}, 2.5);
            Test(new []{0, 0}, new []{0, 0}, 0);
            Test(Array.Empty<int>(), new []{1}, 1);
            Test(new []{2}, Array.Empty<int>(), 2);
            Test(Array.Empty<int>(), new []{1, 2, 3, 4}, 2.5);
        }

        private static void Test(int[] nums1, int[] nums2, double expected)
        {
            Console.WriteLine($"\nInput: {nameof(nums1)} = {nums1.ToStr()}, {nameof(nums2)} = {nums2.ToStr()}");
            var result = FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"Result: {result}, expected: {expected} — {Math.Abs(result - expected) < 0.00001}");
        }
        
        private static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var totalLength = nums1.Length + nums2.Length;
            double result;
            
            if (totalLength % 2 == 0)
            {
                var stepCount = totalLength / 2 - 1;

                result = GoThrough(stepCount, nums1, nums2, 2);
            }
            else
            {
                var stepCount = (totalLength - 1) / 2;

                result = GoThrough(stepCount, nums1, nums2, 1);
            }
            
            return result;
        }

        private static double GoThrough(int stepCount, int[] nums1, int[] nums2, int medianSize)
        {
            int i1 = 0, i2 = 0, step = 0;

            while (step < stepCount)
            {
                if (i1 >= nums1.Length)
                {
                    var rest = stepCount - step;
                    i2 += rest;

                    if (medianSize == 1)
                    {
                        return nums2[i2];
                    }
                    
                    return (nums2[i2] + nums2[i2 + 1]) / (double)medianSize;
                }

                if (i2 >= nums2.Length)
                {
                    var rest = stepCount - step;
                    i1 += rest;

                    if (medianSize == 1)
                    {
                        return nums1[i1];
                    }
                    
                    return (nums1[i1] + nums1[i1 + 1]) / (double)medianSize;
                }
                
                step++;

                if (nums1[i1] <= nums2[i2])
                {
                    i1++;
                }
                else
                {
                    i2++;
                }
            }

            var result = 0.0;
            
            for (var i = 0; i < medianSize; i++)
            {
                if (i1 >= nums1.Length)
                {
                    result += nums2[i2];
                    i2++;
                }
                else if (i2 >= nums2.Length)
                {
                    result += nums1[i1];
                    i1++;
                }
                else if (nums1[i1] <= nums2[i2])
                {
                    result += nums1[i1];
                    i1++;
                }
                else
                {
                    result += nums2[i2];
                    i2++;
                }
            }
            
            return result / medianSize;
        }
    }

    public static class ArrayExtensions
    {
        public static string ToStr(this int[] nums)
        {
            if (nums.Length == 0) return "[]";
            
            var builder = new StringBuilder($"[{nums[0]}");

            for (var i = 1; i < nums.Length; i++)
            {
                builder.Append($", {nums[i]}");
            }

            builder.Append("]");
            
            return builder.ToString();
        }
    }
}