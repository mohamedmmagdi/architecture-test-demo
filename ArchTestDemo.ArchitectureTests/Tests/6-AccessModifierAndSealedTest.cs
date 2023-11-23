using ArchTestDemo.ArchitectureTests.Helpers;
using NetArchTest.Rules;
using System.Reflection;

namespace ArchTestDemo.ArchitectureTests.Tests
{
    public class AccessModifierAndSealedTest
    {
        [Fact]
        public void Repository_Should_BePublic()
        {
            var assembly = Assembly.LoadFrom("ArchTestDemo.DataLayer.dll");

            var result = Types.InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Repository")
                .And()
                .AreClasses()
                .Should()
                .BePublic()
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }

        [Fact]
        public void Repository_Should_BeSealed()
        {
            var assembly = Assembly.LoadFrom("ArchTestDemo.DataLayer.dll");

            var result = Types.InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Repository")
                .And()
                .AreClasses()
                .Should()
                .BeSealed()
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }
    }
}
