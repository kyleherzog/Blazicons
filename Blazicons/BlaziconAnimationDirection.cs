namespace Blazicons;

/// <summary>
/// Specifies the direction in which a Blazicon animation plays.
/// </summary>
public enum BlaziconAnimationDirection
{
    /// <summary>
    /// The animation plays forward each cycle.
    /// </summary>
    Normal,

    /// <summary>
    /// The animation plays backward each cycle.
    /// </summary>
    Reverse,

    /// <summary>
    /// The animation alternates direction each cycle, playing forward then backward.
    /// </summary>
    Alternate,

    /// <summary>
    /// The animation alternates direction each cycle, playing backward then forward.
    /// </summary>
    AlternateReverse,
}

internal static class BlaziconAnimationDirectionExtensions
{
    internal static string ToCssValue(this BlaziconAnimationDirection direction)
    {
        return direction switch
        {
            BlaziconAnimationDirection.Reverse => "reverse",
            BlaziconAnimationDirection.Alternate => "alternate",
            BlaziconAnimationDirection.AlternateReverse => "alternate-reverse",
            _ => "normal",
        };
    }
}
