using AyBorg.Types.Ports;

namespace AyBorg.Types.Result;

/// <summary>
/// Represents a port result.
/// </summary>
public record PortResult
{
    /// <summary>
    /// Gets the id.
    /// </summary>
    public string Id { get; } = string.Empty;

    /// <summary>
    /// Gets the port.
    /// </summary>
    public Port Port { get; } = new Port();

    /// <summary>
    /// Gets the scale factor.
    /// </summary>
    public float ScaleFactor { get; init; } = 1f;

    /// <summary>
    /// Initializes a new instance of the <see cref="PortResult"/> class.
    /// </summary>
    /// <param name="id">The id.</param>
    /// <param name="port">The port.</param>
    public PortResult(string id, Port port)
    {
        Id = id;
        Port = port;
    }
}
