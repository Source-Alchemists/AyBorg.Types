namespace AyBorg.Types.Communication;

/// <summary>
/// Message event arguments.
/// </summary>
public sealed class MessageEventArgs : EventArgs
{
    /// <summary>
    /// Gets the message.
    /// </summary>
    public IMessage Message { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MessageEventArgs"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public MessageEventArgs(IMessage message) : base()
    {
        Message = message;
    }
}
