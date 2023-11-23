using ArchTestDemo.API;
using ArchTestDemo.ArchitectureTests.Helpers;
using ArchTestDemo.ArchitectureTests.Helpers.CustomRules;
using ArchTestDemo.DataLayer;
using NetArchTest.Rules;
using System.Reflection;

namespace ArchTestDemo.ArchitectureTests.Tests
{
    public class ClassesDependencyInjection
    {
        [Fact]
        public void Repository_Should_HaveDbContextInjected()
        {
            var assembly = Assembly.LoadFrom("ArchTestDemo.DataLayer.dll");

            var result = Types.InAssembly(assembly)
                .That()
                .HaveNameEndingWith("Repository")
                .And()
                .AreClasses()
                .Should()
                .MeetCustomRule(new HaveTypeInjectedInConstructor(typeof(ApplicationDbContext)))
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }
    }
}
