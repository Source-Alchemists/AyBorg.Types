﻿namespace AyBorg.Types.Ports;

/// <summary>
/// Represents a generic port.
/// </summary>
public interface IPortGeneric<TValue> : IPort
{
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    TValue Value { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is link convertable.
    /// </summary>
    bool IsLinkConvertable { get; }
}
