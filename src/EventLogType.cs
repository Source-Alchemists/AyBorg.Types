using System.ComponentModel;

namespace AyBorg.Types;

/// <summary>
/// Event log type.
/// </summary>
public enum EventLogType
{
    // Registry

    /// <summary>
    /// Connect.
    /// </summary>
    [Description("Connect")]
    Connect = 42000,

    /// <summary>
    /// Disconnect.
    /// </summary>
    [Description("Disconnect")]
    Disconnect = 42001,

    /// <summary>
    /// Upload.
    /// </summary>
    [Description("Upload")]
    Upload = 42002,

    /// <summary>
    /// Download.
    /// </summary>
    [Description("Download")]
    Download = 42003,

    // Common

    /// <summary>
    /// Result.
    /// </summary>
    [Description("Result")]
    Result = 42010,

    /// <summary>
    /// User Interaction.
    /// </summary>
    [Description("User Interaction")]
    UserInteraction = 42020,

    // Engine

    /// <summary>
    /// Engine.
    /// </summary>
    [Description("Engine")]
    Engine = 42100,

    /// <summary>
    /// Plugin.
    /// </summary>
    [Description("Plugin")]
    Plugin = 42110,

    /// <summary>
    /// Project state.
    /// </summary>
    [Description("Project State")]
    ProjectState = 42200,

    /// <summary>
    /// Project saved.
    /// </summary>
    [Description("Project saved")]
    ProjectSaved = 42201,

    /// <summary>
    /// Project removed.
    /// </summary>
    [Description("Project removed")]
    ProjectRemoved = 42202,

    // Audit

    /// <summary>
    /// Audit.
    /// </summary>
    [Description("Audit")]
    Audit = 42300,

    // Cognitive

    /// <summary>
    /// Cognitive.
    /// </summary>
    [Description("Cognitive")]
    Cognitive = 42400
}
