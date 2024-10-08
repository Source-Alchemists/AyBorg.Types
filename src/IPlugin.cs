namespace AyBorg.Types;

/// <summary>
/// Used to implement a plugin.
/// </summary>
public interface IPlugin {

    /// <summary>
    /// Gets the default name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the categories.
    /// </summary>
    IReadOnlyCollection<string> Categories { get; }
}
