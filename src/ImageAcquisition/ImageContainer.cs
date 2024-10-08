using ImageTorque;

namespace AyBorg.Types;

/// <summary>
/// Represents an image container.
/// </summary>
public sealed class ImageContainer : IDisposable
{
    private bool _isDisposed;

    /// <summary>
    /// Gets the image.
    /// </summary>
    public Image Image { get; }

    /// <summary>
    /// Gets the index.
    /// </summary>
    public long Index { get; }

    /// <summary>
    /// Gets the additional information.
    /// </summary>
    public string AdditionInfo { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageContainer"/> class.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="index">The index.</param>
    /// <param name="additionalInfo">The additional information.</param>
    public ImageContainer(Image image, long index, string additionalInfo)
    {
        Image = image;
        Index = index;
        AdditionInfo = additionalInfo;
    }

    private void Dispose(bool disposing)
    {
        if (!_isDisposed && disposing)
        {
            Image?.Dispose();
            _isDisposed = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
