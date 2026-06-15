using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace Blazicons;

/// <summary>
/// Represents an SVG icon to be rendered.
/// </summary>
public sealed class SvgIcon : IEquatable<SvgIcon>
{
    private static readonly ReadOnlyDictionary<string, string?> defaultAttributes = new(new Dictionary<string, string?>()
    {
        { "viewBox", "0 0 24 24" },
    });

    /// <summary>
    /// Initializes a new instance of the <see cref="SvgIcon"/> class.
    /// </summary>
    /// <param name="content">The markup content that is to reside between the SVG start and end tags.</param>
    /// <param name="viewBox">The value to be used for the viewbox attribute.</param>
    private SvgIcon(string content, string viewBox)
        : this(content, new ReadOnlyDictionary<string, string?>(new Dictionary<string, string?> { { "viewBox", viewBox } }))
    {
    }

    private SvgIcon(string content, ReadOnlyDictionary<string, string?> attributes)
    {
        Content = content;
        Attributes = attributes;
    }

    /// <summary>
    /// Gets the attributes to be applied to the root SVG element.
    /// </summary>
    public ReadOnlyDictionary<string, string?> Attributes { get; }

    /// <summary>
    /// Gets or sets value to be applied to a the color CSS property.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Gets the markup content that is to reside between the SVG start and end tags.
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the SVG icon is flipped horizontally.
    /// </summary>
    public bool IsFlippedHorizontal { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the SVG icon is flipped vertically.
    /// </summary>
    public bool IsFlippedVertical { get; set; }

    /// <summary>
    /// Gets the markup that represents the SVG icon.
    /// </summary>
    public string Markup
    {
        get
        {
            var builder = new StringBuilder();
            builder.Append("<svg");
            foreach (var attribute in Attributes)
            {
                builder.Append($" {attribute.Key}='{attribute.Value}'");
            }

            builder.Append('>');
            builder.Append(Content);
            builder.Append("</svg>");
            return builder.ToString();
        }
    }

    /// <summary>
    /// Gets or sets the X-axis offset to be applied to the SVG icon.
    /// </summary>
    public double OffsetX { get; set; }

    /// <summary>
    /// Gets or sets the Y-axis offset to be applied to the SVG icon.
    /// </summary>
    public double OffsetY { get; set; }

    /// <summary>
    /// Gets or sets the rotation in degrees to be applied to the SVG icon.
    /// </summary>
    public double? Rotation { get; set; }

    /// <summary>
    /// Gets or sets the scale factor to be applied to the SVG icon.
    /// </summary>
    public double? ScaleFactor { get; set; }

    /// <summary>
    /// Gets or sets value to be applied to a the font-size CSS property.
    /// </summary>
    public string? Size { get; set; }

    /// <summary>
    /// Gets the CSS transform value representing all active transforms on the SVG icon.
    /// </summary>
    public string? TransformStyle
    {
        get
        {
            var parts = new List<string>();

            if (OffsetX != 0 || OffsetY != 0)
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
    /// Gets the value to be used for the viewbox attribute of the SVG tag.
    /// </summary>
    public string? ViewBox { get => Attributes["viewBox"]; }

    /// <summary>
    /// Creates an SVG icon from the specified markup content.
    /// </summary>
    /// <param name="content">The markup content that is to reside between the SVG start and end tags.</param>
    /// <param name="viewBox">The value to be used for the viewbox attribute.</param>
    /// <returns>The newly created <see cref="SvgIcon"/> instance.</returns>
    public static SvgIcon FromContent(string content, string viewBox)
    {
        return new SvgIcon(content, viewBox);
    }

    /// <summary>
    /// Creates an SVG icon from the specified markup content.
    /// </summary>
    /// <param name="content">The markup content that is to reside between the SVG start and end tags.</param>
    /// <param name="attributes">The values to use for the attributes on the SVG icon.</param>
    /// <returns>The newly created <see cref="SvgIcon"/> instance.</returns>
    public static SvgIcon FromContent(string content, ReadOnlyDictionary<string, string?>? attributes = null)
    {
        attributes ??= defaultAttributes;

        return new SvgIcon(content, attributes);
    }

    /// <summary>
    /// Creates an SVG icon from the specified path data.
    /// </summary>
    /// <param name="pathData">
    /// The path data that is to be used to create a full path tag and then used as the SVG content.
    /// </param>
    /// <param name="viewBox">An optional value to specify the size of the SVG view box.</param>
    /// <returns>The newly created <see cref="SvgIcon"/> instance.</returns>
    public static SvgIcon FromPathData(string pathData, string viewBox = "0 0 24 24")
    {
        return new SvgIcon($"<path d=\"{pathData}\" />", viewBox);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is SvgIcon other)
        {
            return Equals(other);
        }

        return false;
    }

    /// <inheritdoc/>
    public bool Equals(SvgIcon? other)
    {
        return other is not null
            && Content == other.Content
            && Attributes == other.Attributes
            && Color == other.Color
            && Size == other.Size
            && ScaleFactor == other.ScaleFactor
            && Rotation == other.Rotation
            && OffsetX == other.OffsetX
            && OffsetY == other.OffsetY
            && IsFlippedHorizontal == other.IsFlippedHorizontal
            && IsFlippedVertical == other.IsFlippedVertical;
    }

    /// <summary>
    /// Sets whether the SVG icon is flipped horizontally.
    /// </summary>
    /// <param name="isFlipped">A value indicating whether the icon should be flipped horizontally.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon FlipHorizontal(bool isFlipped = true)
    {
        IsFlippedHorizontal = isFlipped;
        return this;
    }

    /// <summary>
    /// Sets whether the SVG icon is flipped vertically.
    /// </summary>
    /// <param name="isFlipped">A value indicating whether the icon should be flipped vertically.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon FlipVertical(bool isFlipped = true)
    {
        IsFlippedVertical = isFlipped;
        return this;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Content);
        hash.Add(Attributes);
        hash.Add(Color);
        hash.Add(Size);
        hash.Add(ScaleFactor);
        hash.Add(Rotation);
        hash.Add(OffsetX);
        hash.Add(OffsetY);
        hash.Add(IsFlippedHorizontal);
        hash.Add(IsFlippedVertical);
        return hash.ToHashCode();
    }

    /// <summary>
    /// Scales the SVG icon up by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to grow the icon by, relative to a base of 16 units.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon Grow(double amount)
    {
        ScaleFactor = (16 + amount) / 16.0;
        return this;
    }

    /// <summary>
    /// Applies the specified X and Y offset to the SVG icon.
    /// </summary>
    /// <param name="x">The X-axis offset in em units.</param>
    /// <param name="y">The Y-axis offset in em units.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon Offset(double x, double y)
    {
        OffsetX = x;
        OffsetY = y;
        return this;
    }

    /// <summary>
    /// Moves the SVG icon downward by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to move the icon downward, relative to a base of 16 units.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon PushDown(double amount)
    {
        OffsetY += amount / 16.0;
        return this;
    }

    /// <summary>
    /// Moves the SVG icon to the left by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to move the icon to the left, relative to a base of 16 units.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon PushLeft(double amount)
    {
        OffsetX -= amount / 16.0;
        return this;
    }

    /// <summary>
    /// Moves the SVG icon to the right by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to move the icon to the right, relative to a base of 16 units.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon PushRight(double amount)
    {
        OffsetX += amount / 16.0;
        return this;
    }

    /// <summary>
    /// Moves the SVG icon upward by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to move the icon upward, relative to a base of 16 units.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon PushUp(double amount)
    {
        OffsetY -= amount / 16.0;
        return this;
    }

    /// <summary>
    /// Applies the specified rotation to the SVG icon.
    /// </summary>
    /// <param name="degrees">The rotation in degrees to be applied.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon Rotate(double degrees)
    {
        Rotation = degrees;
        return this;
    }

    /// <summary>
    /// Applies the specified scale factor to the SVG icon.
    /// </summary>
    /// <param name="value">The scale factor to be applied.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon Scale(double value)
    {
        ScaleFactor = value;
        return this;
    }

    /// <summary>
    /// Scales the SVG icon down by the specified amount using the 1/16 convention.
    /// </summary>
    /// <param name="amount">The amount to shrink the icon by, relative to a base of 16 units.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon Shrink(double amount)
    {
        ScaleFactor = (16 - amount) / 16.0;
        return this;
    }

    /// <summary>
    /// Applies the specified color to the SVG icon.
    /// </summary>
    /// <param name="color">The CSS color value to be applied.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon WithColor(string? color)
    {
        Color = color;
        return this;
    }

    /// <summary>
    /// Applies the specified CSS font-size value to the SVG icon.
    /// </summary>
    /// <param name="size">The CSS font-size value to be applied.</param>
    /// <returns>The current <see cref="SvgIcon"/> instance.</returns>
    public SvgIcon WithSize(string? size)
    {
        Size = size;
        return this;
    }
}