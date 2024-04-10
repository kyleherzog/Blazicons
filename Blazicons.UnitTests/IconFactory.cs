using System.Collections.ObjectModel;

namespace Blazicons.UnitTests;

internal static class IconFactory
{
    private static readonly ReadOnlyDictionary<string, string> attributes = new(new Dictionary<string, string>() { { "viewBox", "0 0 24 24" } });

    public static SvgIcon Alert => SvgIcon.FromContent("<path d=\"M13 14H11V9H13M13 18H11V16H13M1 21H23L12 2L1 21Z\" />", attributes);

    public static SvgIcon AlertOutline => SvgIcon.FromContent("<path d=\"M12,2L1,21H23M12,6L19.53,19H4.47M11,10V14H13V10M11,16V18H13V16\" />", attributes);
}