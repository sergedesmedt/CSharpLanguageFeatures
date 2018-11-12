using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples {
    public class ClassWithDeconstructor {
        public ClassWithDeconstructor(int externalValueForInt, string externalValueForString) {
            PropertyOfTypeInt = externalValueForInt;
            PropertyOfTypeString = externalValueForString;
        }

        public void Deconstruct(out int holderForInt, out string holderForString) {
            holderForInt = PropertyOfTypeInt;
            holderForString = PropertyOfTypeString;
        }

        public int PropertyOfTypeInt {
            get;
            set;
        }

        public string PropertyOfTypeString {
            get;
            set;
        }
    }
}
