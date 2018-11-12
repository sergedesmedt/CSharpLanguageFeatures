using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples {
    public class InterfaceMethodsInterfaceImpl : IInterfaceMethods {

        public int AnOrinaryMethod(int someArgButWithAnotherName)
        {
            return someArgButWithAnotherName;
        }


        public (int, string) AnonymousTupleAsReturn() {
            return (1, "een");
        }

        // Following will not be regarded as an implementation of 
        //  the interfaces AnonymousTupleAsReturn method: the names used
        //  for the ValueTuple members must be the same as in the interface definition
        //  Here we provided no names in the interface definition, so we cannot provide
        //  names in the implementation neither
        //public (int theInteger, string theText) AnonymousTupleAsReturn() {
        //    return (1, "een");
        //}

        public (int theInteger, string theText) NamedTupleAsReturn() {
            return (1, "een");
        }

        // Following will not be regarded as an implementation of 
        //  the interfaces NamedTupleAsReturn method: the names used
        //  for the ValueTuple members must be the same as in the interface definition
        //public (int theIntegerWithOtherName, string theTextWithOtherName) NamedTupleAsReturn() {
        //    return (1, "een");
        //}

        public void AnonymousTupleAsArgument((int, string) arg)
        {

        }

        // Following will not be regarded as an implementation of 
        //  the interfaces AnonymousTupleAsArgument method: the names used
        //  for the ValueTuple members must be the same as in the interface definition
        //  Here we provided no names in the interface definition, so we cannot provide
        //  names in the implementation neither
        //public void AnonymousTupleAsArgument((int theInteger, string theText) arg) {

        //}

        //// BUT this will:
        //public void AnonymousTupleAsArgument((int, string) argWithAnotherName)
        //{

        //}


        public void NamedTupleAsArgument((int theInteger, string theText) arg) {

        }

        // Following will not be regarded as an implementation of 
        //  the interfaces NamedTupleAsArgument method: the names used
        //  for the ValueTuple members must be the same as in the interface definition
        //public void NamedTupleAsArgument((int theIntegerWithOtherName, string theTextWithOtherName) arg) {

        //}
    }
}
