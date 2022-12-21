using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Blazicons;

public class Blazicon : ComponentBase
{
    /// <summary>
    /// Gets or sets the attributes specified but not explicitly mapped to a property.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

    [Parameter]
    public SvgIcon? Svg { get; set; }

    /// <inheritdoc/>
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (Svg is not null)
        {
            builder.OpenElement(0, "svg");
            builder.AddAttribute(1, "viewBox", Svg.ViewBox);
            builder.AddAttribute(2, "blazicon");
            if (!string.IsNullOrEmpty(StyleAttribute))
            {
                builder.AddAttribute(3, "style", StyleAttribute);
            }
            builder.AddMultipleAttributes(4, AttributesNoStyle);
            builder.AddContent(5, new MarkupString(Svg.Content));
            builder.CloseElement();

        }
    }

    /// <summary>
    /// Gets the HTML attributes specified, but without the style attribute.
    /// </summary>
    protected IReadOnlyDictionary<string, object> AttributesNoStyle => Attributes.Where(x => x.Key != "style").ToDictionary(x => x.Key, x => x.Value);

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
}