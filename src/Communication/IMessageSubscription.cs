namespace AyBorg.Types.Communication;

/// <summary>
/// Message subscription.
/// </summary>
public interface IMessageSubscription {

    /// <summary>
    /// Gets the id.
    /// </summary>
    string Id { get; init; }

    /// <summary>
    /// Event raised when a message is received.
    /// </summary>
    event EventHandler<MessageEventArgs> Received;
}
