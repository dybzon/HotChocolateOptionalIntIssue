using System.Linq;
using HotChocolateOptionalIntIssue.GraphQL.Input;

namespace HotChocolateOptionalIntIssue.GraphQL
{
    public class Mutation
    {
        public IceCream Eat(ToppingInput topping)
        {
            return new IceCream
            {
                Topping = new Topping
                {
                    Pickles = topping.Pickles.Select(p => new Pickle()).ToList(),
                }
            };
        }
    }
}