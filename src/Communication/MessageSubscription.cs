namespace AyBorg.Types.Communication;

/// <summary>
/// Represents a message subscription.
/// </summary>
public record MessageSubscription : IMessageSubscription {

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public string Id { get; init; } = string.Empty;

    /// <summary>
    /// Event raised when a message is received.
    /// </summary>
    public event EventHandler<MessageEventArgs>? Received;

    /// <summary>
    /// Next message.
    /// </summary>
    public void Next(IMessage message)
    {
        Received?.Invoke(this, new MessageEventArgs(message));
    }
}
