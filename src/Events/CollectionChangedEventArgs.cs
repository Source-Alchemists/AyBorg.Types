namespace AyBorg.Types;

/// <summary>
/// Collection changed event arguments.
/// </summary>
public sealed class CollectionChangedEventArgs : EventArgs
{
    /// <summary>
    /// Gets the new collection.
    /// </summary>
    public IEnumerable<object> NewCollection { get; }

    /// <summary>
    /// Gets the added items.
    /// </summary>
    public IEnumerable<object> AddedItems { get; }

    /// <summary>
    /// Gets the removed items.
    /// </summary>
    public IEnumerable<object> RemovedItems { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CollectionChangedEventArgs"/> class.
    /// </summary>
    /// <param name="newCollection">The new collection.</param>
    /// <param name="addedItems">The added items.</param>
    /// <param name="removedItems">The removed items.</param>
    public CollectionChangedEventArgs(IEnumerable<object> newCollection, IEnumerable<object> addedItems, IEnumerable<object> removedItems) : base()
    {
        NewCollection = newCollection;
        AddedItems = addedItems;
        RemovedItems = removedItems;
    }
}
