using ArchTestDemo.ArchitectureTests.Helpers;
using ArchTestDemo.ArchitectureTests.Helpers.CustomRules;
using Microsoft.AspNetCore.Authorization;
using NetArchTest.Rules;
using System.Reflection;

namespace ArchTestDemo.ArchitectureTests.Tests;

public class AttributesTest
{
    private const string _allowAnonymousAttribute = nameof(AllowAnonymousAttribute);

    [Theory]
    [InlineData("ArchTestDemo.API")]
    public void ControllersMethods_ShouldNot_HaveAllowAnonymousAttribute(string assemblyName)
    {
        //Arrange
        var assembly = Assembly.Load(assemblyName);

        //Act	
        var result = Types.InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .MeetCustomRule(new ClassMethodsDoNotHaveAttribute(_allowAnonymousAttribute))
            .GetResult();

        //Assert
        Assert.True(result.IsSuccessful);
    }

    [Theory]
    [InlineData("ArchTestDemo.API")]
    public void Controllers_ShouldNot_HaveAllowAnonymousAttribute(string assemblyName)
    {
        //Arrange
        var assembly = Assembly.Load(assemblyName);

        //Act	
        var result = Types.InAssembly(assembly)
        .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .MeetCustomRule(new ClassDoesNotHasAttributeRule(_allowAnonymousAttribute))
            .GetResult();

        //Assert
        Assert.True(result.IsSuccessful, result.GetUserMessage());
    }
}
