namespace SmallestStringWithAGivenNumericValue;

public class Solution
{
    public string GetSmallestString(int n, int k)
    {
        const int maxNum = 'z' - 'a' + 1;
        var nums = new int[n];

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var rest = k - i;
            nums[i] = rest > maxNum ? maxNum : rest;
            k -= nums[i];
        }
        
        var result = string.Create(n, nums, (str, array) =>
        {
            for (var i = 0; i < array.Length; i++)
            {
                str[i] = (char)('a' + array[i] - 1);
            }
        });

        return result;
    }
}