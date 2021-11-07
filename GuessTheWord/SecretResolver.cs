using System;

namespace GuessTheWord
{
    /// <summary>
    /// Finds the secret word.
    /// </summary>
    public class SecretResolver
    {
        private readonly WordList _wordList;
        private readonly Master _master;

        public string Result { get; private set; } = "not found";
        
        public bool HasResult { get; private set; }

        public SecretResolver(WordList wordList, Master master)
        {
            _wordList = wordList;
            _master = master;
        }

        public void MakeAttempt()
        {
            var attemptWord = _wordList.GetMostCommonWord();
            var attemptCitation = _master.GuessWord(attemptWord);
            
            if (attemptCitation == _wordList.WordLength)
            {
                Result = attemptWord;
                HasResult = true;
                
                return;
            }
            
            _wordList.FilterOut(attemptWord, attemptCitation);

            if (_wordList.Count == 0)
            {
                throw new Exception("The word list is empty");
            }
            
            Console.WriteLine($"Attempt: {attemptWord} | {attemptCitation} | list filtered to {_wordList.Count}");
        }
    }
}