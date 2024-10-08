namespace AyBorg.Types.Ports;

/// <summary>
/// The different port brands.
/// </summary>
public enum PortBrand
{
    /// <summary>
    /// Unknown port brand.
    /// </summary>
    Unknown = -1,

    /// <summary>
    /// Numeric port brand.
    /// </summary>
    Numeric = 10,

    /// <summary>
    /// Numeric collection port brand.
    /// </summary>
    NumericCollection = 11,

    /// <summary>
    /// String port brand.
    /// </summary>
    String = 20,

    /// <summary>
    /// Folder port brand.
    /// </summary>
    Folder = 21,

    /// <summary>
    /// String collection port brand.
    /// </summary>
    StringCollection = 22,

    /// <summary>
    /// Boolean port brand.
    /// </summary>
    Boolean = 30,

    /// <summary>
    /// Enum port brand.
    /// </summary>
    Enum = 40,

    /// <summary>
    /// Select port brand.
    /// </summary>
    Select = 41,

    /// <summary>
    /// Image port brand.
    /// </summary>
    Image = 100,

    /// <summary>
    /// Rectangle port brand.
    /// </summary>
    Rectangle = 110,

    /// <summary>
    /// Rectangle collection port brand.
    /// </summary>
    RectangleCollection = 111,
}
