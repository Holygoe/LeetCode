var board = new []
{
    new[] { '.', '.', '9', '7', '4', '8', '.', '.', '.' },
    new [] { '7', '.', '.', '.', '.', '.', '.', '.', '.' },
    new [] { '.', '2', '.', '1', '.', '9', '.', '.', '.' }, 
    new [] { '.', '.', '7', '.', '.', '.', '2', '4', '.' },
    new [] { '.', '6', '4', '.', '1', '.', '5', '9', '.' }, 
    new [] { '.', '9', '8', '.', '.', '.', '3', '.', '.' },
    new [] { '.', '.', '.', '8', '.', '3', '.', '2', '.' },
    new [] { '.', '.', '.', '.', '.', '.', '.', '.', '6' },
    new [] { '.', '.', '.', '2', '7', '5', '9', '.', '.' }
};

var solution = new Solution();
solution.SolveSudoku(board);
PrintBoard(board);

static void PrintBoard(char[][] board)
{
    for (var i = 0; i < board.Length; i++)
    {
        for (var j = 0; j < board[i].Length; j++)
        {
            Console.Write(board[i][j]);
            Console.Write(' ');
        }
            
        Console.WriteLine();
    }
        
    Console.WriteLine();
}

public class Solution
{
    private const int Size = 9;
    private const int SqrSize = Size * Size;
    private readonly List<char>?[][] _variants;

    public Solution()
    {
        _variants = new List<char>[Size][];
        
        for (var i = 0; i < _variants.Length; i++)
        {
            _variants[i] = new List<char>[Size];
        }
    }

    public void SolveSudoku(char[][] board)
    {
        var hadAnyDecision = true;

        while (hadAnyDecision)
        {
            hadAnyDecision = false;
            
            for (var i = 0; i < SqrSize; i++)
            {
                var (r, c) = GetRowAndColumn(i);
                
                if (board[r][c] != '.')
                {
                    continue;
                }
                    
                var variants = GetVariants(board, _variants[r][c], r, c);

                if (variants.Count == 1)
                {
                    hadAnyDecision = true;
                    board[r][c] = variants.First();
                    _variants[r][c] = null;
                }
                else
                {
                    _variants[r][c] = variants;
                }
            }
        }
        
        FindDecision(board, 0);
    }

    private bool FindDecision(char[][] board, int index)
    {
        if (index == SqrSize)
        {
            return true;
        }
        
        var (r, c) = GetRowAndColumn(index);
        var variants = _variants[r][c];

        if (variants is null)
        {
            return FindDecision(board, index + 1);
        }
        
        foreach (var variant in variants)
        {
            if (!CanBeDecision(board, r, c, variant))
            {
                continue;
            }

            board[r][c] = variant;

            if (FindDecision(board, index + 1))
            {
                return true;
            }
        }

        board[r][c] = '.';
        return false;
    }

    private bool CanBeDecision(char[][] board, int r, int c, char n)
    {
        var s = r / 3 * 3 + c / 3;
        return CheckRow(board, r, n) && CheckColumn(board, c, n) && CheckSquare(board, s, n);
    }

    private (int r, int c) GetRowAndColumn(int index)
    {
        var r = index / Size;
        var c = index % Size;
        return (r, c);
    }

    private List<char> GetVariants(char[][] board, List<char>? variants, int r, int c)
    {
        variants ??= Enumerable.Range('1', Size).Select(n => (char)n).ToList();

        for (var i = 0; i < 9; i++)
        {
            if (TryGetFromRow(board, r, i, out var n))
            {
                variants.Remove(n);
            }
            
            if (TryGetFromColumn(board, c, i, out n))
            {
                variants.Remove(n);
            }
            
            if (TryGetFromSquare(board, r, c, i, out n))
            {
                variants.Remove(n);
            }
        }

        return variants;
    }

    private static bool TryGetFromRow(char[][] board, int r, int i, out char n)
    {
        n = board[r][i];
        return n != '.';
    }
    
    private static bool TryGetFromColumn(char[][] board, int c, int i, out char n)
    {
        n = board[i][c];
        return n != '.';
    }
    
    private static bool TryGetFromSquare(char[][] board, int r, int c, int i, out char n)
    {
        n = board[r / 3 * 3 + i / 3][c / 3 * 3 + i % 3];
        return n != '.';
    }
    
    private bool CheckRow(char[][] board, int r, char n)
    {
        for (var i = 0; i < Size; i++)
        {
            if (board[r][i] == n)
            {
                return false;
            }
        }

        return true;
    }
    
    private bool CheckColumn(char[][] board, int c, char n)
    {
        for (var i = 0; i < Size; i++)
        {
            if (board[i][c] == n)
            {
                return false;
            }
        }

        return true;
    }
    
    private bool CheckSquare(char[][] board, int s, char n)
    {
        var sunR = s / 3 * 3;
        var subC = s % 3 * 3;

        for (var i = 0; i < Size; i++)
        {
            var r = sunR + i / 3;
            var c = subC + i % 3;

            if (board[r][c] == n)
            {
                return false;
            }
        }

        return true;
    }
}