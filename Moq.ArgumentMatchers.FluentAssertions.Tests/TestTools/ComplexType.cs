using System;
using System.Collections.Generic;

namespace Moq.ArgumentMatchers.FluentAssertions.Tests.TestTools
{
    public class ComplexType
    {
        public int IntProperty { get; set; }

        public string StringProperty { get; set; }

        public Guid? GuidProperty { get; set; }

        public AnotherComplexType ComplexTypeProperty { get; set; }

        public IEnumerable<string> ListProperty { get; set; }

        public class AnotherComplexType
        {
            public int IntProperty { get; set; }

            public string StringProperty { get; set; }
        }
    }
}
