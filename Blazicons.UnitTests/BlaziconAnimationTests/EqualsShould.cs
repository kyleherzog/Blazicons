namespace Blazicons.UnitTests.BlaziconAnimationTests;

[TestClass]
public class EqualsShould
{
    [TestMethod]
    public void ReturnFalseGivenDifferentAnimationType()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Spin;

        var result = animation.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenDifferentBeatScale()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat.WithBeatScale(1.5);

        var result = animation.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenDifferentDelay()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat.WithDelay(500);

        var result = animation.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenDifferentDirection()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat.WithDirection(BlaziconAnimationDirection.Reverse);

        var result = animation.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenDifferentDuration()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat.WithDuration(2000);

        var result = animation.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenDifferentFadeOpacity()
    {
        var animation = BlaziconAnimation.Fade;
        var other = BlaziconAnimation.Fade.WithFadeOpacity(0.2);

        var result = animation.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenDifferentFlipAngle()
    {
        var animation = BlaziconAnimation.Flip;
        var other = BlaziconAnimation.Flip.WithFlipAngle(90);

        var result = animation.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenDifferentIterationCount()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat.WithIterationCount("3");

        var result = animation.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenDifferentTimingFunction()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat.WithTimingFunction("linear");

        var result = animation.Equals(other);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenNull()
    {
        var animation = BlaziconAnimation.Beat;

        var result = animation.Equals(null);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnFalseGivenOtherType()
    {
        var animation = BlaziconAnimation.Beat;

        var result = animation.Equals(new object());

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ReturnTrueGivenSameAnimationType()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat;

        var result = animation.Equals(other);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ReturnTrueGivenSameCustomization()
    {
        var animation = BlaziconAnimation.Beat.WithDuration(2000).WithBeatScale(1.5);
        var other = BlaziconAnimation.Beat.WithDuration(2000).WithBeatScale(1.5);

        var result = animation.Equals(other);

        Assert.IsTrue(result);
    }
}