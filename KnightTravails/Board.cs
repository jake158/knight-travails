namespace KnightTravails;
public class Board(int rows = 8, int columns = 8)
{
    private FigureEnum[,] _board = new FigureEnum[rows, columns];

    public void PlaceFigure(FigureEnum? figure, Pos pos)
    {
        ValidatePosition(pos);
        _board[pos.Row, pos.Column] = figure ?? FigureEnum.EmptySpace;
    }

    public void MoveFigure(Pos prevPos, Pos newPos)
    {
        ValidatePosition(prevPos);
        ValidatePosition(newPos);

        var figure = _board[prevPos.Row, prevPos.Column];
        if (figure is FigureEnum.EmptySpace)
        {
            throw new InvalidOperationException($"Cannot move empty space at pos ({prevPos.Row}, {prevPos.Column})");
        }
        _board[newPos.Row, newPos.Column] = figure;
        _board[prevPos.Row, prevPos.Column] = FigureEnum.EmptySpace;
    }

    private void ValidatePosition(Pos pos)
    {
        if (pos.Row < 0 || pos.Row >= rows || pos.Column < 0 || pos.Column >= columns)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), $"Position ({pos.Row}, {pos.Column}) is out of bounds.");
        }
    }

    public void ClearBoard()
    {
        _board = new FigureEnum[rows, columns];
    }

    public void DrawBoard()
    {
        // Print column numbers
        Console.Write("   ");
        for (int c = 0; c < _board.GetLength(1); c++)
        {
            Console.Write($" {c} ");
        }
        Console.WriteLine();

        ConsoleColor currentBg = Console.BackgroundColor;
        ConsoleColor currentFg = Console.ForegroundColor;

        // Print squares
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            Console.Write($"r{i} ");

            for (int j = 0; j < _board.GetLength(1); j++)
            {
                Console.BackgroundColor = (i + j) % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.Black;
                Console.ForegroundColor = (i + j) % 2 == 0 ? ConsoleColor.Red : ConsoleColor.White;
                switch (_board[i, j])
                {
                    case FigureEnum.EmptySpace:
                        Console.Write("   ");
                        break;
                    case FigureEnum.Knight:
                        Console.Write(" ♞ ");
                        break;
                    default:
                        Console.Write(" ? ");
                        break;
                }
            }
            Console.BackgroundColor = currentBg;
            Console.ForegroundColor = currentFg;
            Console.WriteLine();
        }
    }
}