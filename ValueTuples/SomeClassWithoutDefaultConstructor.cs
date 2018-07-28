using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples
{
    class SomeClassWithoutDefaultConstructor
    {
        public SomeClassWithoutDefaultConstructor(int intProperty, string stringProperty) {
            IntProperty = intProperty;
            StringProperty = stringProperty;
        }

        public int IntProperty {
            get;
            set;
        }

        public string StringProperty {
            get;
            set;
        }

        public override string ToString() {
            return string.Format($"SomeClass(IntProperty: {IntProperty}, StringProperty: {StringProperty})");
        }
    }
}
