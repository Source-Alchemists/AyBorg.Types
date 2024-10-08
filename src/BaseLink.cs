namespace AyBorg.Types;

/// <summary>
/// Represents a base link.
/// </summary>
public abstract record BaseLink
{
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Gets the source identifier.
    /// </summary>
    public Guid SourceId { get; protected set; }

    /// <summary>
    /// Gets the target identifier.
    /// </summary>
    public Guid TargetId { get; protected set; }
}
