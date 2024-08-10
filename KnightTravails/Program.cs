using static KnightTravails.KnightLogic;

namespace KnightTravails;
class Program
{
    public static void Main()
    {
        var board = new Board();

        var knightInitial = GetPositionFromUser("initial");
        Console.WriteLine();
        var knightNew = GetPositionFromUser("new");

        board.PlaceFigure(FigureEnum.Knight, knightInitial);

        Console.WriteLine("================================");
        Console.WriteLine($"\nPath from {knightInitial} to {knightNew}:\n");
        board.DrawBoard();
        Console.WriteLine();

        var path = KnightMoves(knightInitial, knightNew);

        var knightCurrent = knightInitial;
        foreach (var step in path[1..])
        {
            Console.WriteLine($"\nMoving {knightCurrent} to {step}:\n");
            board.MoveFigure(knightCurrent, step);
            knightCurrent = step;
            board.DrawBoard();
            Console.WriteLine();
        }

        Console.WriteLine($"Knight has reached the position in {path.Count - 1} steps! Trace:");
        foreach (var step in path[..^1])
        {
            Console.Write($"{step} -> ");
        }
        Console.Write($"{path[^1]}\n");
    }

    private static (int row, int col) GetPositionFromUser(string positionName, int boardRows = 8, int boardCols = 8)
    {
        Console.WriteLine($"Enter the {positionName} position of the knight (row and column):");

        int row, col;
        while (true)
        {
            Console.Write($"Row (0 to {boardRows - 1}): ");
            if (!int.TryParse(Console.ReadLine(), out row) || row < 0 || row >= boardRows)
            {
                Console.WriteLine($"\nInvalid input. Please enter a number between 0 and {boardRows - 1}.");
                continue;
            }

            Console.Write($"Column (0 to {boardCols - 1}): ");
            if (!int.TryParse(Console.ReadLine(), out col) || col < 0 || col >= boardCols)
            {
                Console.WriteLine($"\nInvalid input. Please enter a number between 0 and {boardCols - 1}.");
                continue;
            }
            break;
        }
        return (row, col);
    }
}