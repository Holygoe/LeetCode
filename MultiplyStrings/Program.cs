using System;
using System.Collections.Generic;

namespace MultiplyStrings
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var num1 = "408";
            var num2 = "5";
            var num3 = Multiply(num1, num2);
            
            Console.WriteLine($"{num1}\n{num2}\n{num3}");
        }
        
        private static string Multiply(string num1, string num2)
        {
            var a = ConvertStringToNumbers(num1);
            var b = ConvertStringToNumbers(num2);
            var c = new List<int>();
            
            for (var i = 0; i < a.Length; i++)
            {
                var carry = 0;
                
                for (var j = 0; j < b.Length; j++)
                {
                    var k = i + j;

                    if (c.Count <= k)
                    {
                        c.Add(0);
                    }

                    c[k] += a[i] * b[j] + carry;
                    carry = c[k] / 10;
                    c[k] %= 10;
                }

                if (carry > 0)
                {
                    c.Add(carry);
                }
            }
            
            return ConvertNumbersToString(c);
        }

        private static int[] ConvertStringToNumbers(string stringNum)
        {
            var result = new int[stringNum.Length];
            var numIndex = 0;
            const int offset = '0';

            for (var strIndex = stringNum.Length - 1; strIndex >= 0; strIndex--)
            {
                result[numIndex++] = stringNum[strIndex] - offset;
            }

            return result;
        }

        private static string ConvertNumbersToString(List<int> numbers)
        {
            var numberCount = numbers.Count;

            while (numbers[numberCount - 1] == 0)
            {
                numberCount--;

                if (numberCount == 0) return "0";
            }
            
            var result = string.Create(numberCount,  numbers, (span, nums) =>
            {
                var strIndex = 0;
                const int offset = '0';
                
                for (var numIndex = numberCount - 1; numIndex >= 0; numIndex--)
                {
                    span[strIndex++] = (char)(nums[numIndex] + offset);
                }
            });
            
            return result;
        }
    }
}