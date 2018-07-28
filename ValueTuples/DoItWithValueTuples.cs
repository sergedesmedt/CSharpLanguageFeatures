using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples
{
    static class DoItWithValueTuples {
        public static void TuplesCreation_ByConstructor() {
            ValueTuple<int, string> myValueTuple = new ValueTuple<int, string>(10, "tien");
        }

        public static void TuplesCreation_ByFactory() {
            var myValueTuple = ValueTuple.Create(10, "tien");
        }

        public static void TuplesCreation_BySyntaxConvention() {
            var myValueTuple = (10, "tien");
        }

        public static void TuplesCreation_WithDefaultConstructor() {
            // Following does not compile
            ValueTuple<int, string> myTuple = new ValueTuple<int, string>();
        }

        public static void TuplesCreation_WithMemberAssignment() {
            ValueTuple<int, string> myTuple = new ValueTuple<int, string>(10, "tien");

            //Following does compile: member assignment is allowed
            myTuple.Item1 = 21;
            myTuple.Item2 = "twinig";
        }

        public static void TuplesCreation_Deconstruction() {
            var (theNumber, theString) = ValueTuple.Create(11, "elf");
            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
        }

        public static (int, string) GiveMeTheTuple() {
            return (11, "elf");
        }

        public static void CallingTheTuple() {
            var returnTuple = GiveMeTheTuple();
            Console.WriteLine($"Tuple item1: {returnTuple.Item1} - item2: {returnTuple.Item2}");
        }
    }
}
