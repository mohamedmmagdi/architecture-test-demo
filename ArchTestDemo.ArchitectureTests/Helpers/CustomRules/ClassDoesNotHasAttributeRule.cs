using Mono.Cecil;
using NetArchTest.Rules;

namespace ArchTestDemo.ArchitectureTests.Helpers.CustomRules;

public class ClassDoesNotHasAttributeRule : ICustomRule
{
    private readonly string _attributeName;

    public ClassDoesNotHasAttributeRule(string attributeName)
    {
        _attributeName = attributeName;
    }

    public bool MeetsRule(TypeDefinition type)
    {
        return type.CustomAttributes.All(a => a.AttributeType.Name != _attributeName);
    }
}