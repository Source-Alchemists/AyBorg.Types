namespace AyBorg.Types.Ports;

/// <summary>
/// Represents an enum port.
/// </summary>
public sealed class EnumPort : ValuePortGeneric<EnumPort, Enum>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumPort"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="direction">The port direction.</param>
    /// <param name="value">The value.</param>
    public EnumPort(string name, PortDirection direction, Enum value) : base(name, direction, value)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EnumPort"/> class.
    /// </summary>
    public EnumPort(EnumPort port) : base(port)
    {
        Value = port.Value;
    }

    /// <summary>
    /// Gets the brand.
    /// </summary>
    public override PortBrand Brand => PortBrand.Enum;

    /// <summary>
    /// Updates the value.
    /// </summary>
    /// <param name="port">The port.</param>
    public override void UpdateValue(IPort port) {
        var sourcePort = (EnumPort)port;
        Value = sourcePort.Value;
    }
}
