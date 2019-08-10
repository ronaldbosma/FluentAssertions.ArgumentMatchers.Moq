Moq.ArgumentMatchers.FluentAssertions
===

The 'Moq.ArgumentMatchers.FluentAssertions' package provides a simple way to use FluentAssertions in combination with Moq.

The package has a class called `Its` with a method `EquivalentTo`. It can be used in the Setup and Verify stages of a Mock similar to other argument matchers like ` It.IsAny<T>()`.

### Examples
```csharp
_mock.Setup(m => m.DoSomething(Its.EquivalentTo(expectedComplexType))).Returns(result);

_mock.Verify(m => m.DoSomething(Its.EquivalentTo(expectedComplexType)));
```

### Use
The package is available on NuGet. Use `
Install-Package Moq.ArgumentMatchers.FluentAssertions` to install.

### Build
Download Visual Studio 2019 and build.