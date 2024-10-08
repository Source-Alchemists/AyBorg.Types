using AyBorg.Types.Ports;

namespace AyBorg.Types;

/// <summary>
/// Represents a port provider plugin.
/// </summary>
public interface IPortProviderPlugin : IPlugin {
    /// <summary>
    /// Gets the ports.
    /// </summary>
    IReadOnlyCollection<IPort> Ports { get; }
}
