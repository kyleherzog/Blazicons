namespace Blazicons.Extensions;

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