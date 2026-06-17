using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Blazicons;

/// <summary>
/// A component that renders a counter badge overlay within a <see cref="BlaziconLayers"/> container.
/// </summary>
public partial class BlaziconLayersCounter
{
    /// <summary>
    /// Gets or sets the attributes specified but not explicitly mapped to a property.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets or sets the child content to display as the counter badge.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the styling to apply to the counter badge.
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
                .Where(x => x.Key != "style" && x.Key != "blazicon-layers-counter")
                .ToDictionary(x => x.Key, x => x.Value);
            result["blazicon-layers-counter"] = string.Empty;
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
            result.AddStyle("background-color", Styling?.BackgroundColor, !string.IsNullOrEmpty(Styling?.BackgroundColor));
            result.AddStyle("color", Styling?.Color, !string.IsNullOrEmpty(Styling?.Color));
            result.AddStyle("font-size", Styling?.Size, !string.IsNullOrEmpty(Styling?.Size));
            var corner = Styling?.Corner ?? LayerCorner.TopRight;
            switch (corner)
            {
                case LayerCorner.BottomRight:
                    result.AddStyle("top", "auto");
                    result.AddStyle("bottom", "0");
                    result.AddStyle("transform-origin", "bottom right");
                    break;

                case LayerCorner.BottomLeft:
                    result.AddStyle("top", "auto");
                    result.AddStyle("bottom", "0");
                    result.AddStyle("right", "auto");
                    result.AddStyle("left", "0");
                    result.AddStyle("transform-origin", "bottom left");
                    break;

                case LayerCorner.TopLeft:
                    result.AddStyle("right", "auto");
                    result.AddStyle("left", "0");
                    result.AddStyle("transform-origin", "top left");
                    break;
            }

            var userTransform = Styling?.TransformStyle;
            var transform = string.IsNullOrEmpty(userTransform) ? "scale(0.25)" : $"scale(0.25) {userTransform}";
            result.AddStyle("transform", transform);
            return result.NullIfEmpty();
        }
    }
}