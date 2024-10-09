namespace AyBorg.Types;

/// <summary>
/// Represents the environment of the application.
/// </summary>
public interface IEnvironment
{
    /// <summary>
    /// Gets the storage location.
    /// </summary>
    string StorageLocation { get; }
}
