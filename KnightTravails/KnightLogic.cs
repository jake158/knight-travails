namespace KnightTravails;
public static class KnightLogic
{
    private class Node(Pos pos, Node? predecessor = null)
    {
        public Pos Pos { get; init; } = pos;
        public Node? Predecessor { get; set; } = predecessor;
    }

    public static List<Pos> KnightMoves(Pos from, Pos to, int boardRows = 8, int boardCols = 8)
    {
        var visited = new List<Pos>();
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
                var path = new List<Pos>();
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
                    queue.Enqueue(new Node(pos: new Pos(move.row, move.col), predecessor: node));
                }
            }
        }
        return [];
    }
}
