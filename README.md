![Nuget](https://img.shields.io/nuget/dt/FluentAssertions.ArgumentMatchers.Moq)

FluentAssertions.ArgumentMatchers.Moq
===

The [FluentAssertions.ArgumentMatchers.Moq NuGet package](https://www.nuget.org/packages/FluentAssertions.ArgumentMatchers.Moq/) provides a simple way to use Moq in combination with FluentAssertions to compare complex objects.

The package has a method called `Its.EquivalentTo`. It can be used in the Setup and Verify stages of a Mock similar to other argument matchers like ` It.IsAny<T>()`. The `actual.Should().BeEquivalentTo(expected)` method is used inside to compare objects. An overload is available so you can pass in configuration to FluentAssertions.

### Examples
```csharp
_mock.Setup(m => m.DoSomething(Its.EquivalentTo(expectedComplexType))).Returns(result);

_mock.Verify(m => m.DoSomething(Its.EquivalentTo(expectedComplexType)));

_mock.Verify(m => m.DoSomething(Its.EquivalentTo(
    expectedComplexType, 
    options => options.Excluding(c => c.SomeProperty)
)));
```