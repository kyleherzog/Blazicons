namespace Blazicons.UnitTests.SvgIconTests;

[TestClass]
public class FlipHorizontalShould
{
    [TestMethod]
    public void SetIsFlippedHorizontalGivenCalledWithFalse()
    {
        var icon = IconFactory.Alert;
        icon.FlipHorizontal();

        icon.FlipHorizontal(false);

        Assert.IsFalse(icon.IsFlippedHorizontal);
    }

    [TestMethod]
    public void SetIsFlippedHorizontalTrueGivenCalledWithNoArgs()
    {
        var icon = IconFactory.Alert;

        icon.FlipHorizontal();

        Assert.IsTrue(icon.IsFlippedHorizontal);
    }
}