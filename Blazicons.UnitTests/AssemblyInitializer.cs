namespace Blazicons.UnitTests;

[TestClass]
public class AssemblyInitializer
{
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext context)
    {
        VerifyBunit.Initialize();
    }
}
