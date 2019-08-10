using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq.ArgumentMatchers.FluentAssertions.Tests.Net45.TestTools;
using FluentAssertions;

namespace Moq.ArgumentMatchers.FluentAssertions.Tests.Net45
{
    [TestClass]
    public class ItsTests
    {
        private Mock<IInterface> _mock;

        [TestInitialize]
        public void TestInitialize()
        {
            _mock = new Mock<IInterface>();
        }

        [TestMethod]
        public void EquivalentTo_Matches_Two_Complex_Types_With_Same_Data()
        {
            var complexType = ComplexType.Create();
            var expectedComplexType = complexType.Copy();

            _mock.Object.DoSomething(complexType);

            _mock.Verify(m => m.DoSomething(Its.EquivalentTo(expectedComplexType)));
        }

        [TestMethod]
        public void EquivalentTo_Does_Not_Match_Two_Complex_Types_If_Child_Property_Has_Different_Value()
        {
            var complexType = ComplexType.Create();

            var expectedComplexType = complexType.Copy();
            expectedComplexType.ComplexTypeProperty.IntProperty++;

            _mock.Object.DoSomething(complexType);

            Action verify = () => _mock.Verify(m => m.DoSomething(Its.EquivalentTo(expectedComplexType)));
            verify.Should().Throw<MockException>();
        }

        [TestMethod]
        public void EquivalentTo_Matches_Two_Complex_Types_If_Child_Property_Has_Different_Value_But_Its_Ignored()
        {
            var complexType = ComplexType.Create();

            var expectedComplexType = complexType.Copy();
            expectedComplexType.ComplexTypeProperty.IntProperty++;

            _mock.Object.DoSomething(complexType);

            _mock.Verify(m => m.DoSomething(Its.EquivalentTo(
                expectedComplexType,
                options => options.Excluding(c => c.ComplexTypeProperty.IntProperty)
            )));
        }
    }
}
