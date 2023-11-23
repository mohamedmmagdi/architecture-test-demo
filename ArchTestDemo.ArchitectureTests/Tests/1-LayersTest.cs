using ArchTestDemo.API;
using ArchTestDemo.ArchitectureTests.Helpers;
using NetArchTest.Rules;
using System.Reflection;

namespace ArchTestDemo.ArchitectureTests.Tests
{
    public class LayersTest
    {
        [Fact]
        public void BusinessLayer_ShouldNot_DependOnAPILayer()
        {
            var businessAssembly = Assembly.LoadFrom("ArchTestDemo.BusinessLayer.dll");

            var result = Types.InAssembly(businessAssembly)
                .ShouldNot()
                .HaveDependencyOn("ArchTestDemo.API")
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }

        [Fact]
        public void DataLayer_ShouldNot_DependOnBusinessNorAPILayer()
        {
            var dataAssembly = Assembly.LoadFrom("ArchTestDemo.DataLayer.dll");

            var result = Types.InAssembly(dataAssembly)
                .ShouldNot()
                .HaveDependencyOnAll("ArchTestDemo.API", "ArchTestDemo.BusinessLayer")
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }


        [Fact]
        public void APILayer_Should_DependOnDataAndBusinessLayers()
        {
            var apiAssembly = typeof(APIAssemblyReference).Assembly;

            var result = Types.InAssembly(apiAssembly)
                .That()
                .HaveNameEndingWith("Controller")
                .Should()
                .HaveDependencyOnAll("ArchTestDemo.DataLayer", "ArchTestDemo.BusinessLayer")
                .GetResult();

            Assert.True(result.IsSuccessful, result.GetUserMessage());
        }
    }
}