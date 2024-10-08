namespace AyBorg.Types.ImageAcquisition;

/// <summary>
/// Represents a camera device.
/// </summary>
public interface ICameraDevice : IDevice
{
    /// <summary>
    /// Acquisition.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The image container.</returns>
    ValueTask<ImageContainer> AcquisitionAsync(CancellationToken cancellationToken);
}
