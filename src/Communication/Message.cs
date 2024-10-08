namespace AyBorg.Types.Communication;

/// <summary>
/// Represents a message.
/// </summary>
public record Message : IMessage
{
    /// <summary>
    /// Gets or sets the content type.
    /// </summary>
    public string ContentType { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the payload.
    /// </summary>
    public ArraySegment<byte> Payload { get; init; } = ArraySegment<byte>.Empty;
}
