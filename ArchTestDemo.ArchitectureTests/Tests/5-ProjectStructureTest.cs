using ArchTestDemo.ArchitectureTests.Helpers;
using ArchTestDemo.DataLayer.Repository.Interfaces;
using NetArchTest.Rules;
using System.Reflection;

namespace ArchTestDemo.ArchitectureTests.Tests
{
    public class ProjectStructureTest
    {
        [Fact]
        public void Repositories_Should_ResideInRepositoryNameSpace()
        {
            var dataLayerAssembly = Assembly.LoadFrom("ArchTestDemo.DataLayer.dll");

            var result = Types.InAssembly(dataLayerAssembly)
                .That()
                .ImplementInterface(typeof(IRepository<>))
                .And()
                .AreClasses()
                .Should()
                .ResideInNamespace("ArchTestDemo.DataLayer.Repository.Implementation")
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }

        [Fact]
        public void IRepositories_Should_ResideInRepositoryNameSpace()
        {
            var dataLayerAssembly = Assembly.LoadFrom("ArchTestDemo.DataLayer.dll");

            var result = Types.InAssembly(dataLayerAssembly)
                .That()
                .HaveNameEndingWith("Repository")
                .And()
                .AreInterfaces()
                .Should()
                .ResideInNamespace("ArchTestDemo.DataLayer.Repository.Interfaces")
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }
    }
}
