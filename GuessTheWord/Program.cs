using System;

namespace GuessTheWord
{
    internal static class Program
    {
        private static void Main()
        {
            const int maxRunCount = 1000;
            var totalAttemptCount = 0;
            int runCount;
            
            for (runCount = 0; runCount < maxRunCount; runCount++)
            {
                var hasResult = GuessTheWord(out var attemptCount);

                totalAttemptCount += attemptCount;

                if (hasResult) continue;
                
                runCount++;
                    
                break;
            }
            
            Console.WriteLine($"The average attempt count: {(float)totalAttemptCount / runCount} in {runCount} run(s)");
        }

        private static bool GuessTheWord(out int attemptCount)
        {
            const int wordLength = 6;
            const int listSize = 100;
            
            var wordList = new WordList(listSize, wordLength);
            var master = new Master(wordList);
            
            master.PrintSecret();

            const int maxAttemptCount = 10;
            
            attemptCount = 0;
            var secretResolver = new SecretResolver(wordList, master);

            while(attemptCount < maxAttemptCount && !secretResolver.HasResult)
            {
                attemptCount++;

                secretResolver.MakeAttempt();
            }

            if (secretResolver.HasResult)
            {
                Console.WriteLine($"Result: {secretResolver.Result} within {attemptCount} attempt(s)\n");
            }
            else
            {
                Console.WriteLine($"Result {secretResolver.Result}\n");
            }

            return secretResolver.HasResult;
        }
    }
}