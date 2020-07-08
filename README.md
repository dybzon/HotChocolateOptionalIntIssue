# To reproduce the issue:
1. Clone this repo and start the graphql server
2. Open the playground (https://localhost:5001/playground/)
3. Execute this mutation:
```
mutation eatChiliStrawberryIcecream {
  eat(topping: { pickles: { dillPickle: { weight: 5 } } }) {
    description
  }
}
```

This returns the expected result:
```
{
  "data": {
    "eat": {
      "description": "A chili strawberry ice cream with a tasty pickle"
    }
  }
}
```

4. Execute the same mutation with the last part of the input parameterized:
```
mutation eatChiliStrawberryIcecream($input: DillPickleInput) {
  eat(topping: { pickles: { dillPickle: $input } }) {
    description
  }
}
```

with these query variables:
```
{ "input": { "weight": 5 } }
```

This returns an error:
```
{
  "errors": [
    {
      "message": "Unexpected Execution Error",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
      "path": [
        "eat"
      ],
      "extensions": {
        "message": "Unable to convert type from `Optional`1` to `Int32`",
        "stackTrace": "   at HotChocolate.Utilities.TypeConversion.Convert(Type from, Type to, Object source)\r\n   at HotChocolate.Utilities.InputObjectToObjectValueConverter.VisitLeaf(INamedInputType type, Object obj, Action`1 setValue, ISet`1 processed)\r\n   at HotChocolate.Utilities.InputObjectToObjectValueConverter.VisitValue(IInputType type, Object obj, Action`1 setValue, ISet`1 processed)\r\n   at HotChocolate.Utilities.InputObjectToObjectValueConverter.VisitInputObject(InputObjectType type, Object obj, Action`1 setValue, ISet`1 processed)\r\n   at HotChocolate.Utilities.InputObjectToObjectValueConverter.Convert(InputObjectType type, Object obj)\r\n   at HotChocolate.Types.InputObjectType.ParseValue(Object value)\r\n   at HotChocolate.Execution.VariableToValueRewriter.ReplaceVariable(VariableNode variable, IInputType type)\r\n   at HotChocolate.Execution.VariableToValueRewriter.RewriteObjectField(ObjectFieldNode node, Object context)\r\n   at HotChocolate.Language.SyntaxRewriter`1.RewriteMany[T](IReadOnlyList`1 items, TContext context, Func`3 func)\r\n   at HotChocolate.Language.SyntaxRewriter`1.<>c__DisplayClass20_0`2.<RewriteMany>b__0(IReadOnlyList`1 p, TContext c)\r\n   at HotChocolate.Language.SyntaxRewriter`1.Rewrite[TParent,TProperty](TParent parent, TProperty property, TContext context, Func`3 visit, Func`2 rewrite)\r\n   at HotChocolate.Language.SyntaxRewriter`1.RewriteMany[TParent,TProperty](TParent parent, IReadOnlyList`1 property, TContext context, Func`3 visit, Func`2 rewrite)\r\n   at HotChocolate.Language.SyntaxRewriter`1.RewriteObjectValue(ObjectValueNode node, TContext context)\r\n   at HotChocolate.Execution.VariableToValueRewriter.RewriteObjectValue(ObjectValueNode node, Object context)\r\n   at HotChocolate.Execution.VariableToValueRewriter.RewriteObjectField(ObjectFieldNode node, Object context)\r\n   at HotChocolate.Language.SyntaxRewriter`1.RewriteMany[T](IReadOnlyList`1 items, TContext context, Func`3 func)\r\n   at HotChocolate.Language.SyntaxRewriter`1.<>c__DisplayClass20_0`2.<RewriteMany>b__0(IReadOnlyList`1 p, TContext c)\r\n   at HotChocolate.Language.SyntaxRewriter`1.Rewrite[TParent,TProperty](TParent parent, TProperty property, TContext context, Func`3 visit, Func`2 rewrite)\r\n   at HotChocolate.Language.SyntaxRewriter`1.RewriteMany[TParent,TProperty](TParent parent, IReadOnlyList`1 property, TContext context, Func`3 visit, Func`2 rewrite)\r\n   at HotChocolate.Language.SyntaxRewriter`1.RewriteObjectValue(ObjectValueNode node, TContext context)\r\n   at HotChocolate.Execution.VariableToValueRewriter.RewriteObjectValue(ObjectValueNode node, Object context)\r\n   at HotChocolate.Language.SyntaxRewriter`1.RewriteValue(IValueNode node, TContext context)\r\n   at HotChocolate.Execution.VariableToValueRewriter.RewriteValue(IValueNode value, IType type, IVariableValueCollection variables, ITypeConversion typeConversion)\r\n   at HotChocolate.Execution.VariableToValueRewriter.Rewrite(IValueNode value, IType type, IVariableValueCollection variables, ITypeConversion typeConversion)\r\n   at HotChocolate.Execution.ResolverContext.CoerceArgumentValue[T](String name, ArgumentValue argumentValue)\r\n   at HotChocolate.Execution.ResolverContext.Argument[T](NameString name)\r\n   at lambda_method(Closure , IResolverContext )\r\n   at HotChocolate.Types.FieldMiddlewareCompiler.<>c__DisplayClass3_0.<<CreateResolverMiddleware>b__0>d.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at HotChocolate.Execution.ExecutionStrategyBase.ExecuteMiddlewareAsync(ResolverContext resolverContext, IErrorHandler errorHandler)"
      }
    }
  ]
}
```
