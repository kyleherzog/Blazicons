namespace Blazicons.UnitTests.SvgIconTests;

[TestClass]
public class OffsetShould
{
    [TestMethod]
    public void SetOffsetGivenOffsetCalled()
    {
        var icon = IconFactory.Alert;

        icon.Offset(1.5, 2.5);

        Assert.AreEqual(1.5, icon.OffsetX);
        Assert.AreEqual(2.5, icon.OffsetY);
    }

    [TestMethod]
    public void IncrementOffsetXGivenPushRightCalled()
    {
        var icon = IconFactory.Alert;

        icon.PushRight(2);

        Assert.AreEqual(2 / 16.0, icon.OffsetX);
    }

    [TestMethod]
    public void DecrementOffsetXGivenPushLeftCalled()
    {
        var icon = IconFactory.Alert;

        icon.PushLeft(2);

        Assert.AreEqual(-2 / 16.0, icon.OffsetX);
    }

    [TestMethod]
    public void IncrementOffsetYGivenPushDownCalled()
    {
        var icon = IconFactory.Alert;

        icon.PushDown(2);

        Assert.AreEqual(2 / 16.0, icon.OffsetY);
    }

    [TestMethod]
    public void DecrementOffsetYGivenPushUpCalled()
    {
        var icon = IconFactory.Alert;

        icon.PushUp(2);

        Assert.AreEqual(-2 / 16.0, icon.OffsetY);
    }

    [TestMethod]
    public void AccumulateOffsetXGivenMultiplePushRightCalls()
    {
        var icon = IconFactory.Alert;

        icon.PushRight(2).PushRight(1);

        Assert.AreEqual(3 / 16.0, icon.OffsetX);
    }
}
