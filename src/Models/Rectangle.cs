namespace AyBorg.Types.Models;

/// <summary>
/// Represents a rectangle.
/// </summary>
public record struct RectangleModel
{
    /// <summary>
    /// Gets or sets the x-coordinate.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Gets or sets the y-coordinate.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    public int Height { get; set; }
}
