using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FluentAssertions.ArgumentMatchers.Moq.Tests
{
    [TestClass]
    public class Issue7Tests
    {
        [TestMethod]
        public void FailsBecauseListIsPassed()
        {
            var mock = new Mock<IDependency>();
            var list = new List<SomeType> { new SomeType(1) };

            mock.Object.DoSomething(list.ToArray());

            mock.Verify(x => x.DoSomething(Its.EquivalentTo(list)));
        }

        [TestMethod]
        public void SucceedsBecauseIEnumerableSomeTypeIsPassedToItsEquivalent()
        {
            var mock = new Mock<IDependency>();
            var list = new List<SomeType> { new SomeType(1) };

            mock.Object.DoSomething(list.ToArray());

            mock.Verify(x => x.DoSomething(Its.EquivalentTo<IEnumerable<SomeType>>(list)));
        }

        [TestMethod]
        public void SucceedsBecausePassedTypeIsEnumerable()
        {
            var mock = new Mock<IDependency>();
            var list = new List<SomeType> { new SomeType(1) };
            IEnumerable<SomeType> enumerable = list;

            mock.Object.DoSomething(list.ToArray());

            mock.Verify(x => x.DoSomething(Its.EquivalentTo(enumerable)));
        }
    }

    public record SomeType(int i);

    public interface IDependency
    {
        void DoSomething(IEnumerable<SomeType> _);
    }
}
