using System.Runtime.CompilerServices;
using VerifyTests.Blazor;

namespace Blazicons.UnitTests;

[TestClass]
public static class AssemblyInitializer
{
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext context)
    {
        VerifyBunit.Initialize();
        RuntimeHelpers.RunClassConstructor(typeof(Render).TypeHandle);
    }
}
