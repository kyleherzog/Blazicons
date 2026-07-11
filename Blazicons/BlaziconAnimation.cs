using System.Collections.ObjectModel;
using System.Globalization;

namespace Blazicons;

/// <summary>
/// Represents an animation to be applied to a Blazicon, including its type and customization options.
/// </summary>
public class BlaziconAnimation : IEquatable<BlaziconAnimation>
{
    private readonly string attributeSuffix;

    private BlaziconAnimation(string attributeSuffix)
    {
        this.attributeSuffix = attributeSuffix;
    }

    /// <summary>
    /// Gets a new <see cref="BlaziconAnimation"/> instance configured for the beat animation.
    /// </summary>
    public static BlaziconAnimation Beat => new("beat");

    /// <summary>
    /// Gets a new <see cref="BlaziconAnimation"/> instance configured for the beat-fade animation.
    /// </summary>
    public static BlaziconAnimation BeatFade => new("beat-fade");

    /// <summary>
    /// Gets a new <see cref="BlaziconAnimation"/> instance configured for the bounce animation.
    /// </summary>
    public static BlaziconAnimation Bounce => new("bounce");

    /// <summary>
    /// Gets a new <see cref="BlaziconAnimation"/> instance configured for the fade animation.
    /// </summary>
    public static BlaziconAnimation Fade => new("fade");

    /// <summary>
    /// Gets a new <see cref="BlaziconAnimation"/> instance configured for the flip animation.
    /// </summary>
    public static BlaziconAnimation Flip => new("flip");

    /// <summary>
    /// Gets a new <see cref="BlaziconAnimation"/> instance configured for the shake animation.
    /// </summary>
    public static BlaziconAnimation Shake => new("shake");

    /// <summary>
    /// Gets a new <see cref="BlaziconAnimation"/> instance configured for the spin animation.
    /// </summary>
    public static BlaziconAnimation Spin => new("spin");

    /// <summary>
    /// Gets a new <see cref="BlaziconAnimation"/> instance configured for the spin-pulse animation.
    /// </summary>
    public static BlaziconAnimation SpinPulse => new("spin-pulse");

    /// <summary>
    /// Gets a new <see cref="BlaziconAnimation"/> instance configured for the spin-reverse animation.
    /// </summary>
    public static BlaziconAnimation SpinReverse => new("spin-reverse");

    /// <summary>
    /// Gets the scale factor applied at the peak of the beat animation.
    /// </summary>
    public double? BeatScale { get; private set; }

    /// <summary>
    /// Gets the opacity applied at the peak of the beat-fade animation.
    /// </summary>
    public double? BeatFadeOpacity { get; private set; }

    /// <summary>
    /// Gets the scale factor applied at the peak of the beat-fade animation.
    /// </summary>
    public double? BeatFadeScale { get; private set; }

    /// <summary>
    /// Gets the height of the jump arc in the bounce animation, in em units.
    /// </summary>
    public double? BounceHeight { get; private set; }

    /// <summary>
    /// Gets the X scale factor applied at the jump apex of the bounce animation.
    /// </summary>
    public double? BounceJumpScaleX { get; private set; }

    /// <summary>
    /// Gets the Y scale factor applied at the jump apex of the bounce animation.
    /// </summary>
    public double? BounceJumpScaleY { get; private set; }

    /// <summary>
    /// Gets the X scale factor applied at landing in the bounce animation.
    /// </summary>
    public double? BounceLandScaleX { get; private set; }

    /// <summary>
    /// Gets the Y scale factor applied at landing in the bounce animation.
    /// </summary>
    public double? BounceLandScaleY { get; private set; }

    /// <summary>
    /// Gets the rebound height of the bounce animation, in em units.
    /// </summary>
    public double? BounceRebound { get; private set; }

    /// <summary>
    /// Gets the X scale factor applied at the start of the bounce animation.
    /// </summary>
    public double? BounceStartScaleX { get; private set; }

    /// <summary>
    /// Gets the Y scale factor applied at the start of the bounce animation.
    /// </summary>
    public double? BounceStartScaleY { get; private set; }

    /// <summary>
    /// Gets the delay before the animation starts, in milliseconds.
    /// </summary>
    public double? Delay { get; private set; }

