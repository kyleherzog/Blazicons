namespace Blazicons;

/// <summary>
/// Provides predefined <see cref="LayerStyling"/> starting points for text overlay layers.
/// </summary>
public static class TextLayerStyling
{
    /// <summary>
    /// Gets a new <see cref="LayerStyling"/> instance pre-configured with black text as a starting point for chaining.
    /// </summary>
    public static LayerStyling Default => LayerStyling.Default.WithColor("#000");
}