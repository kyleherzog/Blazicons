namespace Blazicons.UnitTests.BlaziconAnimationTests;

[TestClass]
public class ToCssCustomPropertiesShould
{
    [TestMethod]
    public void ReturnBeatFadeOpacityGivenBeatFadeOpacitySet()
    {
        var animation = BlaziconAnimation.BeatFade.WithBeatFadeOpacity(0.3);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("0.3", result["--blazicon-beat-fade-opacity"]);
    }

    [TestMethod]
    public void ReturnBeatFadeScaleGivenBeatFadeScaleSet()
    {
        var animation = BlaziconAnimation.BeatFade.WithBeatFadeScale(0.8);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("0.8", result["--blazicon-beat-fade-scale"]);
    }

    [TestMethod]
    public void ReturnBeatScaleGivenBeatScaleSet()
    {
        var animation = BlaziconAnimation.Beat.WithBeatScale(1.5);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("1.5", result["--blazicon-beat-scale"]);
    }

    [TestMethod]
    public void ReturnBounceHeightWithEmUnitsGivenBounceHeightSet()
    {
        var animation = BlaziconAnimation.Bounce.WithBounceHeight(-0.5);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("-0.5em", result["--blazicon-bounce-height"]);
    }

    [TestMethod]
    public void ReturnBounceReboundWithEmUnitsGivenBounceReboundSet()
    {
        var animation = BlaziconAnimation.Bounce.WithBounceRebound(-0.125);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("-0.125em", result["--blazicon-bounce-rebound"]);
    }

    [TestMethod]
    public void ReturnDelayInMillisecondsGivenDelaySet()
    {
        var animation = BlaziconAnimation.Beat.WithDelay(250);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("250ms", result["--blazicon-animation-delay"]);
    }

    [TestMethod]
    public void ReturnDelayInMillisecondsGivenDelaySetAsTimeSpan()
    {
        var animation = BlaziconAnimation.Beat.WithDelay(TimeSpan.FromMilliseconds(500));

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("500ms", result["--blazicon-animation-delay"]);
    }

    [TestMethod]
    public void ReturnDirectionAlternateGivenDirectionSetToAlternate()
    {
        var animation = BlaziconAnimation.Beat.WithDirection(BlaziconAnimationDirection.Alternate);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("alternate", result["--blazicon-animation-direction"]);
    }

    [TestMethod]
    public void ReturnDirectionAlternateReverseGivenDirectionSetToAlternateReverse()
    {
        var animation = BlaziconAnimation.Beat.WithDirection(BlaziconAnimationDirection.AlternateReverse);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("alternate-reverse", result["--blazicon-animation-direction"]);
    }

    [TestMethod]
    public void ReturnDirectionGivenDirectionSet()
    {
        var animation = BlaziconAnimation.Beat.WithDirection(BlaziconAnimationDirection.Reverse);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("reverse", result["--blazicon-animation-direction"]);
    }

    [TestMethod]
    public void ReturnDurationInMillisecondsGivenDurationSet()
    {
        var animation = BlaziconAnimation.Beat.WithDuration(1500);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("1500ms", result["--blazicon-animation-duration"]);
    }

    [TestMethod]
    public void ReturnDurationInMillisecondsGivenDurationSetAsTimeSpan()
    {
        var animation = BlaziconAnimation.Beat.WithDuration(TimeSpan.FromSeconds(2));

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("2000ms", result["--blazicon-animation-duration"]);
    }

    [TestMethod]
    public void ReturnEmptyGivenNoCustomization()
    {
        var animation = BlaziconAnimation.Beat;

        var result = animation.ToCssCustomProperties();

        Assert.IsEmpty(result);
    }

    [TestMethod]
    public void ReturnFadeOpacityGivenFadeOpacitySet()
    {
        var animation = BlaziconAnimation.Fade.WithFadeOpacity(0.2);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("0.2", result["--blazicon-fade-opacity"]);
    }

    [TestMethod]
    public void ReturnFlipAngleWithDegUnitsGivenFlipAngleSet()
    {
        var animation = BlaziconAnimation.Flip.WithFlipAngle(90);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("90deg", result["--blazicon-flip-angle"]);
    }

    [TestMethod]
    public void ReturnFlipXGivenFlipXSet()
    {
        var animation = BlaziconAnimation.Flip.WithFlipX(1);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("1", result["--blazicon-flip-x"]);
    }

    [TestMethod]
    public void ReturnFlipYGivenFlipYSet()
    {
        var animation = BlaziconAnimation.Flip.WithFlipY(0);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("0", result["--blazicon-flip-y"]);
    }

    [TestMethod]
    public void ReturnFlipZGivenFlipZSet()
    {
        var animation = BlaziconAnimation.Flip.WithFlipZ(1);

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("1", result["--blazicon-flip-z"]);
    }

    [TestMethod]
    public void ReturnIterationCountGivenIterationCountSet()
    {
        var animation = BlaziconAnimation.Beat.WithIterationCount("3");

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("3", result["--blazicon-animation-iteration-count"]);
    }

    [TestMethod]
    public void ReturnOnlySetPropertiesGivenPartialCustomization()
    {
        var animation = BlaziconAnimation.Beat.WithDuration(2000);

        var result = animation.ToCssCustomProperties();

        Assert.HasCount(1, result);
        Assert.IsTrue(result.ContainsKey("--blazicon-animation-duration"));
    }

    [TestMethod]
    public void ReturnTimingFunctionGivenTimingFunctionSet()
    {
        var animation = BlaziconAnimation.Beat.WithTimingFunction("linear");

        var result = animation.ToCssCustomProperties();

        Assert.AreEqual("linear", result["--blazicon-animation-timing"]);
    }
}