using System.Globalization;

namespace Blazicons;

/// <summary>
/// Provides the base set of style and transform properties shared across Blazicon content types.
/// </summary>
/// <typeparam name="T">The concrete type that extends this base class.</typeparam>
public abstract class BlaziconContentBase<T>
    where T : BlaziconContentBase<T>
{
    /// <summary>
    /// Gets or sets the value to be applied to the color CSS property.
    /// </summary>
    public string? Color { get; protected set; }

    /// <summary>
    /// Gets or sets a value indicating whether the content is flipped horizontally.
    /// </summary>
    public bool IsFlippedHorizontal { get; protected set; }

    /// <summary>
    /// Gets or sets a value indicating whether the content is flipped vertically.
    /// </summary>
    public bool IsFlippedVertical { get; protected set; }

    /// <summary>
    /// Gets or sets the X-axis offset in em units.
    /// </summary>
    public double OffsetX { get; protected set; }

    /// <summary>
    /// Gets or sets the Y-axis offset in em units.
    /// </summary>
    public double OffsetY { get; protected set; }

    /// <summary>
    /// Gets or sets the rotation in degrees.
    /// </summary>
    public double? Rotation { get; protected set; }

    /// <summary>
    /// Gets or sets the scale factor.
    /// </summary>
    public double? ScaleFactor { get; protected set; }

    /// <summary>
    /// Gets or sets the value to be applied to the font-size CSS property.
    /// </summary>
    public string? Size { get; protected set; }

    /// <summary>
    /// Gets the CSS transform value representing all active transforms.
    /// </summary>
    public string? TransformStyle
    {
        get
        {
            var parts = new List<string>();

            if (!OffsetX.EquatesTo(0) || !OffsetY.EquatesTo(0))
            {
                parts.Add($"translate({OffsetX.ToString(CultureInfo.InvariantCulture)}em, {OffsetY.ToString(CultureInfo.InvariantCulture)}em)");
            }

            if (ScaleFactor.HasValue)
            {
                parts.Add($"scale({ScaleFactor.Value.ToString(CultureInfo.InvariantCulture)})");
            }

            if (Rotation.HasValue)
            {
                parts.Add($"rotate({Rotation.Value.ToString(CultureInfo.InvariantCulture)}deg)");
            }

            if (IsFlippedHorizontal)
            {
                parts.Add("scaleX(-1)");
            }

            if (IsFlippedVertical)
            {
                parts.Add("scaleY(-1)");
            }

            return parts.Count > 0 ? string.Join(" ", parts) : null;
        }
    }

    /// <summary>
    /// Sets whether the content is flipped horizontally.
    /// </summary>
    /// <param name="isFlipped">A value indicating whether to flip horizontally.</param>
    /// <returns>The current instance.</returns>
    public T FlipHorizontal(bool isFlipped = true)
    {
        IsFlippedHorizontal = isFlipped;
        return (T)this;
    }

    /// <summary>
    /// Sets whether the content is flipped vertically.
    /// </summary>
    /// <param name="isFlipped">A value indicating whether to flip vertically.</param>
    /// <returns>The current instance.</returns>
    public T FlipVertical(bool isFlipped = true)
    {
        IsFlippedVertical = isFlipped;
        return (T)this;
    }

    /// <summary>
    /// Scales the content up by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to grow by, relative to a base of 16 units.</param>
    /// <returns>The current instance.</returns>
    public T Grow(double amount)
    {
        ScaleFactor = (16 + amount) / 16.0;
        return (T)this;
    }

    /// <summary>
    /// Applies the specified X and Y offset.
    /// </summary>
    /// <param name="x">The X-axis offset in em units.</param>
    /// <param name="y">The Y-axis offset in em units.</param>
    /// <returns>The current instance.</returns>
    public T Offset(double x, double y)
    {
        OffsetX = x;
        OffsetY = y;
        return (T)this;
    }

    /// <summary>
    /// Moves the content downward by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to move downward, relative to a base of 16 units.</param>
    /// <returns>The current instance.</returns>
    public T PushDown(double amount)
    {
        OffsetY += amount / 16.0;
        return (T)this;
    }

    /// <summary>
    /// Moves the content to the left by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to move left, relative to a base of 16 units.</param>
    /// <returns>The current instance.</returns>
    public T PushLeft(double amount)
    {
        OffsetX -= amount / 16.0;
        return (T)this;
    }

    /// <summary>
    /// Moves the content to the right by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to move right, relative to a base of 16 units.</param>
    /// <returns>The current instance.</returns>
    public T PushRight(double amount)
    {
        OffsetX += amount / 16.0;
        return (T)this;
    }

    /// <summary>
    /// Moves the content upward by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to move upward, relative to a base of 16 units.</param>
    /// <returns>The current instance.</returns>
    public T PushUp(double amount)
    {
        OffsetY -= amount / 16.0;
        return (T)this;
    }

    /// <summary>
    /// Applies the specified rotation in degrees.
    /// </summary>
    /// <param name="degrees">The rotation in degrees to be applied.</param>
    /// <returns>The current instance.</returns>
    public T Rotate(double degrees)
    {
        Rotation = degrees;
        return (T)this;
    }

    /// <summary>
    /// Applies the specified scale factor.
    /// </summary>
    /// <param name="value">The scale factor to be applied.</param>
    /// <returns>The current instance.</returns>
    public T Scale(double value)
    {
        ScaleFactor = value;
        return (T)this;
    }

    /// <summary>
    /// Scales the content down by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to shrink by, relative to a base of 16 units.</param>
    /// <returns>The current instance.</returns>
    public T Shrink(double amount)
    {
        ScaleFactor = (16 - amount) / 16.0;
        return (T)this;
    }

    /// <summary>
    /// Applies the specified CSS color value.
    /// </summary>
    /// <param name="color">The CSS color value to be applied.</param>
    /// <returns>The current instance.</returns>
    public T WithColor(string? color)
    {
        Color = color;
        return (T)this;
    }

    /// <summary>
    /// Applies the specified CSS font-size value.
    /// </summary>
    /// <param name="size">The CSS font-size value to be applied.</param>
    /// <returns>The current instance.</returns>
    public T WithSize(string? size)
    {
        Size = size;
        return (T)this;
    }
}