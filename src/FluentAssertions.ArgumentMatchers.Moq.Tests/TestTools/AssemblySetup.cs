using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FluentAssertions.ArgumentMatchers.Moq.Tests.TestTools
{
    [TestClass]
    public class AssemblySetup
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // Print the FluentAssertions.ArgumentMatchers.FakeItEasy, FakeItEasy and FluentAssertions assembly version
            // so we can check which versions are used during the tests.
            // The 'tests' folder in the repository contains unit tests that reuse the tests of this project
            // and execute tests with different version of FakeItEasy and FluentAssertions
            PrintAssemblyVersion(typeof(Its).Assembly);
            PrintAssemblyVersion(typeof(Mock).Assembly);
            PrintAssemblyVersion(typeof(TypeExtensions).Assembly);
        }

        private static void PrintAssemblyVersion(Assembly assembly)
        {
            var assemblyName = assembly.GetName();
            var assemblyFileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            Trace.WriteLine($"{assemblyName.Name} - {assemblyName.Version} - {assemblyFileVersionInfo.FileVersion} - {assemblyFileVersionInfo.ProductVersion}");
        }
    }
}
