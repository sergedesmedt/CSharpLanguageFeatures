using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples {
    public class VirtualMethodsImpl : VirtualMethods {
        //public override (int, string) AnonymousTupleAsReturn() {
        //    return (1, "een");
        //}

        // Following will not be regarded as an implementation of 
        //  the interfaces AnonymousTupleAsReturn method: the names used
        //  for the ValueTuple members must be the same as in the interface definition
        //  Here we provided no names in the interface definition, so we cannot provide
        //  names in the implementation neither
        //public override (int theInteger, string theText) AnonymousTupleAsReturn() {
        //    return (1, "een");
        //}

        public override (int theInteger, string theText) NamedTupleAsReturn() {
            return (1, "een");
        }

        // Following will not be regarded as an implementation of 
        //  the interfaces NamedTupleAsReturn method: the names used
        //  for the ValueTuple members must be the same as in the interface definition
        //public override (int theIntegerWithOtherName, string theTextWithOtherName) NamedTupleAsReturn() {
        //    return (1, "een");
        //}

        public override void AnonymousTupleAsArgument((int, string) arg) {

        }

        // Following will not be regarded as an implementation of 
        //  the interfaces AnonymousTupleAsArgument method: the names used
        //  for the ValueTuple members must be the same as in the interface definition
        //  Here we provided no names in the interface definition, so we cannot provide
        //  names in the implementation neither
        //public override void AnonymousTupleAsArgument((int theInteger, string theText) arg) {

        //}

        public override void NamedTupleAsArgument((int theInteger, string theText) arg) {

        }

        // Following will not be regarded as an implementation of 
        //  the interfaces NamedTupleAsArgument method: the names used
        //  for the ValueTuple members must be the same as in the interface definition
        //public override void NamedTupleAsArgument((int theIntegerWithOtherName, string theTextWithOtherName) arg) {

        //}    
    }
}
