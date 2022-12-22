namespace Blazicons;

public class SvgIcon
{
    private SvgIcon(string content, string viewBox)
    {
        Content = content;
        ViewBox = viewBox;
    }

    public string? Color { get; set; }

    public string? Size { get; set; }

    public string Content { get; }

    public string Markup
    {
        get
        {
            return $"<svg viewBox='{ViewBox}'>{Content}</svg>";
        }
    }

    public string ViewBox { get; }

    public SvgIcon WithColor(string? color)
    {
        Color = color;
        return this;
    }

    public SvgIcon WithSize(string? size)
    {
        Size = size;
        return this;
    }

    public static SvgIcon FromPathData(string pathData, string viewBox = "0 0 24 24")
    {
        return new SvgIcon($"<path d=\"{pathData}\" />", viewBox);
    }

    public static SvgIcon FromContent(string content, string viewBox = "0 0 24 24")
    {
        return new SvgIcon(content, viewBox);
    }
}
