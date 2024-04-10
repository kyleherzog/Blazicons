using Blazicons.Base;
using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blazicons;

/// <summary>
/// A component that renders an SVG icon.
/// </summary>
public class Blazicon : BlaziconBase
{
    private Dictionary<string, string> lastKnownAttributes = new();
    private int? lastSvgHash;

    /// <summary>
    /// Gets or sets the attributes specified but not explicitly mapped to a property.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets or sets the SVG icon to render.
    /// </summary>
    [Parameter]
    public SvgIcon? Svg { get; set; }

    /// <summary>
    /// Gets the HTML attributes specified, but without the style attribute.
    /// </summary>
    protected IReadOnlyDictionary<string, object> AttributesNoStyle => Attributes.Where(x => x.Key != "style").ToDictionary(x => x.Key, x => x.Value);

    /// <summary>
    /// Gets the value to be used for the style attribute.
    /// </summary>
    protected string? StyleAttribute
    {
        get
        {
            var result = default(StyleBuilder);

            result.AddStyleFromAttributes(Attributes);
            result.AddStyle("color", Svg?.Color, !string.IsNullOrEmpty(Svg?.Color));
            result.AddStyle("font-size", Svg?.Size, !string.IsNullOrEmpty(Svg?.Size));

            return result.NullIfEmpty();
        }
    }

    /// <inheritdoc/>
    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
        if (Svg is not null)
        {
            __builder.OpenElement(0, "svg");
            for (var i = 0; i < Svg.Attributes.Count; i++)
            {
                var attribute = Svg.Attributes.ElementAt(i);
                __builder.AddAttribute(i + 1, attribute.Key, attribute.Value);
            }

            __builder.AddAttribute(102, "blazicon");
            if (!string.IsNullOrEmpty(StyleAttribute))
            {
                __builder.AddAttribute(103, "style", StyleAttribute);
            }

            __builder.AddMultipleAttributes(104, AttributesNoStyle);
            __builder.AddContent(105, new MarkupString(Svg.Content));
            __builder.CloseElement();
        }
    }

    /// <inheritdoc/>
    protected override void OnAfterRender(bool firstRender)
    {
        lastSvgHash = Svg?.GetHashCode();
    }

    /// <inheritdoc/>
    protected override bool ShouldRender()
    {
        var svgHash = Svg?.GetHashCode();
        var hasSvgChanges = !lastSvgHash.Equals(svgHash);
        lastSvgHash = svgHash;

        return hasSvgChanges || HasAttributesChanged();
    }

    private bool HasAttributesChanged()
    {
        var attributes = Attributes.ToDictionary(x => x.Key, x => x.Value?.ToString() ?? string.Empty);
        var result = !attributes.SequenceEqual(lastKnownAttributes);

        lastKnownAttributes = attributes;
        return result;
    }
}