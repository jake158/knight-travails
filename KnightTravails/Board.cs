namespace KnightTravails;
public class Board(int rows = 8, int columns = 8)
{
    private FigureEnum[,] _board = new FigureEnum[rows, columns];

    public void PlaceFigure(FigureEnum? figure, (int row, int column) pos)
    {
        ValidatePosition(pos);
        _board[pos.row, pos.column] = figure ?? FigureEnum.EmptySpace;
    }

    public void MoveFigure((int row, int column) prevPos, (int row, int column) newPos)
    {
        ValidatePosition(prevPos);
        ValidatePosition(newPos);

        var figure = _board[prevPos.row, prevPos.column];
        if (figure is FigureEnum.EmptySpace)
        {
            throw new InvalidOperationException($"Cannot move empty space at pos ({prevPos.row}, {prevPos.column})");
        }
        _board[newPos.row, newPos.column] = figure;
        _board[prevPos.row, prevPos.column] = FigureEnum.EmptySpace;
    }

    private void ValidatePosition((int row, int column) pos)
    {
        if (pos.row < 0 || pos.row >= rows || pos.column < 0 || pos.column >= columns)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), $"Position ({pos.row}, {pos.column}) is out of bounds.");
        }
    }

    public void ClearBoard()
    {
        _board = new FigureEnum[rows, columns];
    }

    public void DrawBoard()
    {
        // Print column numbers
        Console.Write("  ");
        for (int c = 0; c < _board.GetLength(1); c++)
        {
            Console.Write($" {c} ");
        }
        Console.WriteLine();

        // Print squares
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            Console.Write(i + " ");

            for (int j = 0; j < _board.GetLength(1); j++)
            {
                switch (_board[i, j])
                {
                    case FigureEnum.EmptySpace:
                        Console.Write("[ ]");
                        break;
                    case FigureEnum.Knight:
                        Console.Write("[♞]");
                        break;
                    default:
                        Console.Write("[?]");
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}