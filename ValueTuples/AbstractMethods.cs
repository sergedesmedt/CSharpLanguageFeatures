using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples {
    public abstract class AbstractMethods {
        public abstract (int, string) AnonymousTupleAsReturn();
        public abstract (int theInteger, string theText) NamedTupleAsReturn();

        public abstract void AnonymousTupleAsArgument((int, string) arg);
        public abstract void NamedTupleAsArgument((int theInteger, string theText) arg);
    }
}
