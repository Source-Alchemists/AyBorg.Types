namespace AyBorg.Types.Ports;

/// <summary>
/// Boolean port.
/// </summary>
public sealed class BooleanPort : ValuePortGeneric<BooleanPort, bool>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanPort"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="direction">The port direction.</param>
    /// <param name="value">The value.</param>
    public BooleanPort(string name, PortDirection direction, bool value) : base(name, direction, value)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanPort"/> class.
    /// </summary>
    public BooleanPort(BooleanPort port) : base(port)
    {
        Value = port.Value;
    }

    /// <summary>
    /// Gets the brand.
    /// </summary>
    public override PortBrand Brand => PortBrand.Boolean;

    /// <summary>
    /// Updates the value.
    /// </summary>
    /// <param name="port">The port.</param>
    public override void UpdateValue(IPort port) {
        var sourcePort = (BooleanPort)port;
        Value = sourcePort.Value;
    }
}
