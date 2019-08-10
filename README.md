[![Build Status](https://dev.azure.com/ronaldbosma/GitHub/_apis/build/status/ronaldbosma.Moq.ArgumentMatchers.FluentAssertions?branchName=master)](https://dev.azure.com/ronaldbosma/GitHub/_build/latest?definitionId=5&branchName=master)
![Nuget](https://img.shields.io/nuget/dt/Moq.ArgumentMatchers.FluentAssertions)

Moq.ArgumentMatchers.FluentAssertions
===

The Moq.ArgumentMatchers.FluentAssertions package provides a simple way to use Moq in combination with FluentAssertions to compare complex objects.

The package has a method called `Its.EquivalentTo`. It can be used in the Setup and Verify stages of a Mock similar to other argument matchers like ` It.IsAny<T>()`. The `actual.Should().BeEquivalentTo(expected)` syntax is used inside to compare objects. An overload is available so you can pass in configuration to FluentAssertions.

### Examples
```csharp
_mock.Setup(m => m.DoSomething(Its.EquivalentTo(expectedComplexType))).Returns(result);

_mock.Verify(m => m.DoSomething(Its.EquivalentTo(expectedComplexType)));

_mock.Verify(m => m.DoSomething(Its.EquivalentTo(
    expectedComplexType, 
    options => options.Excluding(c => c.SomeProperty)
)));
```

### Build
Created with Visual Studio 2019.