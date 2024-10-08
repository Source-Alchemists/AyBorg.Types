using System.ComponentModel;

namespace AyBorg.Types;

/// <summary>
/// Symbolizes different units.
/// </summary>
public enum Unit
{
    /// <summary>
    /// Hertz.
    /// </summary>
    [Description("1/s")]
    Hertz = 100,

    /// <summary>
    /// Nanoseconds.
    /// </summary>
    [Description("ns")]
    Nanoseconds = 101,

    /// <summary>
    /// Microseconds.
    /// </summary>
    [Description("µs")]
    Microseconds = 102,

    /// <summary>
    /// Milliseconds.
    /// </summary>
    [Description("ms")]
    Milliseconds = 103,

    /// <summary>
    /// Seconds.
    /// </summary>
    [Description("s")]
    Seconds = 104,

    /// <summary>
    /// Minutes.
    /// </summary>
    [Description("min")]
    Minutes = 105,

    /// <summary>
    /// Hours.
    /// </summary>
    [Description("h")]
    Hours = 106,

    /// <summary>
    /// Days.
    /// </summary>
    [Description("d")]
    Days = 107
}
