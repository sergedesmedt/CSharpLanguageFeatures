using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples {
    public class VirtualMethods {
        public virtual (int, string) AnonymousTupleAsReturn() { return (10, "tien"); }
        public virtual (int theInteger, string theText) NamedTupleAsReturn() { return (10, "tien"); }

        public virtual void AnonymousTupleAsArgument((int, string) arg) { }
        public virtual void NamedTupleAsArgument((int theInteger, string theText) arg) { }
    }
}
