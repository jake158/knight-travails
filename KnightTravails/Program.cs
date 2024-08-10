namespace KnightTravails;
class Program
{
    public static void Main()
    {
        var board = new Board();
        var knightInitial = (0, 0);
        var knightNew = (0, 7);

        board.PlaceFigure(FigureEnum.Knight, knightInitial);
        board.DrawBoard();
        var path = KnightMoves(knightInitial, knightNew);

        Console.WriteLine($"\nPath from {knightInitial} to {knightNew}:");
        foreach (var step in path)
        {
            Console.Write($"{step}  ");
        }
        Console.WriteLine();
    }

    private class Node((int row, int col) pos, Node? predecessor = null)
    {
        public (int row, int col) Pos { get; init; } = pos;
        public Node? Predecessor { get; set; } = predecessor;
    }

    public static List<(int row, int col)> KnightMoves((int row, int col) from, (int row, int col) to, int boardRows = 8, int boardCols = 8)
    {
        var visited = new List<(int row, int col)>();
        var queue = new Queue<Node>();
        queue.Enqueue(new Node(pos: from));

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (visited.Contains(node.Pos))
            {
                continue;
            }
            else if (node.Pos == to)
            {
                var path = new List<(int row, int col)>();
                var curr = node;

                while (curr != null)
                {
                    path.Insert(0, curr.Pos);
                    curr = curr.Predecessor;
                }
                return path;
            }

            visited.Add(node.Pos);
            var (row, col) = node.Pos;

            (int row, int col)[] possibleMoves =
            [
                (row - 2, col - 1),
                (row - 2, col + 1),
                (row + 2, col - 1),
                (row + 2, col + 1),
                (row - 1, col - 2),
                (row + 1, col - 2),
                (row - 1, col + 2),
                (row + 1, col + 2)
            ];

            foreach (var move in possibleMoves)
            {
                if (!(move.row < 0 || move.row >= boardRows || move.col < 0 || move.col >= boardCols))
                {
                    queue.Enqueue(new Node(pos: move, predecessor: node));
                }
            }
        }
        return [];
    }
}