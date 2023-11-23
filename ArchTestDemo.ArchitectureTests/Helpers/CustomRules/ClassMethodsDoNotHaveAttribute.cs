using Mono.Cecil;
using NetArchTest.Rules;

namespace ArchTestDemo.ArchitectureTests.Helpers.CustomRules;

public class ClassMethodsDoNotHaveAttribute : ICustomRule
{
    private readonly string _attributeName;

    public ClassMethodsDoNotHaveAttribute(string attributeName)
    {
        _attributeName = attributeName;
    }
    public bool MeetsRule(TypeDefinition type)
    {
        return type.Methods.All(m =>
        {
            if (m.CustomAttributes.All(a => a.AttributeType.Name != _attributeName))
            {
                return true;
            }

            return false;
        });
    }
}