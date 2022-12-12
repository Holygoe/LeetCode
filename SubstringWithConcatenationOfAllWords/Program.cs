var solution = new Solution();
var s = "wordgoodgoodgoodbestword";
var words = new[] { "word","good","best","good" };
var result = solution.FindSubstring(s, words);

public class Solution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        var result = new List<int>();
        var wordCount = words.Length;

        if (wordCount == 0)
        {
            return result;
        }
        
        var wordLength = words[0].Length;
        var phraseLength = wordLength * wordCount;
        var trackedLength = s.Length - phraseLength;
        var originalWords = new Dictionary<string, int>();
        
        foreach (var word in words)
        {
            if (originalWords.TryGetValue(word, out var value))
            {
                originalWords[word] = value + 1;
            }
            else
            {
                originalWords[word] = 1;
            }
        }

        for (var i = 0; i <= trackedLength; i++)
        {
            var wordMap = new Dictionary<string, int>(originalWords);
            
            for (var j = i; j < i + phraseLength; j += wordLength)
            {
                var word = s.Substring(j, wordLength);
                
                if (!wordMap.TryGetValue(word, out var value))
                {
                    break;
                }

                if (value > 1)
                {
                    wordMap[word] = value - 1;
                }
                else
                {
                    wordMap.Remove(word);
                }
            }
            
            if (wordMap.Count == 0)
            {
                result.Add(i);
            }
        }

        return result;
    }
}