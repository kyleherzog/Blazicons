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
        using var context = new BunitContext();
        var icon = IconFactory.Alert;
        var attributes = new Dictionary<string, object>
        {
            { "style", "display: block;" },
        };

        var component = context.Render<Blazicon>(parameters =>
        {
            parameters.Add(p => p.Svg, icon.WithSize("150%"));
            parameters.Add(p => p.Attributes, attributes);
        });

        var markup = component.Markup;

        return Verify(markup);
    }

    [TestMethod]
    public Task RenderWithAnimationGivenBeatSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.Animate(BlaziconAnimation.Beat),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithAnimationGivenBeatWithCustomDurationSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.Animate(BlaziconAnimation.Beat.WithDuration(2000)),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithAnimationGivenSpinSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.Animate(BlaziconAnimation.Spin),
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
    public Task RenderWithTransformGivenFlipHorizontalSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.FlipHorizontal(),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithTransformGivenFlipVerticalSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.FlipVertical(),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithTransformGivenGrowCalled()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.Grow(2),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithTransformGivenMultipleTransformsSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.Scale(1.5).Rotate(45).PushRight(2).FlipHorizontal(),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithTransformGivenOffsetSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.Offset(1, 0.5),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithTransformGivenPushRightCalled()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.PushRight(2),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithTransformGivenRotationSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.Rotate(45),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithTransformGivenScaleSet()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.Scale(1.5),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RenderWithTransformGivenShrinkCalled()
    {
        var template = new Blazicon
        {
            Svg = IconFactory.Alert.Shrink(2),
        };

        var output = Render.Component(template: template);
        return Verify(output);
    }

    [TestMethod]
    public Task RerenderGivenAttributeValueChanged()
    {
        using var context = new BunitContext();
        var icon = IconFactory.Alert;
        var attributes = new Dictionary<string, object>
        {
            { "class", "hello" },
        };
        var component = context.Render<Blazicon>(parameters =>
        {
            parameters.Add(p => p.Svg, icon);
            parameters.Add(p => p.Attributes, attributes);
        });

        var markup1 = component.Markup;

        attributes["class"] = "world";
        component.Render(parameters =>
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
        using var context = new BunitContext();
        var icon = IconFactory.Alert;
        var component = context.Render<Blazicon>(parameters =>
        {
            parameters.Add(p => p.Svg, icon);
        });

        var markup1 = component.Markup;

        icon = IconFactory.AlertOutline;
        component.Render(parameters =>
        {
            parameters.Add(p => p.Svg, icon);
        });

        var markup2 = component.Markup;
        Assert.AreNotEqual(markup1, markup2);

        return Verify(markup2);
    }
}