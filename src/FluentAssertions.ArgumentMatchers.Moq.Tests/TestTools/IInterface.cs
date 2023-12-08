using System.Collections.Generic;

namespace FluentAssertions.ArgumentMatchers.Moq.Tests.TestTools
{
    public interface IInterface
    {
        void DoSomething(ComplexType complexType);
        
        void DoSomethingWithCollection(IEnumerable<ComplexType> complexType);
    }
}
