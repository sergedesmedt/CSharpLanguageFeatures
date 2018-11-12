using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples
{
    public struct SomeValueType {
        public string TheValue;
    }

    public class SomeReferenceType {
        public string TheValue;
    }

    public class QuickRefresh_ReferenceTypeVersusValueType
    {
        public static void MethodWithValueTypeArg(SomeValueType vType) {
            vType.TheValue = "New value inside MethodWithValueTypeArg";
            Console.WriteLine("After changing inside MethodWithValueTypeArg we have: " 
                + vType.TheValue);
        }

        public static void MethodWithReferenceTypeArg(SomeReferenceType rType) {
            rType.TheValue = "New value inside MethodWithValueTypeArg";
            Console.WriteLine("After changing inside MethodWithReferenceTypeArg we have: " 
                + rType.TheValue);
        }

        static void ValueType_Behavour() {
            SomeValueType vType = new SomeValueType() {
                TheValue = "vType.TheValue: Value before message call"
            };
            Console.WriteLine("vType.TheValue original value is: " + vType.TheValue);

            SomeReferenceType rType = new SomeReferenceType() {
                TheValue = "rType.TheValue: Value before message call"
            };
            Console.WriteLine("rType.TheValue original value is: " + rType.TheValue);

            QuickRefresh_ReferenceTypeVersusValueType.MethodWithValueTypeArg(vType);
            Console.WriteLine("vType.TheValue value after method call is: " + vType.TheValue);

            QuickRefresh_ReferenceTypeVersusValueType.MethodWithReferenceTypeArg(rType);
            Console.WriteLine("rType.TheValue value after method call is: " + rType.TheValue);
        }
    }
}
