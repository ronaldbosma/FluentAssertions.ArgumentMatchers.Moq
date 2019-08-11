using System;
using System.Linq;
using System.Collections.Generic;

namespace FluentAssertions.ArgumentMatchers.Moq.Tests.TestTools
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

        public ComplexType Copy()
        {
            return new ComplexType
            {
                IntProperty = IntProperty,
                StringProperty = StringProperty,
                GuidProperty = GuidProperty,
                ComplexTypeProperty = new AnotherComplexType
                {
                    IntProperty = ComplexTypeProperty.IntProperty,
                    StringProperty = ComplexTypeProperty.StringProperty
                },
                ListProperty = ListProperty.Select(s => s)
            };
        }
    }
}
