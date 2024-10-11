namespace AyBorg.Types;

/// <summary>
/// Represents a point in a two-dimensional plane.
/// </summary>
public readonly record struct Point
{

    /// <summary>
    /// Gets the x-coordinate of this <see cref="Point"/>.
    /// </summary>
    public int X { get; init; }

    /// <summary>
    /// Gets the y-coordinate of this <see cref="Point"/>.
    /// </summary>
    public int Y { get; init; }
}
