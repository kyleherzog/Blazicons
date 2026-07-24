using Bunit;
using Microsoft.AspNetCore.Components;
using VerifyTests.Blazor;

namespace Blazicons.UnitTests.BlaziconLayersTextTests;

[TestClass]
public class ComponentShould : VerifyBase
{
    [TestMethod]
    public Task RenderEmptySpanGivenNoChildContentSet()
    {
        var template = new BlaziconLayersText();

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderInsideLayersGivenIconAndTextChild()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayers>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.OpenComponent<Blazicon>(0);
                builder.AddAttribute(1, nameof(Blazicon.Svg), IconFactory.Alert);
                builder.CloseComponent();
                builder.OpenComponent<BlaziconLayersText>(2);
                builder.AddAttribute(3, nameof(BlaziconLayersText.ChildContent), (RenderFragment)(b => b.AddContent(0, "!")));
                builder.CloseComponent();
            }));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RenderTextGivenChildContentSet()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayersText>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.AddContent(0, "99");
            }));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RenderWithColorGivenColorSet()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayersText>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.AddContent(0, "99");
            }));
            parameters.Add(p => p.Styling, LayerStyling.Default.WithColor("#ff0000"));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RenderWithSizeGivenSizeSet()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayersText>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.AddContent(0, "99");
            }));
            parameters.Add(p => p.Styling, LayerStyling.Default.WithSize("0.5em"));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RenderWithTransformGivenRotationSet()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayersText>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.AddContent(0, "99");
            }));
            parameters.Add(p => p.Styling, LayerStyling.Default.Rotate(45));
        });

        return Verify(component.Markup);
    }
}