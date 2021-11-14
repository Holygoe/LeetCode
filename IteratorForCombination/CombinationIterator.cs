namespace IteratorForCombination
{
    public class CombinationIterator
    {
        private readonly string _characters;
        private readonly int[] _symbols;

        public CombinationIterator(string characters, int combinationLength) 
        {
            _characters = characters;
            _symbols = new int[combinationLength];

            for (var i = 0; i < combinationLength; i++)
            {
                _symbols[i] = i;
            }
        }
    
        public string Next() 
        {
            var result = string.Create(_symbols.Length, _characters, (span, original) => 
            {
                for (var i = 0; i < _symbols.Length; i++) 
                {
                    span[i] = original[_symbols[i]];
                }
            });

            MoveNext(_symbols.Length - 1, _characters.Length - 1);
        
            return result;
        }

        public bool HasNext() => _symbols[^1] < _characters.Length;

        private int MoveNext(int i, int maxValue)
        {
            if (i == 0 || _symbols[i] < maxValue)
            {
                _symbols[i]++;
            }
            else
            {
                _symbols[i] = MoveNext(i - 1, _symbols[i] - 1) + 1;
            }
            
            return _symbols[i];
        }
    }
}