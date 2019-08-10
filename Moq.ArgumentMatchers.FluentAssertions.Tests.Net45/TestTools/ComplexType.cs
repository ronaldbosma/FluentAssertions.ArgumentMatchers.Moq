using System;
using System.Linq;
using System.Collections.Generic;

namespace Moq.ArgumentMatchers.FluentAssertions.Tests.Net45.TestTools
{
    public class ComplexType
    {
        public static ComplexType Create()
        {
            return new ComplexType
            {
                IntProperty = 23,
                StringProperty = "adlfasdlfj",
                GuidProperty = null,
                ComplexTypeProperty = new AnotherComplexType
                {
                    IntProperty = 934,
                    StringProperty = "aslk asdlfj  lkasdjflkj"
                },
                ListProperty = new List<string> { "a", "b", "c" }
            };
        }

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
                IntProperty = this.IntProperty,
                StringProperty = this.StringProperty,
                GuidProperty = this.GuidProperty,
                ComplexTypeProperty = new AnotherComplexType
                {
                    IntProperty = this.ComplexTypeProperty.IntProperty,
                    StringProperty = this.ComplexTypeProperty.StringProperty
                },
                ListProperty = this.ListProperty.Select(s => s)
            };
        }
    }
}
