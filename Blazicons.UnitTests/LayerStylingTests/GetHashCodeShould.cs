namespace Blazicons.UnitTests.LayerStylingTests;

[TestClass]
public class GetHashCodeShould
{
    [TestMethod]
    public void ReturnDifferentHashGivenDifferentBackgroundColor()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.WithBackgroundColor("#000");

        var expected = styling.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentColoring()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.WithColor("#ff0000");

        var expected = styling.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentCorner()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.AnchorTo(LayerCorner.BottomLeft);

        var expected = styling.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentHorizontalFlip()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.FlipHorizontal();

        var expected = styling.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentRotation()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.Rotate(45);

        var expected = styling.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentScaleFactor()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.Scale(1.5);

        var expected = styling.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentSizing()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.WithSize("200%");

        var expected = styling.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentVerticalFlip()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default.FlipVertical();

        var expected = styling.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnSameHashGivenSameInstance()
    {
        var styling = LayerStyling.Default;

        var expected = styling.GetHashCode();
        var result = styling.GetHashCode();

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ReturnSameHashGivenSameValues()
    {
        var styling = LayerStyling.Default;
        var other = LayerStyling.Default;

        var expected = styling.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreEqual(expected, result);
    }
}