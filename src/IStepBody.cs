namespace AyBorg.Types;

/// <summary>
/// Used to implement a step plugin.
/// </summary>
public interface IStepBody : IPortProviderPlugin
{
    /// <summary>
    /// Tries to run asynchronous.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>True if successful.</returns>
    ValueTask<bool> TryRunAsync(CancellationToken cancellationToken);
}
