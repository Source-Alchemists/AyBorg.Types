namespace AyBorg.Types;

/// <summary>
/// Represents a line.
/// </summary>
public readonly record struct Line
{

    /// <summary>
    /// Gets the first position.
    /// </summary>
    public Point Position1 { get; init; }

    /// <summary>
    /// Gets the second position.
    /// </summary>
    public Point Position2 { get; init; }
}
