using Bunit;
using Microsoft.AspNetCore.Components;
using VerifyTests.Blazor;

namespace Blazicons.UnitTests.BlaziconLayersCounterTests;

[TestClass]
public class ComponentShould : VerifyBase
{
    [TestMethod]
    public Task RenderCounterGivenChildContentSet()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayersCounter>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.AddContent(0, "3");
            }));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RenderEmptySpanGivenNoChildContentSet()
    {
        var template = new BlaziconLayersCounter();

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderInsideLayersGivenIconAndCounterChild()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayers>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.OpenComponent<Blazicon>(0);
                builder.AddAttribute(1, nameof(Blazicon.Svg), IconFactory.Alert);
                builder.CloseComponent();
                builder.OpenComponent<BlaziconLayersCounter>(2);
                builder.AddAttribute(3, nameof(BlaziconLayersCounter.ChildContent), (RenderFragment)(b => b.AddContent(0, "3")));
                builder.CloseComponent();
            }));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RenderWithColorGivenColorSet()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayersCounter>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.AddContent(0, "3");
            }));
            parameters.Add(p => p.Styling, LayerStyling.Default.WithColor("#ff0000"));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RenderWithSizeGivenSizeSet()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayersCounter>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.AddContent(0, "3");
            }));
            parameters.Add(p => p.Styling, LayerStyling.Default.WithSize("0.5em"));
        });

        return Verify(component.Markup);
    }
}