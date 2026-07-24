namespace Blazicons.UnitTests.SvgIconTests;

[TestClass]
public class RotateShould
{
    [TestMethod]
    public void SetRotationGivenRotateCalled()
    {
        var icon = IconFactory.Alert;

        icon.Rotate(45);

        Assert.AreEqual(45, icon.Rotation);
    }
}