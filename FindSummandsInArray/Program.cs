// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

int[] a = { -4, -1, 5, 8 };
int[] b = { -3, -1, 0, 2, 6 };
int[] c = { 2, 4, 8 };
int[] d = { -2, -1, 1, 2 };

FindAddends(a, 7);
FindAddends(b, 6);
FindAddends(c, 8);
FindAddends(d, 0);

static void FindAddends(int[] nums, int sum)
{
    Console.Write($"For '{nums.ToString()}' array and '{sum}' sum ");

    for (var i = 0; i < nums.Length - 1; i++)
    {
        if (nums[i] > sum)
        {
            ShowNoResult();
            return;
        }

        if (nums[i] + nums[^1] < sum)
        {
            continue;
        }

        var minJ = i + 1;
        var maxJ = nums.Length - 1;

        while (maxJ >= minJ)
        {
            var j = (maxJ + minJ) / 2;
            var temp = nums[i] + nums[j];

            if (temp == sum)
            {
                Console.WriteLine($"the result is {nums[i]} and {nums[j]}.");
                return;
            }

            if (temp > sum)
            {
                maxJ = j - 1;
            }
            else
            {
                minJ = j + 1;
            }
        }
    }
    
    ShowNoResult();
}

static void ShowNoResult()
{
    Console.WriteLine("there is no result.");
}