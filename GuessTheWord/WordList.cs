using System;
using System.Collections.Generic;

namespace GuessTheWord
{
    public class WordList
    {
        private readonly List<string> _list;

        private static readonly Random Random = new Random();

        public readonly int WordLength;

        public int Count => _list.Count;
        
        public WordList(int size, int wordLength)
        {
            WordLength = wordLength;
            _list = new List<string>(size);

            for (var i = 0; i < size; i++)
            {
                _list.Add(WordUtility.GetRandom(wordLength));
            }
        }

        public string GetRandomWord()
        {
            var index = Random.Next(_list.Count);

            return _list[index];
        }

        public void FilterOut(string sample, int matchCount)
        {
            if (sample.Length != WordLength) throw new ArgumentException();

            _list.Remove(sample);
            
            for (var i = _list.Count - 1; i >= 0; i--)
            {
                if (WordUtility.GetMatchCount(_list[i], sample) != matchCount)
                {
                    _list.RemoveAt(i);
                }
            }
        }

        public string GetMostCommonWord()
        {
            (int index, int similarity) result = (0, 0);

            for (var i = 0; i < _list.Count; i++)
            {
                var similarity = GetWordSimilarity(i);

                if (similarity > result.similarity)
                {
                    result = (i, similarity);
                }
            }

            return _list[result.index];
        }
        
        private int GetWordSimilarity(int wordIndex)
        {
            var word = _list[wordIndex];
            var similarity = 0;
            
            for (var i = 0; i < _list.Count; i++)
            {
                if (i == wordIndex) continue;

                similarity += WordUtility.GetMatchCount(word, _list[i]);
            }

            return similarity;
        }
    }
}