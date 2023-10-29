namespace Blazicons.UnitTests.SvgIconTests;

[TestClass]
public class GetHashCodeShould
{
    [TestMethod]
    public void ReturnDifferentHashGivenDifferentColoring()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.WithColor("#ff00ff");

        var expected = icon.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentContent()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.AlertOutline;

        var expected = icon.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentSizing()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.WithSize("200%");

        var expected = icon.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnSameHashGivenSameContent()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert;

        var expected = icon.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ReturnSameHashGivenSameInstance()
    {
        var icon = IconFactory.Alert;

        var expected = icon.GetHashCode();
        var result = icon.GetHashCode();

        Assert.AreEqual(expected, result);
    }
}