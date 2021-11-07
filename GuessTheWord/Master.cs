using System;

namespace GuessTheWord
{
    /// <summary>
    /// Selects a secret word from the list.
    /// </summary>
    public class Master
    {
        private readonly string _secret;
        
        public Master(WordList wordList)
        {
            _secret = wordList.GetRandomWord();
        }

        public void PrintSecret()
        {
            Console.WriteLine($"Secret: {_secret}");
        }

        public int GuessWord(string guess)
        {
            if (guess.Length != _secret.Length) throw new ArgumentException();

            var matchCount = 0;

            for (var i = 0; i < guess.Length; i++)
            {
                if (guess[i] == _secret[i])
                {
                    matchCount++;
                }
            }
            
            return matchCount;
        }
    }
}