    /// <summary>
    /// Gets the direction in which the animation plays.
    /// </summary>
    public BlaziconAnimationDirection? Direction { get; private set; }

    /// <summary>
    /// Gets the duration of the animation, in milliseconds.
    /// </summary>
    public double? Duration { get; private set; }

    /// <summary>
    /// Gets the minimum opacity of the fade animation.
    /// </summary>
    public double? FadeOpacity { get; private set; }

    /// <summary>
    /// Gets the angle of the flip animation, in degrees.
    /// </summary>
    public double? FlipAngle { get; private set; }

    /// <summary>
    /// Gets the X component of the flip animation axis vector.
    /// </summary>
    public double? FlipX { get; private set; }

    /// <summary>
    /// Gets the Y component of the flip animation axis vector.
    /// </summary>
    public double? FlipY { get; private set; }

    /// <summary>
    /// Gets the Z component of the flip animation axis vector.
    /// </summary>
    public double? FlipZ { get; private set; }

    /// <summary>
    /// Gets the number of times the animation repeats, or <c>"infinite"</c> for continuous looping.
    /// </summary>
    public string? IterationCount { get; private set; }

    /// <summary>
    /// Gets the CSS timing function used by the animation.
    /// </summary>
    public string? TimingFunction { get; private set; }

    /// <summary>
    /// Gets the HTML attribute name used to identify this animation on the SVG element.
    /// </summary>
    internal string AttributeName => $"blazicon-{attributeSuffix}";

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is BlaziconAnimation other)
        {
            return Equals(other);
        }

        return false;
    }

    /// <inheritdoc/>
    public bool Equals(BlaziconAnimation? other)
    {
        return other is not null
            && attributeSuffix == other.attributeSuffix
            && BeatScale == other.BeatScale
            && BeatFadeOpacity == other.BeatFadeOpacity
            && BeatFadeScale == other.BeatFadeScale
            && BounceHeight == other.BounceHeight
            && BounceJumpScaleX == other.BounceJumpScaleX
            && BounceJumpScaleY == other.BounceJumpScaleY
            && BounceLandScaleX == other.BounceLandScaleX
            && BounceLandScaleY == other.BounceLandScaleY
            && BounceRebound == other.BounceRebound
            && BounceStartScaleX == other.BounceStartScaleX
            && BounceStartScaleY == other.BounceStartScaleY
            && Delay == other.Delay
            && Direction == other.Direction
            && Duration == other.Duration
            && FadeOpacity == other.FadeOpacity
            && FlipAngle == other.FlipAngle
            && FlipX == other.FlipX
            && FlipY == other.FlipY
            && FlipZ == other.FlipZ
            && IterationCount == other.IterationCount
            && TimingFunction == other.TimingFunction;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(attributeSuffix);
        hash.Add(BeatScale);
        hash.Add(BeatFadeOpacity);
        hash.Add(BeatFadeScale);
        hash.Add(BounceHeight);
        hash.Add(BounceJumpScaleX);
        hash.Add(BounceJumpScaleY);
        hash.Add(BounceLandScaleX);
        hash.Add(BounceLandScaleY);
        hash.Add(BounceRebound);
        hash.Add(BounceStartScaleX);
        hash.Add(BounceStartScaleY);
        hash.Add(Delay);
        hash.Add(Direction);
        hash.Add(Duration);
        hash.Add(FadeOpacity);
        hash.Add(FlipAngle);
        hash.Add(FlipX);
        hash.Add(FlipY);
        hash.Add(FlipZ);
        hash.Add(IterationCount);
        hash.Add(TimingFunction);
        return hash.ToHashCode();
    }

    /// <summary>
    /// Returns a read-only dictionary of CSS custom property names and values representing only the explicitly set customization options.
    /// </summary>
    /// <returns>A dictionary of CSS custom property entries to be applied as inline styles.</returns>
    public IReadOnlyDictionary<string, string> ToCssCustomProperties()
    {
        var result = new Dictionary<string, string>();

        if (Duration.HasValue)
        {
            result["--blazicon-animation-duration"] = $"{Duration.Value.ToString(CultureInfo.InvariantCulture)}ms";
        }

        if (Delay.HasValue)
        {
            result["--blazicon-animation-delay"] = $"{Delay.Value.ToString(CultureInfo.InvariantCulture)}ms";
        }

        if (Direction.HasValue)
        {
            result["--blazicon-animation-direction"] = Direction.Value.ToCssValue();
        }

        if (IterationCount is not null)
        {
            result["--blazicon-animation-iteration-count"] = IterationCount;
        }

        if (TimingFunction is not null)
        {
            result["--blazicon-animation-timing"] = TimingFunction;
        }

        if (BeatScale.HasValue)
        {
            result["--blazicon-beat-scale"] = BeatScale.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (FadeOpacity.HasValue)
        {
            result["--blazicon-fade-opacity"] = FadeOpacity.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (BeatFadeOpacity.HasValue)
        {
            result["--blazicon-beat-fade-opacity"] = BeatFadeOpacity.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (BeatFadeScale.HasValue)
        {
            result["--blazicon-beat-fade-scale"] = BeatFadeScale.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (BounceRebound.HasValue)
        {
            result["--blazicon-bounce-rebound"] = $"{BounceRebound.Value.ToString(CultureInfo.InvariantCulture)}em";
        }

        if (BounceHeight.HasValue)
        {
            result["--blazicon-bounce-height"] = $"{BounceHeight.Value.ToString(CultureInfo.InvariantCulture)}em";
        }

        if (BounceStartScaleX.HasValue)
        {
            result["--blazicon-bounce-start-scale-x"] = BounceStartScaleX.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (BounceStartScaleY.HasValue)
        {
            result["--blazicon-bounce-start-scale-y"] = BounceStartScaleY.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (BounceJumpScaleX.HasValue)
        {
            result["--blazicon-bounce-jump-scale-x"] = BounceJumpScaleX.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (BounceJumpScaleY.HasValue)
        {
            result["--blazicon-bounce-jump-scale-y"] = BounceJumpScaleY.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (BounceLandScaleX.HasValue)
        {
            result["--blazicon-bounce-land-scale-x"] = BounceLandScaleX.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (BounceLandScaleY.HasValue)
        {
            result["--blazicon-bounce-land-scale-y"] = BounceLandScaleY.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (FlipX.HasValue)
        {
            result["--blazicon-flip-x"] = FlipX.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (FlipY.HasValue)
        {
            result["--blazicon-flip-y"] = FlipY.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (FlipZ.HasValue)
        {
            result["--blazicon-flip-z"] = FlipZ.Value.ToString(CultureInfo.InvariantCulture);
        }

        if (FlipAngle.HasValue)
        {
            result["--blazicon-flip-angle"] = $"{FlipAngle.Value.ToString(CultureInfo.InvariantCulture)}deg";
        }

        return new ReadOnlyDictionary<string, string>(result);
    }

    /// <summary>
    /// Sets the scale factor at the peak of the beat animation.
    /// </summary>
    /// <param name="scale">The scale factor, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBeatScale(double? scale)
    {
        BeatScale = scale;
        return this;
    }

    /// <summary>
    /// Sets the opacity at the peak of the beat-fade animation.
    /// </summary>
    /// <param name="opacity">The opacity value between 0 and 1, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBeatFadeOpacity(double? opacity)
    {
        BeatFadeOpacity = opacity;
        return this;
    }

    /// <summary>
    /// Sets the scale factor at the peak of the beat-fade animation.
    /// </summary>
    /// <param name="scale">The scale factor, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBeatFadeScale(double? scale)
    {
        BeatFadeScale = scale;
        return this;
    }

    /// <summary>
    /// Sets the height of the jump arc in the bounce animation.
    /// </summary>
    /// <param name="em">The height in em units (typically negative, e.g. <c>-0.5</c>), or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBounceHeight(double? em)
    {
        BounceHeight = em;
        return this;
    }

    /// <summary>
    /// Sets the X scale factor at the jump apex of the bounce animation.
    /// </summary>
    /// <param name="scale">The scale factor, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBounceJumpScaleX(double? scale)
    {
        BounceJumpScaleX = scale;
        return this;
    }

    /// <summary>
    /// Sets the Y scale factor at the jump apex of the bounce animation.
    /// </summary>
    /// <param name="scale">The scale factor, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBounceJumpScaleY(double? scale)
    {
        BounceJumpScaleY = scale;
        return this;
    }

    /// <summary>
    /// Sets the X scale factor at landing in the bounce animation.
    /// </summary>
    /// <param name="scale">The scale factor, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBounceLandScaleX(double? scale)
    {
        BounceLandScaleX = scale;
        return this;
    }

    /// <summary>
    /// Sets the Y scale factor at landing in the bounce animation.
    /// </summary>
    /// <param name="scale">The scale factor, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBounceLandScaleY(double? scale)
    {
        BounceLandScaleY = scale;
        return this;
    }

    /// <summary>
    /// Sets the rebound height of the bounce animation.
    /// </summary>
    /// <param name="em">The rebound height in em units (typically negative, e.g. <c>-0.125</c>), or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBounceRebound(double? em)
    {
        BounceRebound = em;
        return this;
    }

    /// <summary>
    /// Sets the X scale factor at the start of the bounce animation.
    /// </summary>
    /// <param name="scale">The scale factor, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBounceStartScaleX(double? scale)
    {
        BounceStartScaleX = scale;
        return this;
    }

    /// <summary>
    /// Sets the Y scale factor at the start of the bounce animation.
    /// </summary>
    /// <param name="scale">The scale factor, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithBounceStartScaleY(double? scale)
    {
        BounceStartScaleY = scale;
        return this;
    }

    /// <summary>
    /// Sets the delay before the animation starts.
    /// </summary>
    /// <param name="milliseconds">The delay in milliseconds, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithDelay(double? milliseconds)
    {
        Delay = milliseconds;
        return this;
    }

    /// <summary>
    /// Sets the delay before the animation starts.
    /// </summary>
    /// <param name="delay">The delay as a <see cref="TimeSpan"/>.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithDelay(TimeSpan delay)
    {
        return WithDelay(delay.TotalMilliseconds);
    }

    /// <summary>
    /// Sets the direction in which the animation plays.
    /// </summary>
    /// <param name="direction">The animation direction, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithDirection(BlaziconAnimationDirection? direction)
    {
        Direction = direction;
        return this;
    }

    /// <summary>
    /// Sets the duration of the animation.
    /// </summary>
    /// <param name="milliseconds">The duration in milliseconds, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithDuration(double? milliseconds)
    {
        Duration = milliseconds;
        return this;
    }

    /// <summary>
    /// Sets the duration of the animation.
    /// </summary>
    /// <param name="duration">The duration as a <see cref="TimeSpan"/>.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithDuration(TimeSpan duration)
    {
        return WithDuration(duration.TotalMilliseconds);
    }

    /// <summary>
    /// Sets the minimum opacity of the fade animation.
    /// </summary>
    /// <param name="opacity">The opacity value between 0 and 1, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithFadeOpacity(double? opacity)
    {
        FadeOpacity = opacity;
        return this;
    }

    /// <summary>
    /// Sets the angle of the flip animation.
    /// </summary>
    /// <param name="degrees">The angle in degrees, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithFlipAngle(double? degrees)
    {
        FlipAngle = degrees;
        return this;
    }

    /// <summary>
    /// Sets the X component of the flip animation axis vector.
    /// </summary>
    /// <param name="x">The X component value, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithFlipX(double? x)
    {
        FlipX = x;
        return this;
    }

    /// <summary>
    /// Sets the Y component of the flip animation axis vector.
    /// </summary>
    /// <param name="y">The Y component value, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithFlipY(double? y)
    {
        FlipY = y;
        return this;
    }

    /// <summary>
    /// Sets the Z component of the flip animation axis vector.
    /// </summary>
    /// <param name="z">The Z component value, or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithFlipZ(double? z)
    {
        FlipZ = z;
        return this;
    }

    /// <summary>
    /// Sets the number of times the animation repeats.
    /// </summary>
    /// <param name="count">The iteration count (e.g. <c>"3"</c> or <c>"infinite"</c>), or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithIterationCount(string? count)
    {
        IterationCount = count;
        return this;
    }

    /// <summary>
    /// Sets the CSS timing function used by the animation.
    /// </summary>
    /// <param name="timing">The CSS timing function value (e.g. <c>"ease-in-out"</c>, <c>"linear"</c>), or <c>null</c> to use the default.</param>
    /// <returns>The current <see cref="BlaziconAnimation"/> instance.</returns>
    public BlaziconAnimation WithTimingFunction(string? timing)
    {
        TimingFunction = timing;
        return this;
    }
}