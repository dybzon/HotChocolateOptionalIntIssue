using HotChocolate;

namespace HotChocolateOptionalIntIssue.GraphQL.Input
{
    public class ButterPickleInput
    {
        public Optional<int> Size { get; set; }
    }
}