namespace KnightTravails;
public readonly struct Pos(int row, int column) : IEquatable<Pos>
{
    public int Row { get; init; } = row;
    public int Column { get; init; } = column;

    public override bool Equals(object? obj)
    {
        if (obj is Pos other)
        {
            return Equals(other);
        }
        return false;
    }

    public bool Equals(Pos other)
    {
        return Row == other.Row && Column == other.Column;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }

    public static bool operator ==(Pos left, Pos right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Pos left, Pos right)
    {
        return !(left == right);
    }

    public void Deconstruct(out int row, out int column)
    {
        row = Row;
        column = Column;
    }
}