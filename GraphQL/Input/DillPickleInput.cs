using HotChocolate;

namespace HotChocolateOptionalIntIssue.GraphQL.Input
{
    public class DillPickleInput
    {
        public Optional<int> Weight { get; set; }
    }
}