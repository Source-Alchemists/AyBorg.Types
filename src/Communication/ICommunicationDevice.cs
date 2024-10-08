using AyBorg.Types.Ports;

namespace AyBorg.Types.Communication;

/// <summary>
/// Represents a communication device.
/// </summary>
public interface ICommunicationDevice : IDevice
{
    /// <summary>
    /// Try to send a port.
    /// </summary>
    /// <param name="messageId">The message identifier.</param>
    /// <param name="port">The port.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a value indicating whether the port was sent.</returns>
    ValueTask<bool> TrySendAsync(string messageId, IPort port);

    /// <summary>
    /// Subscribe to a message.
    /// </summary>
    /// <param name="messageId">The message identifier.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the message subscription.</returns>
    ValueTask<IMessageSubscription> SubscribeAsync(string messageId);

    /// <summary>
    /// Unsubscribe from a message.
    /// </summary>
    /// <param name="subscription">The message subscription.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask UnsubscribeAsync(IMessageSubscription subscription);
}
