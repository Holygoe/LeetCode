using System;

namespace GuessTheWord
{
    public static class WordUtility
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly int AlphabetLength = Alphabet.Length;
        private static readonly Random Random = new Random();

        public static string GetRandom(int length)
        {
            var word = string.Create(length, Alphabet, (span, _) =>
            {
                for (var i = 0; i < length; i++)
                {
                    var symbol = Alphabet[Random.Next(AlphabetLength)];
                    span[i] = symbol;
                }
            });

            return word;
        }

        public static int GetMatchCount(string left, string right)
        {
            if (left.Length != right.Length)
            {
                throw new ArgumentException();
            }
            
            var result = 0;
            
            for (var i = 0; i < left.Length; i++)
            {
                if (left[i] == right[i])
                {
                    result++;
                }
            }

            return result;
        }
    }
}