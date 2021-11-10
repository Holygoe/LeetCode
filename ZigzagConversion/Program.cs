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
            var solution = new Solution();

            foreach (var task in Tasks)
            {
                Test(solution, task);
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