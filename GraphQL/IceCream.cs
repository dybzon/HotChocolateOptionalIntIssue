namespace HotChocolateOptionalIntIssue.GraphQL
{
    public class IceCream
    {
        public Topping Topping { get; set; } = default!;

        public string Flavor { get; set; } = "chili strawberry";

        public string Description => $"A {this.Flavor} ice cream with {(this.Topping.Pickles.Count == 1 ? "a tasty pickle" : $"{this.Topping.Pickles.Count} tasty pickles")}";
    }
}