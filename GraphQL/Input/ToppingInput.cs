using System.Collections.Generic;

namespace HotChocolateOptionalIntIssue.GraphQL.Input
{
    public class ToppingInput
    {
        public IEnumerable<PicklesInput>? Pickles { get; set; }
    }
}