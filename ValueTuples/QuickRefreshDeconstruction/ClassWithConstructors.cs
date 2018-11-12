using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples {
    public class ClassWithConstructors {
        public ClassWithConstructors() {
            PropertyOfTypeInt = 0;
            PropertyOfTypeString = "Initialized with fixed value in consructor";
        }

        public ClassWithConstructors(int externalValueForInt, string externalValueForString) {
            PropertyOfTypeInt = externalValueForInt;
            PropertyOfTypeString = externalValueForString;
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
