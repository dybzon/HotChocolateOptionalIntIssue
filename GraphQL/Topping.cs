using System.Collections.Generic;

namespace HotChocolateOptionalIntIssue.GraphQL
{
    public class Topping
    {
        public ICollection<Pickle> Pickles { get; set; } = new List<Pickle>();
    }
}