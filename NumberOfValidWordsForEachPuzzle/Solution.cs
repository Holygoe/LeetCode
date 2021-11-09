using System.Collections.Generic;

namespace NumberOfValidWordsForEachPuzzle
{
    /// <summary>
    /// The problem https://leetcode.com/problems/number-of-valid-words-for-each-puzzle/
    /// </summary>
    public class Solution
    {
        private const int ACode = 'a';

        public IList<int> FindNumOfValidWords(string[] words, string[] puzzles)
        {
            var wordCount = words.Length;
            var puzzleCount = puzzles.Length;
            
            var puzzleMaps = new int[puzzleCount];
            var firstLetterBits = new int[puzzleCount];
            var result = new int[puzzleCount];
            
            for (var i = 0; i < puzzleCount; i++)
            {
                firstLetterBits[i] = 1 << (puzzles[i][0] - ACode);
                puzzleMaps[i] = ~GetBitmap(puzzles[i]);
            }

            for (var i = 0; i < wordCount; i++)
            {
                var wordMap = GetBitmap(words[i]);

                for (var j = 0; j < puzzleCount; j++)
                {
                    if ((wordMap & firstLetterBits[j]) == 0
                        || (wordMap & puzzleMaps[j]) != 0)
                    {
                        continue;
                    }

                    result[j]++;
                }
            }

            return result;
        }

        private static int GetBitmap(string source)
        {
            var bitmap = 0;
            var sourceLength = source.Length;
            
            for (var i = 0; i < sourceLength; i++)
            {
                bitmap |= 1 << (source[i] - ACode);
            }
            
            return bitmap;
        }
    }
}