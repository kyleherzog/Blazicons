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
            __builder.AddAttribute(1, "viewBox", Svg.ViewBox);
            __builder.AddAttribute(2, "blazicon");
            if (!string.IsNullOrEmpty(StyleAttribute))
            {
                __builder.AddAttribute(3, "style", StyleAttribute);
            }

            __builder.AddMultipleAttributes(4, AttributesNoStyle);
            __builder.AddContent(5, new MarkupString(Svg.Content));
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
        return !lastSvgHash.Equals(Svg?.GetHashCode());
    }
}