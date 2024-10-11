namespace AyBorg.Types.Models;

/// <summary>
/// Represents an cached image.
/// </summary>
public sealed record CacheImage : IDisposable
{
    private bool _disposedValue;

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    public ImageTorque.IImage? OriginalImage { get; init; }

    /// <summary>
    /// Gets or sets the meta information.
    /// </summary>
    public ImageMeta Meta { get; init; }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                OriginalImage?.Dispose();
            }
            _disposedValue = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
