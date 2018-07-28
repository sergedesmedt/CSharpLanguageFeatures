using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples
{
    class SomeClass
    {
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
