namespace AyBorg.Types.Result;

/// <summary>
/// Represents a result storage provider.
/// </summary>
public interface IResultStorageProvider
{
    /// <summary>
    /// Adds the specified result.
    /// </summary>
    void Add(PortResult result);
}
