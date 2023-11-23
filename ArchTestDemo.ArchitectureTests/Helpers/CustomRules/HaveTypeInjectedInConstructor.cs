using Mono.Cecil;
using NetArchTest.Rules;

namespace ArchTestDemo.ArchitectureTests.Helpers.CustomRules;

public class HaveTypeInjectedInConstructor : ICustomRule
{
    private readonly Type _type;
    public HaveTypeInjectedInConstructor(Type type)
    {
        _type = type;
    }
    public bool MeetsRule(TypeDefinition type)
    {
        return type.Methods.Any(m =>
            m.IsConstructor &&
            m.Parameters.Any(p => p.ParameterType.FullName == _type.FullName));
    }
}