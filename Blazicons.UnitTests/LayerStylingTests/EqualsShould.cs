namespace Blazicons.UnitTests.LayerStylingTests;

[TestClass]
public class EqualsShould
{
    [TestMethod]
    public void ReturnFalseGivenNull()
    {
        var styling = LayerStyling.Default;

        var result = styling.Equals(null);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentBackgroundColor()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.WithBackgroundColor("#000");

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentColoring()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.WithColor("#ff0000");

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentCorner()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.AnchorTo(LayerCorner.BottomLeft);

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentHorizontalFlip()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.FlipHorizontal();

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentOffsetX()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.PushRight(2);

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentOffsetY()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.PushDown(2);

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentRotation()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.Rotate(45);

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentScaleFactor()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.Scale(1.5);

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentSizing()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.WithSize("200%");

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherStylingWithDifferentVerticalFlip()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.FlipVertical();

        var result = styling.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherType()
    {
        var styling = LayerStyling.Default;

        var result = styling.Equals(new object());

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnTrueGivenOtherStylingWithSameValues()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default;

        var result = styling.Equals(other);

        Assert.IsTrue(result);
    }
}