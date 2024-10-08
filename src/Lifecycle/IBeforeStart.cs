namespace AyBorg.Types;

/// <summary>
/// Used to perform actions before the <cref see="IStepBody"/> is started.
/// </summary>
public interface IBeforeStart
{
    /// <summary>
    /// Called [before start].
    /// Called once on single run or continuous run before TryRunAsync.
    /// </summary>
    ValueTask BeforeStartAsync();
}
