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

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentScaleFactor()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.Scale(1.5);

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentRotation()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.Rotate(45);

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentOffsetX()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.PushRight(2);

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentOffsetY()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.PushDown(2);

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentHorizontalFlip()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.FlipHorizontal();

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentVerticalFlip()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.FlipVertical();

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherIconWithDifferentAnimation()
    {
        var icon = IconFactory.Alert;
        var other = IconFactory.Alert.Animate(BlaziconAnimation.Spin);

        var result = icon.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnTrueGivenOtherIconWithSameAnimation()
    {
        var icon = IconFactory.Alert.Animate(BlaziconAnimation.Beat);
        var other = IconFactory.Alert.Animate(BlaziconAnimation.Beat);

        var result = icon.Equals(other);

        Assert.IsTrue(result);
    }
}
