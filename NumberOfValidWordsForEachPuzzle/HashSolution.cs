using System.Collections.Generic;

namespace NumberOfValidWordsForEachPuzzle
{
    public class HashSolution
    {
        private const int ACode = 'a';

        public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
        {
            var result = new int[puzzles.Length];
            var wordHashMap = new Dictionary<int, int>();
            
            foreach (var word in words)
            {
                var wordBitmap = GetBitmap(word);

                if (!wordHashMap.TryAdd(wordBitmap, 1))
                {
                    wordHashMap[wordBitmap]++;
                }
            }
            
            for (var i = 0; i < puzzles.Length; i++)
            {
                var puzzle = puzzles[i];
                var firstLetter = 1 << (puzzle[0] - ACode);
                
                if (!wordHashMap.TryGetValue(firstLetter, out var count))
                {
                    count = 0;
                }
                
                var mask = GetBitmap(puzzle, 1);
                
                for (var subMask = mask; subMask > 0; subMask = (subMask - 1) & mask) 
                {
                    if (wordHashMap.TryGetValue(subMask | firstLetter, out var value))
                    {
                        count += value;
                    }
                }

                result[i] = count;
            }
            
            return result;
        }

        private static int GetBitmap(string source, int startLetter = 0)
        {
            var bitmap = 0;
            var sourceLength = source.Length;
            
            for (var i = startLetter; i < sourceLength; i++)
            {
                bitmap |= 1 << (source[i] - ACode);
            }
            
            return bitmap;
        }
    }
}