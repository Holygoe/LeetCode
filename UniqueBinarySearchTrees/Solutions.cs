using System;
using System.Globalization;

namespace UniqueBinarySearchTrees
{
    public class Solutions
    {
        public int NumTrees(int n)
        {
            var row = new int[n + 1];
            row[0] = 1;
            row[1] = 1;
        
            for (var i = 2; i <= n; i++)
            {
                var sum = 0;
                var left = i - 1;
                var right = 0;
            
                while (left >= right)
                {
                    var step = row[left] * row[right];
                
                    if (left != right)
                    {
                        step *= 2;
                    }

                    sum += step;
                
                    left--;
                    right++;
                }
            
                row[i] = sum;
            }
        
            return row[n];
        }
        
        public int NumTreesNonAlloc(int n)
        {
            if (n == 0 || n == 1) return 1;
            
            var sum = 0;
            var left = n - 1;
            var right = 0;
            
            while (left >= right)
            {
                var step = NumTreesNonAlloc(left) * NumTreesNonAlloc(right);
                
                if (left != right)
                {
                    step *= 2;
                }

                sum += step;
                
                left--;
                right++;
            }
        
            return sum;
        }
        
        public unsafe int NumTreesStackAlloc(int n)
        {
            if (n == 0 || n == 1) return 1;
            
            var row = stackalloc int[n + 1];
            row[0] = 1;
            row[1] = 1;
        
            for (var i = 2; i <= n; i++)
            {
                var sum = 0;
                var left = i - 1;
                var right = 0;
            
                while (left >= right)
                {
                    var step = row[left] * row[right];
                
                    if (left != right)
                    {
                        step *= 2;
                    }

                    sum += step;
                
                    left--;
                    right++;
                }
                
                row[i] = sum;
            }
        
            return row[n];
        }
        
        private static unsafe int GetRowItem(int i, int* row)
        {
            var sum = 0;
            var left = i - 1;
            var right = 0;
            
            while (left >= right)
            {
                var step = row[left] * row[right];
                
                if (left != right)
                {
                    step *= 2;
                }

                sum += step;
                
                left--;
                right++;
            }

            return sum;
        }
        
        public static string timeConversion(string s)
        {
            var dt = DateTime.ParseExact(s, "h:mm:ss", CultureInfo.InvariantCulture);
        
            return dt.ToString("hh:mm:ss");
        }  

    }
}