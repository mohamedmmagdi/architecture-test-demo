using ArchTestDemo.ArchitectureTests.Helpers;
using ArchTestDemo.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetArchTest.Rules;
using System.Reflection;

namespace ArchTestDemo.ArchitectureTests.Tests
{
    public class NamingConventionTest
    {
        [Fact]
        public void GenericRepositories_Should_HaveNameEndingWithRepository()
        {
            var dataLayerAssembly = Assembly.LoadFrom("ArchTestDemo.DataLayer.dll");

            var result = Types.InAssembly(dataLayerAssembly)
                .That()
                .ImplementInterface(typeof(IRepository<>))
                .And()
                .AreGeneric()
                .Should()
                .HaveNameEndingWith("Repository`1")
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }

        [Fact]
        public void Repositories_Should_HaveNameEndingWithRepository()
        {
            var dataLayerAssembly = Assembly.LoadFrom("ArchTestDemo.DataLayer.dll");

            var result = Types.InAssembly(dataLayerAssembly)
                .That()
                .ImplementInterface(typeof(IRepository<>))
                .And()
                .AreNotGeneric()
                .Should()
                .HaveNameEndingWith("Repository")
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }


        [Fact]
        public void Controllers_Should_HaveNameEndingWithController()
        {
            var apiLayerAssembly = Assembly.LoadFrom("ArchTestDemo.API.dll");

            var result = Types.InAssembly(apiLayerAssembly)
                .That()
                .Inherit(typeof(ControllerBase))
                .Should()
                .HaveNameEndingWith("Controller")
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }
    }
}
