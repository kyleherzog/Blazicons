using System.Collections.ObjectModel;
using System.Text;

namespace Blazicons;

/// <summary>
/// Represents an SVG icon to be rendered.
/// </summary>
public sealed class SvgIcon : BlaziconContentBase<SvgIcon>, IEquatable<SvgIcon>
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
    /// Gets the markup content that is to reside between the SVG start and end tags.
    /// </summary>
    public string Content { get; }

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
            && ScaleFactor.EquatesTo(other.ScaleFactor)
            && Rotation.EquatesTo(other.Rotation)
            && OffsetX.EquatesTo(other.OffsetX)
            && OffsetY.EquatesTo(other.OffsetY)
            && IsFlippedHorizontal == other.IsFlippedHorizontal
            && IsFlippedVertical == other.IsFlippedVertical;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = default(HashCode);
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
}