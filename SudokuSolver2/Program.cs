var board = new[]
// {
//     new[] { '.', '.', '9', '7', '4', '8', '.', '.', '.' },
//     new [] { '7', '.', '.', '.', '.', '.', '.', '.', '.' },
//     new [] { '.', '2', '.', '1', '.', '9', '.', '.', '.' }, 
//     new [] { '.', '.', '7', '.', '.', '.', '2', '4', '.' },
//     new [] { '.', '6', '4', '.', '1', '.', '5', '9', '.' }, 
//     new [] { '.', '9', '8', '.', '.', '.', '3', '.', '.' },
//     new [] { '.', '.', '.', '8', '.', '3', '.', '2', '.' },
//     new [] { '.', '.', '.', '.', '.', '.', '.', '.', '6' },
//     new [] { '.', '.', '.', '2', '7', '5', '9', '.', '.' }
// };

{
    new []{ '5', '3', '4', '.', '7', '.', '.', '.', '.' }, new []{ '6', '.', '.', '1', '9', '5', '.', '.', '.' },
    new []{ '.', '9', '8', '.', '.', '.', '.', '6', '.' }, new []{ '8', '.', '.', '.', '6', '.', '.', '.', '3' },
    new []{ '4', '.', '.', '8', '.', '3', '.', '.', '1' }, new []{ '7', '.', '.', '.', '2', '.', '.', '.', '6' },
    new []{ '.', '6', '.', '.', '.', '.', '2', '8', '.' }, new []{ '.', '.', '.', '4', '1', '9', '.', '.', '5' },
    new []{ '.', '.', '.', '.', '8', '.', '.', '7', '9' }
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

            if (j == 2 || j == 5)
            {
                Console.Write(' ');
            }
        }
            
        Console.WriteLine();
        
        if (i == 2 || i == 5)
        {
            Console.WriteLine();
        }
    }
        
    Console.WriteLine();
}

public class Solution
{
    private const int Size = 9;
    private const int SqrSize = Size * Size;
    
    public void SolveSudoku(char[][] board)
    {
        FindDecision(board, 0);
    }

    private bool FindDecision(char[][] board, int index)
    {
        if (index == SqrSize)
        {
            return true;
        }
        
        var (r, c) = GetRowAndColumn(index);
        
        if (board[r][c] != '.')
        {
            return FindDecision(board, index + 1);
        }
        
        for (var n = '0'; n <= '9'; n++)
        {
            if (!CanBeDecision(board, r, c, n))
            {
                continue;
            }

            board[r][c] = n;

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