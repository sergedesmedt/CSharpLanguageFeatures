using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples {
    public interface IInterfaceMethods {
        int AnOrinaryMethod(int someArg);

        (int, string) AnonymousTupleAsReturn();
        (int theInteger, string theText) NamedTupleAsReturn();

        void AnonymousTupleAsArgument((int, string) arg);
        void NamedTupleAsArgument((int theInteger, string theText) arg);
    }
}
