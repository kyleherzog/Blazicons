namespace Blazicons;

/// <summary>
/// Represents an SVG icon to be rendered.
/// </summary>
public sealed class SvgIcon : IEquatable<SvgIcon>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SvgIcon"/> class.
    /// </summary>
    /// <param name="content">The markup content that is to reside between the SVG start and end tags.</param>
    /// <param name="viewBox">The value to be used for the viewbox attribute.</param>
    private SvgIcon(string content, string viewBox)
    {
        Content = content;
        ViewBox = viewBox;
    }

    /// <summary>
    /// Gets or sets value to be applied to a the color CSS property.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets value to be applied to a the font-size CSS property.
    /// </summary>
    public string? Size { get; set; }

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
            return $"<svg viewBox='{ViewBox}'>{Content}</svg>";
        }
    }

    /// <summary>
    /// Gets the value to be used for the viewbox attribute of the SVG tag.
    /// </summary>
    public string ViewBox { get; }

    /// <summary>
    /// Creates an SVG icon from the specified path data.
    /// </summary>
    /// <param name="pathData">The path data that is to be used to create a full path tag and then used as the SVG content.</param>
    /// <param name="viewBox">An optional value to specify the size of the SVG view box.</param>
    /// <returns>The newly created <see cref="SvgIcon"/> instance.</returns>
    public static SvgIcon FromPathData(string pathData, string viewBox = "0 0 24 24")
    {
        return new SvgIcon($"<path d=\"{pathData}\" />", viewBox);
    }

    /// <summary>
    /// Creates an SVG icon from the specified markup content.
    /// </summary>
    /// <param name="content">The markup content that is to reside between the SVG start and end tags.</param>
    /// <param name="viewBox">The value to be used for the viewbox attribute.</param>
    /// <returns>The newly created <see cref="SvgIcon"/> instance.</returns>
    public static SvgIcon FromContent(string content, string viewBox = "0 0 24 24")
    {
        return new SvgIcon(content, viewBox);
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

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Content, ViewBox, Color, Size);
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
            && ViewBox == other.ViewBox
            && Color == other.Color
            && Size == other.Size;
    }
}