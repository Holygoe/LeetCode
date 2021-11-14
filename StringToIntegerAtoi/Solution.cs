namespace StringToIntegerAtoi
{
    public class Solution
    {
        public int MyAtoi(string s)
        {
            var result = 0L;
            var isMinus = false;
            
            using var text = s.GetEnumerator();

            while (text.MoveNext())
            {
                var c = text.Current;
                
                if (c == ' ') continue;

                if (c == '+') break;

                if (c == '-')
                {
                    isMinus = true;
                    break;
                }

                var num = c - '0';

                if (num >= 0 && num <= 9)
                {
                    result = num;
                    break;
                }

                return 0;
            }

            while (text.MoveNext())
            {
                var num = text.Current - '0';

                if (num < 0 || num > 9) break;

                if (isMinus)
                {
                    num = -num;
                }
                
                result = result * 10 + num;

                if (result < int.MinValue) return int.MinValue;

                if (result > int.MaxValue) return int.MaxValue;
            }
            
            return (int) result;
        }
    }
}