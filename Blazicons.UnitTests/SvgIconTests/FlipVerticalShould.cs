namespace Blazicons.UnitTests.SvgIconTests;

[TestClass]
public class FlipVerticalShould
{
    [TestMethod]
    public void SetIsFlippedVerticalTrueGivenCalledWithNoArgs()
    {
        var icon = IconFactory.Alert;

        icon.FlipVertical();

        Assert.IsTrue(icon.IsFlippedVertical);
    }

    [TestMethod]
    public void SetIsFlippedVerticalGivenCalledWithFalse()
    {
        var icon = IconFactory.Alert;
        icon.FlipVertical();

        icon.FlipVertical(false);

        Assert.IsFalse(icon.IsFlippedVertical);
    }
}
