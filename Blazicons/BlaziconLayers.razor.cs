using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Blazicons;

/// <summary>
/// A component that renders a stack of layered SVG icons.
/// </summary>
public partial class BlaziconLayers
{
    /// <summary>
    /// Gets or sets the attributes specified but not explicitly mapped to a property.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets or sets the child content to render as layers.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets the HTML attributes specified, but without the style attribute.
    /// </summary>
    protected Dictionary<string, object> AttributesNoStyle
    {
        get
        {
            var result = Attributes
                .Where(x => x.Key != "style" && x.Key != "blazicon-layers")
                .ToDictionary(x => x.Key, x => x.Value);
            result["blazicon-layers"] = string.Empty;
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
            return result.NullIfEmpty();
        }
    }
}
