namespace Blazicons.UnitTests.SvgIconTests;

[TestClass]
public class ScaleShould
{
    [TestMethod]
    public void SetScaleFactorGivenScaleCalled()
    {
        var icon = IconFactory.Alert;

        icon.Scale(1.5);

        Assert.AreEqual(1.5, icon.ScaleFactor);
    }

    [TestMethod]
    public void SetScaleFactorToGrowthRatioGivenGrowCalled()
    {
        var icon = IconFactory.Alert;

        icon.Grow(2);

        Assert.AreEqual((16 + 2) / 16.0, icon.ScaleFactor);
    }

    [TestMethod]
    public void SetScaleFactorToShrinkRatioGivenShrinkCalled()
    {
        var icon = IconFactory.Alert;

        icon.Shrink(2);

        Assert.AreEqual((16 - 2) / 16.0, icon.ScaleFactor);
    }
}