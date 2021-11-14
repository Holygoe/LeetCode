using System;

namespace IteratorForCombination
{
    public static class Program
    {
        private static void Main()
        {
            var itr = new CombinationIterator("abc", 2);

            while (itr.HasNext())
            {
                Console.Write($"{itr.Next()} ");
            }
        }
    }
}