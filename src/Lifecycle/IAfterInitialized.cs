namespace AyBorg.Types;

/// <summary>
/// Used to perform actions after the <cref see="IStepBody"/> has been initialized.
/// </summary>
public interface IAfterInitialized
{
    /// <summary>
    /// Called [after initializing].
    /// </summary>
    ValueTask AfterInitializedAsync();
}
