using VerifyTests.Blazor;
using Bunit;
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