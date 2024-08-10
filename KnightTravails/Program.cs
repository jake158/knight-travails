using System.Collections.Generic;

namespace KnightTravails;
class Program
{
    public static void Main()
    {
        var board = new Board();
        var knightPos = (4, 4);

        board.PlaceFigure(FigureEnum.Knight, knightPos);
        board.DrawBoard();
        KnightMoves(knightPos, (5, 5));
    }

    private class Node((int row, int col) pos, Node? predecessor = null)
    {
        public (int row, int col) Pos { get; init; } = pos;
        public Node? Predecessor { get; set; } = predecessor;
    }

    public static (int row, int col)[] KnightMoves((int row, int col) from, (int row, int col) to, int boardRows = 8, int boardCols = 8)
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
            
            visited.Add(node.Pos);
            var (row, col) = node.Pos;
            // Implement
            Console.WriteLine(visited[0]);
        }
        return [(0, 0)];
    }
}