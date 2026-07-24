using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Blazicons;

/// <summary>
/// A component that renders a text overlay within a <see cref="BlaziconLayers"/> container.
/// </summary>
public partial class BlaziconLayersText
{
    /// <summary>
    /// Gets or sets the attributes specified but not explicitly mapped to a property.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets or sets the child content to display as the text layer.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the styling to apply to the text layer.
    /// </summary>
    [Parameter]
    public LayerStyling? Styling { get; set; }

    /// <summary>
    /// Gets the HTML attributes specified, but without the style attribute.
    /// </summary>
    protected Dictionary<string, object> AttributesNoStyle
    {
        get
        {
            var result = Attributes
                .Where(x => x.Key != "style" && x.Key != "blazicon-layers-text")
                .ToDictionary(x => x.Key, x => x.Value);
            result["blazicon-layers-text"] = string.Empty;
            return result;
        }
    }

    /// <summary>
    /// Gets the value to be used for the style attribute.
    /// </summary>
    protected string? StyleAttribute
    {
        get
        {
            var result = default(StyleBuilder);
            result.AddStyleFromAttributes(Attributes);
            result.AddStyle("color", Styling?.Color, !string.IsNullOrEmpty(Styling?.Color));
            result.AddStyle("font-size", Styling?.Size, !string.IsNullOrEmpty(Styling?.Size));
            result.AddStyle("transform", Styling?.TransformStyle, !string.IsNullOrEmpty(Styling?.TransformStyle));
            return result.NullIfEmpty();
        }
    }
}