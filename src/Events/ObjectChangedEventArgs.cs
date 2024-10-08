namespace AyBorg.Types;

/// <summary>
/// Object changed event arguments.
/// </summary>
public sealed class ObjectChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the object.
    /// </summary>
    public object Object { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectChangedEventArgs"/> class.
    /// </summary>
    public ObjectChangedEventArgs(object obj) : base()
    {
        Object = obj;
    }
}
