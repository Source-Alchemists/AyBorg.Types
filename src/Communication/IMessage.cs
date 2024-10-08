namespace AyBorg.Types.Communication;

/// <summary>
/// Represents a message.
/// </summary>
public interface IMessage {

    /// <summary>
    /// Gets the content type.
    /// </summary>
    string ContentType { get; init; }

    /// <summary>
    /// Gets the payload.
    /// </summary>
    ArraySegment<byte> Payload { get; init; }
}
