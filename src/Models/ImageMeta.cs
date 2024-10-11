using ImageTorque;

namespace AyBorg.Types.Models;

/// <summary>
/// Represents image meta informations.
/// </summary>
public readonly record struct ImageMeta
{

    /// <summary>
    /// Gets the width of the image.
    /// </summary>
    public int Width { get; init; }

    /// <summary>
    /// Gets the height of the image.
    /// </summary>
    public int Height { get; init; }

    /// <summary>
    /// Gets the pixel format of the image.
    /// </summary>
    public PixelFormat PixelFormat { get; init; }
}
