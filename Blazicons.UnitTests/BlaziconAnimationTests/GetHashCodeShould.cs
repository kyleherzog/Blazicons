namespace Blazicons.UnitTests.BlaziconAnimationTests;

[TestClass]
public class GetHashCodeShould
{
    [TestMethod]
    public void ReturnDifferentHashGivenDifferentAnimationType()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Spin;

        var expected = animation.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentBeatScale()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat.WithBeatScale(1.5);

        var expected = animation.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentDelay()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat.WithDelay(500);

        var expected = animation.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnDifferentHashGivenDifferentDuration()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat.WithDuration(2000);

        var expected = animation.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreNotEqual(expected, result);
    }

    [TestMethod]
    public void ReturnSameHashGivenSameAnimationType()
    {
        var animation = BlaziconAnimation.Beat;
        var other = BlaziconAnimation.Beat;

        var expected = animation.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ReturnSameHashGivenSameCustomization()
    {
        var animation = BlaziconAnimation.Beat.WithDuration(2000).WithBeatScale(1.5);
        var other = BlaziconAnimation.Beat.WithDuration(2000).WithBeatScale(1.5);

        var expected = animation.GetHashCode();
        var result = other.GetHashCode();

        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void ReturnSameHashGivenSameInstance()
    {
        var animation = BlaziconAnimation.Spin;

        var expected = animation.GetHashCode();
        var result = animation.GetHashCode();

        Assert.AreEqual(expected, result);
    }
}