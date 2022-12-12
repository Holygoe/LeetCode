var nums = new [] { 2, 1, 3 };
var solution = new Solution();
var result = solution.FirstMissingPositive(nums);
Console.WriteLine(result);

public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        var result = 1;
        var set = new HashSet<int>();
        
        foreach (var num in nums)
        {
            if (num < result)
            {
                continue;
            }

            if (num == result)
            {
                result = FindNextNumber(set, result + 1);
            }
            else
            {
                set.Add(num);
            }
        }

        return result;
    }

    private int FindNextNumber(HashSet<int> set, int result)
    {
        return set.Remove(result) ? FindNextNumber(set, result + 1) : result;
    }
}