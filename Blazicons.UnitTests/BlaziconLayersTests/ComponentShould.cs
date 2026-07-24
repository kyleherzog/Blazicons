using Bunit;
using Microsoft.AspNetCore.Components;
using VerifyTests.Blazor;

namespace Blazicons.UnitTests.BlaziconLayersTests;

[TestClass]
public class ComponentShould : VerifyBase
{
    [TestMethod]
    public Task RenderEmptySpanGivenNoChildContentSet()
    {
        var template = new BlaziconLayers();

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RendersWithClassAttributeGivenClassSet()
    {
        using var context = new BunitContext();
        var attributes = new Dictionary<string, object>
        {
            { "class", "my-layers" },
        };

        var component = context.Render<BlaziconLayers>(parameters =>
        {
            parameters.Add(p => p.Attributes, attributes);
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.OpenComponent<Blazicon>(0);
                builder.AddAttribute(1, nameof(Blazicon.Svg), IconFactory.Alert);
                builder.CloseComponent();
            }));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RendersWithMergedStylesGivenStyleSet()
    {
        using var context = new BunitContext();
        var attributes = new Dictionary<string, object>
        {
            { "style", "font-size: 3em;" },
        };

        var component = context.Render<BlaziconLayers>(parameters =>
        {
            parameters.Add(p => p.Attributes, attributes);
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.OpenComponent<Blazicon>(0);
                builder.AddAttribute(1, nameof(Blazicon.Svg), IconFactory.Alert);
                builder.CloseComponent();
            }));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RenderWithOneLayerGivenOneChildIcon()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayers>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.OpenComponent<Blazicon>(0);
                builder.AddAttribute(1, nameof(Blazicon.Svg), IconFactory.Alert);
                builder.CloseComponent();
            }));
        });

        return Verify(component.Markup);
    }

    [TestMethod]
    public Task RenderWithTwoLayersGivenTwoChildIcons()
    {
        using var context = new BunitContext();
        var component = context.Render<BlaziconLayers>(parameters =>
        {
            parameters.Add(p => p.ChildContent, (RenderFragment)(builder =>
            {
                builder.OpenComponent<Blazicon>(0);
                builder.AddAttribute(1, nameof(Blazicon.Svg), IconFactory.Alert);
                builder.CloseComponent();
                builder.OpenComponent<Blazicon>(2);
                builder.AddAttribute(3, nameof(Blazicon.Svg), IconFactory.AlertOutline);
                builder.CloseComponent();
            }));
        });

        return Verify(component.Markup);
    }
}