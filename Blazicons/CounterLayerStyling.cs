namespace Blazicons;

/// <summary>
/// Provides predefined <see cref="LayerStyling"/> starting points for counter badge overlay layers.
/// </summary>
public static class CounterLayerStyling
{
    /// <summary>
    /// Gets a new <see cref="LayerStyling"/> instance pre-configured with white text, a red background, and a
    /// bottom-left anchor.
    /// </summary>
    public static LayerStyling BottomLeft => LayerStyling.Default.WithColor("#fff").WithBackgroundColor("#f00").AnchorTo(LayerCorner.BottomLeft);

    /// <summary>
    /// Gets a new <see cref="LayerStyling"/> instance pre-configured with white text, a red background, and a
    /// bottom-right anchor.
    /// </summary>
    public static LayerStyling BottomRight => LayerStyling.Default.WithColor("#fff").WithBackgroundColor("#f00").AnchorTo(LayerCorner.BottomRight);

    /// <summary>
    /// Gets a new <see cref="LayerStyling"/> instance pre-configured with white text, a red background, and a top-right
    /// anchor as a starting point for chaining.
    /// </summary>
    public static LayerStyling Default => TopRight;

    /// <summary>
    /// Gets a new <see cref="LayerStyling"/> instance pre-configured with white text, a red background, and a top-left
    /// anchor.
    /// </summary>
    public static LayerStyling TopLeft => LayerStyling.Default.WithColor("#fff").WithBackgroundColor("#f00").AnchorTo(LayerCorner.TopLeft);

    /// <summary>
    /// Gets a new <see cref="LayerStyling"/> instance pre-configured with white text, a red background, and a top-right
    /// anchor.
    /// </summary>
    public static LayerStyling TopRight => LayerStyling.Default.WithColor("#fff").WithBackgroundColor("#f00").AnchorTo(LayerCorner.TopRight);
}