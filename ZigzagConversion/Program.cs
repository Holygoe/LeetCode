using System;

namespace ZigzagConversion
{
    internal static class Program
    {
        private static readonly Task[] Tasks =
        {
            new Task { s = "PAYPALISHIRING", numRows = 3, expectation = "PAHNAPLSIIGYIR" },
            new Task { s = "PAYPALISHIRING", numRows = 4, expectation = "PINALSIGYAHRPI" },
            new Task { s = "A", numRows = 1, expectation = "A" }
        };
        
        private static void Main()
        {
            // var solution = new Solution();
            //
            // foreach (var task in Tasks)
            // {
            //     Test(solution, task);
            // }

            var x = 1534236469;
            var result = 0;
            var isMinus = x < 0;
            var max = isMinus ? int.MinValue / 10 : int.MaxValue / 10;
            var maxRest = isMinus ? int.MinValue % 10 : int.MaxValue % 10;
        
            while (x != 0)
            {
                var rest = x % 10;
            
                if (isMinus && result <= max && rest < maxRest 
                    || !isMinus && result >= max && rest > maxRest)
                {
                    return;
                }
            
                result = result * 10 + rest;;
                x = (x - rest) / 10;
            }
        }

        private static void Test(Solution solution, Task task)
        {
            var result = solution.Convert(task.s, task.numRows);
            
            Console.WriteLine($"s '{task.s}', rows {task.numRows}, result '{result}', expect '{task.expectation}' — {result == task.expectation}");
        }
    }

    public class Task
    {
        public string s;
        public int numRows;
        public string expectation;
    }
}