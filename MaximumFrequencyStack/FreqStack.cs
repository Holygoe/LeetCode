namespace MaximumFrequencyStack;

public class FreqStack
{
    private readonly Dictionary<int, int> _map;
    private readonly Dictionary<int, Stack<int>> _frequency;
    private int _maxFrequency;

    public FreqStack()
    {
        _map = new();
        _frequency = new();
    }
    
    public void Push(int value)
    {
        if (_map.TryGetValue(value, out var valueFrequency))
        {
            valueFrequency++;
            _map[value] = valueFrequency;
        }
        else
        {
            valueFrequency = 1;
            _map.Add(value, valueFrequency);
        }

        if (!_frequency.TryGetValue(valueFrequency, out var frequencyStack))
        {
            frequencyStack = new();
            _frequency.Add(valueFrequency, frequencyStack);
        }
        
        frequencyStack.Push(value);

        if (valueFrequency > _maxFrequency)
        {
            _maxFrequency = valueFrequency;
        }
    }

    public int Pop()
    {
        var resultStack = _frequency[_maxFrequency];
        var result = resultStack.Pop();
        _map[result]--;
        
        if (resultStack.Count == 0)
        {
            _maxFrequency--;
        }

        return result;
    }
}