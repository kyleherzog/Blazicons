namespace Blazicons;

/// <summary>
/// Represents the styling to be applied to a layered text or counter overlay.
/// </summary>
public sealed class LayerStyling : BlaziconContentBase<LayerStyling>, IEquatable<LayerStyling>
{
    /// <summary>
    /// Gets a new <see cref="LayerStyling"/> instance with default settings as a starting point for chaining.
    /// </summary>
    public static LayerStyling Default => new();

    /// <summary>
    /// Gets the value to be applied to the background-color CSS property.
    /// </summary>
    public string? BackgroundColor { get; private set; }

    /// <summary>
    /// Gets the corner at which the counter badge is anchored.
    /// </summary>
    public LayerCorner Corner { get; private set; }

    /// <summary>
    /// Applies the specified corner anchor.
    /// </summary>
    /// <param name="corner">The corner at which the counter badge is anchored.</param>
    /// <returns>The current <see cref="LayerStyling"/> instance.</returns>
    public LayerStyling AnchorTo(LayerCorner corner)
    {
        Corner = corner;
        return this;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is LayerStyling other)
        {
            return Equals(other);
        }

        return false;
    }

    /// <inheritdoc/>
    public bool Equals(LayerStyling? other)
    {
        return other is not null
            && BackgroundColor == other.BackgroundColor
            && Corner == other.Corner
            && Color == other.Color
            && Size == other.Size
            && ScaleFactor.EquatesTo(other.ScaleFactor)
            && Rotation.EquatesTo(other.Rotation)
            && OffsetX.EquatesTo(other.OffsetX)
            && OffsetY.EquatesTo(other.OffsetY)
            && IsFlippedHorizontal == other.IsFlippedHorizontal
            && IsFlippedVertical == other.IsFlippedVertical
            && Equals(Animation, other.Animation);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = default(HashCode);
        hash.Add(BackgroundColor);
        hash.Add(Corner);
        hash.Add(Color);
        hash.Add(Size);
        hash.Add(ScaleFactor);
        hash.Add(Rotation);
        hash.Add(OffsetX);
        hash.Add(OffsetY);
        hash.Add(IsFlippedHorizontal);
        hash.Add(IsFlippedVertical);
        hash.Add(Animation);
        return hash.ToHashCode();
    }

    /// <summary>
    /// Applies the specified CSS background-color value.
    /// </summary>
    /// <param name="backgroundColor">The CSS background-color value to be applied.</param>
    /// <returns>The current <see cref="LayerStyling"/> instance.</returns>
    public LayerStyling WithBackgroundColor(string? backgroundColor)
    {
        BackgroundColor = backgroundColor;
        return this;
    }
}