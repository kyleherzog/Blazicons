namespace Blazicons.UnitTests.SvgIconTests;

[TestClass]
public class EqualsShould
{
    [TestMethod]
    public void ReturnFalseGivenNull()
    {
        var icon = IconFactory.Alert;

        var result = icon.Equals(null);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentColoring()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.WithColor("#ff00ff");

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentContent()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.AlertOutline;

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentSizing()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.WithSize("200%");

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherType()
    {
        var icon = IconFactory.Alert;

        var result = icon.Equals(new object());

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnTrueGivenOtherIconWithSameContent()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert;

        var result = icon.Equals(other);

        Assert.IsTrue(result);
    }
}