using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq.ArgumentMatchers.FluentAssertions.Tests.TestTools;

namespace Moq.ArgumentMatchers.FluentAssertions.Tests
{
    [TestClass]
    public class ItsTests
    {
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        public void EquivalentTo_Matches_Two_Complex_Types_With_Same_Data()
        {
            // Arrange
            var complexType = _fixture.Create<ComplexType>();
            var expectedComplexType = complexType.Copy();

            var mock = new Mock<IInterface>();

            // Act
            mock.Object.DoSomething(complexType);

            // Assert
            mock.Verify(m => m.DoSomething(Its.EquivalentTo(expectedComplexType)));
        }
    }
}
