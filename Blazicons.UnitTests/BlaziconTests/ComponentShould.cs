using Bunit;
using VerifyTests.Blazor;

namespace Blazicons.UnitTests.BlaziconTests;

[TestClass]
public class ComponentShould : VerifyBase
{
    [TestMethod]
    public Task RenderNothingGivenSvgNotSet()
    {
        var template = new Blazicon();

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderSvgGivenSvgSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert,
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RendersWithMergedStyles()
    {
        using var context = new Bunit.TestContext();
        var icon = IconFactory.Alert;
        var attributes = new Dictionary<string, object>
        {
            { "style", "display: block;" },
        };

        var component = context.RenderComponent<Blazicon>(parameters =>
        {
            parameters.Add(p => p.Svg, icon.WithSize("150%"));
            parameters.Add(p => p.Attributes, attributes);
        });

        var markup = component.Markup;

        return Verify(markup);
    }

    [TestMethod]
    public Task RenderWithColorGivenColorSetAsHex()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.WithColor("#ff0000"),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithSizeGivenSizeSetAsPercentage()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.WithSize("200%"),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithSizeGivenSizeSetAsPixels()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.WithSize("20px"),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RerenderGivenAttributeValueChanged()
    {
        using var context = new Bunit.TestContext();
        var icon = IconFactory.Alert;
        var attributes = new Dictionary<string, object>
        {
            { "class", "hello" },
        };
        var component = context.RenderComponent<Blazicon>(parameters =>
        {
            parameters.Add(p => p.Svg, icon);
            parameters.Add(p => p.Attributes, attributes);
        });

        var markup1 = component.Markup;

        attributes["class"] = "world";
        component.SetParametersAndRender(parameters =>
        {
            parameters.Add(p => p.Svg, icon);
        });

        var markup2 = component.Markup;
        Assert.AreNotEqual(markup1, markup2);

        return Verify(markup2);
    }

    [TestMethod]
    public Task RerenderGivenSvgContentChanged()
    {
        using var context = new Bunit.TestContext();
        var icon = IconFactory.Alert;
        var component = context.RenderComponent<Blazicon>(parameters =>
        {
            parameters.Add(p => p.Svg, icon);
        });

        var markup1 = component.Markup;

        icon = IconFactory.AlertOutline;
        component.SetParametersAndRender(parameters =>
        {
            parameters.Add(p => p.Svg, icon);
        });

        var markup2 = component.Markup;
        Assert.AreNotEqual(markup1, markup2);

        return Verify(markup2);
    }
}