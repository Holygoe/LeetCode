namespace ZigzagConversion
{
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;
            
            var result = string.Create(s.Length, s, (result, origin) =>
            {
                var i = 0;
                var step = (numRows - 1) * 2;
                var j = 0;

                while (j < origin.Length)
                {
                    result[i] = origin[j];
                    i++;
                    j += step;
                }

                if (numRows > 2)
                {
                    for (var k = 1; k < numRows - 1; k++)
                    {
                        int firstStep = step - k * 2, secondStep = k * 2;
                        j = k;
                            
                        while (j < origin.Length)
                        {
                            result[i] = origin[j];
                            i++;
                            j += firstStep;

                            if (j >= origin.Length) break;

                            result[i] = origin[j];
                            i++;
                            j += secondStep;
                        }
                    }
                }

                j = numRows - 1;
                
                while (j < origin.Length)
                {
                    result[i] = origin[j];
                    i++;
                    j += step;
                }
            });
            
            return result;
        }
    }
}