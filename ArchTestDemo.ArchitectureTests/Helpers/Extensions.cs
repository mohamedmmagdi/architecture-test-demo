using NetArchTest.Rules;

namespace ArchTestDemo.ArchitectureTests.Helpers
{
    public static class Extensions
    {
        public static string GetUserMessage(this TestResult result)
        {
            if (result is null || result.FailingTypeNames == null || !result.FailingTypeNames.Any())
                return string.Empty;

            return $"failed for types: {string.Join(",", result.FailingTypeNames)}";
        }
    }
}
