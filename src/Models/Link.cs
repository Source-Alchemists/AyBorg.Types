namespace AyBorg.Types.Models;

/// <summary>
/// Represents a link.
/// </summary>
public record struct LinkModel
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the source identifier.
    /// </summary>
    public Guid SourceId { get; set; }

    /// <summary>
    /// Gets or sets the target identifier.
    /// </summary>
    public Guid TargetId { get; set; }
}
