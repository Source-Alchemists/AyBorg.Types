namespace AyBorg.Types.Models;

/// <summary>
/// Represents an enum.
/// </summary>
public sealed record EnumModel
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Gets or sets the names.
    /// </summary>
    public string[]? Names { get; init; }

    /// <summary>
    /// Equals.
    /// </summary>
    /// <param name="other">Other enum.</param>
    /// <returns>True if equal.</returns>
    public bool Equals(EnumModel? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (other.Name == null || Name == null) return false;
        if (Name != other.Name) return false;
        if (Names == null || other.Names == null) return false;

        foreach (string n in Names)
        {
            if (!other.Names.Contains(n)) return false;
        }

        return true;
    }

    /// <summary>
    /// Get hash code.
    /// </summary>
    /// <returns>Hash code.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Names);
    }
}
