namespace KnightTravails;
class Program
{
    public static void Main(string[] args)
    {
        var board = new Board();
        board.PlaceFigure(FigureEnum.Knight, (4, 4));
        board.MoveFigure((4, 4), (0, 1));
        board.DrawBoard();
    }
}