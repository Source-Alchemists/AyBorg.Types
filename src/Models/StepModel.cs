namespace AyBorg.Types.Models;

/// <summary>
/// Represents a step.
/// </summary>
public sealed record StepModel
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public Guid Id { get; init; } = Guid.Empty;

    /// <summary>
    /// Gets or sets the default name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the categories.
    /// </summary>
    public IEnumerable<string> Categories { get; init; } = new List<string>();

    /// <summary>
    /// Gets or sets the x position.
    /// </summary>
    public int X { get; set; } = 0;

    /// <summary>
    /// Gets or sets the y position.
    /// </summary>
    public int Y { get; set; } = 0;

    /// <summary>
    /// Gets or sets the meta information.
    /// </summary>
    public PluginMetaInfo MetaInfo { get; init; } = new PluginMetaInfo();

    /// <summary>
    /// Gets or sets the ports.
    /// </summary>
    public IEnumerable<PortModel>? Ports { get; set; } = new List<PortModel>();

    /// <summary>
    /// Gets or sets the execution time in milliseconds.
    /// </summary>
    public long ExecutionTimeMs { get; set; }
}
