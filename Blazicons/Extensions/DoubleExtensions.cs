namespace Blazicons;

internal static class DoubleExtensions
{
    private const double epsilon = 1e-10;

    internal static bool EquatesTo(this double value, double other)
    {
        return Math.Abs(value - other) <= epsilon;
    }

    internal static bool EquatesTo(this double? value, double? other)
    {
        if (!value.HasValue && !other.HasValue)
        {
            return true;
        }

        if (!value.HasValue || !other.HasValue)
        {
            return false;
        }

        return value.Value.EquatesTo(other.Value);
    }
}