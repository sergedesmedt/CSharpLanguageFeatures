using System;
using System.Collections.Generic;
using System.Linq;
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
            // Following does compile
            ValueTuple<int, string> myTuple = new ValueTuple<int, string>();
        }

        public static void TuplesWithManyMembers_CreatBySyntax() {
            var sevenMemberTuple = (1, 2, 3, 4, 5, 6, 7);

            // We can proceed adding members
            var eightMemberTuple = (1, 2, 3, 4, 5, 6, 7, 8);
            var nineMemberTupleAttempt1 = (1, 2, 3, 4, 5, 6, 7, 8, 9);
        }

        public static void TuplesCreation_ImmutabilityWithMemberAssignment() {
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

        public static void CallingTheTuple_Deconstruction() {
            var (theNumber, theString) = GiveMeTheTuple();
            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
        }

        public static void CallingTheTuple_DeconstructionIntoExistingVariables() {
            int theNumber;
            string theString;

            // Following does no longer compile: the variable names allready exist
            //var (theNumber, theString) = GiveMeTheTuple();

            (theNumber, theString) = GiveMeTheTuple();

            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
        }

        public static void CallingTheTuple_Deconstruction_Ignore() {
            var (_, theString) = GiveMeTheTuple();
            // The underscore cannot be used to get at Item1 of the tuple
            // By using the underscore we tell the compiler to ignore the Item1 member in the deconstruction of the tuple.
            //Console.WriteLine($"Tuple item1 through variable theNumber: {_} - item2 through variable theString: {theString}");
            Console.WriteLine($"Tuple item1 cannot be retrieved - item2 through variable theString: {theString}");
        }

        public static void AcceptTheTuple_Anonymous((int, string) arg) {
            Console.WriteLine($"Tuple item1 through the member: {arg.Item1} - item2 through the member: {arg.Item2}");
        }

        public static void AcceptTheTuple_Named((int theNumber, string theString) arg) {
            // Following does not compile
            //Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
            Console.WriteLine($"Tuple item1 through variable theNumber: {arg.theNumber} - item2 through variable theString: {arg.theString}");
        }

        public static void SendingTheTuple_Anonymous() {
            // We do not need to provide names
            var anonymousTuple = (1, "tien");
            AcceptTheTuple_Anonymous(anonymousTuple);

            // We can provide names
            var someNamedTupe = (invokerIntName: 1, invokerStringName: "tien");
            AcceptTheTuple_Anonymous(someNamedTupe);

            // Following does not compile: they are not seperate arguments but are part of the same tuple
            //AcceptTheTuple_Anonymous(1, "tien");
        }

        public static void SendingTheTuple_Named() {
            // We do not need to provide names
            var anonymousTuple = (1, "tien");
            AcceptTheTuple_Named(anonymousTuple);

            // We can provide other names
            var someNamedTupe = (invokerIntName: 1, invokerStringName: "tien");
            AcceptTheTuple_Named(someNamedTupe);

            // Following does not compile: they are not seperate arguments but are part of the same tuple
            //AcceptTheTuple_Named(1, "tien");
        }

        public static void TuplesFromDictionaries() {
            Dictionary<int, string> source = new Dictionary<int, string> { { 1, "één" }, { 2, "twee" }, { 3, "drie" } };

            var listOfTuples = source.Select(kv => (kv.Key, kv.Value)).ToList();

            foreach (var tuple in listOfTuples) {
                Console.WriteLine($"Iterating Tuple item1: {tuple.Item1} - item2: {tuple.Item2}");

                var (theNumber, theString) = tuple;
                Console.WriteLine($"Iterating Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");

            }
        }

        public static void DecompositionFromTupleList() {
            List<(int, string)> tupleList = new List<(int, string)>() {
                (1, "een"),
                (2, "twee"),
                (3, "drie"),
            };

            var decomposedThroughAnonymousTypesList = tupleList.Select(t => new { t.Item1, t.Item2 }).ToList();

            var decomposedThroughDeconstructionListDefaultNames = tupleList.Select(t => (t.Item1, t.Item2)).ToList();
            foreach (var anonymousTuple in decomposedThroughDeconstructionListDefaultNames) {
                Console.WriteLine($"Iterating Tuple item1: {anonymousTuple.Item1} - item2: {anonymousTuple.Item2}");
            }

            var decomposedThroughDeconstructionListSpecifiedNames = tupleList.Select(t => (theNumber: t.Item1, theString: t.Item2)).ToList();
            foreach (var namedTuple in decomposedThroughDeconstructionListSpecifiedNames) {
                Console.WriteLine($"Iterating Tuple item1: {namedTuple.theNumber} - item2: {namedTuple.theString}");
            }
            //var decomposedThroughDeconstructionList = tupleList.Select(t => ( theNumber = t.Item1, theString = t.Item2 )).ToList();
        }

        public static List<(int theNumberInList, string theStringInList)> GetDecompositionFromTupleList() {
            List<(int, string)> tupleList = new List<(int, string)>() {
                (1, "een"),
                (2, "twee"),
                (3, "drie"),
            };

            var decomposedThroughDeconstructionListSpecifiedNames = tupleList.Select(t => (theNumber: t.Item1, theString: t.Item2)).ToList();
            foreach (var namedTuple in decomposedThroughDeconstructionListSpecifiedNames) {
                Console.WriteLine($"Iterating ValueTuple theNumber: {namedTuple.theNumber} - theString: {namedTuple.theString}");
            }
            return decomposedThroughDeconstructionListSpecifiedNames;
        }

        public static void CallingDecompositionFromTupleList() {
            var theList = GetDecompositionFromTupleList();

            foreach (var namedTuple in theList) {
                // Following does NOT compile: the old member names of the ValueTuple are lost when returning them as (int theNumberInList, string theStringInList)
                //Console.WriteLine($"Iterating ValueTuple theNumber: {namedTuple.theNumber} - theString: {namedTuple.theString}");
                Console.WriteLine($"Iterating ValueTuple theNumberInList: {namedTuple.theNumberInList} - theStringInList: {namedTuple.theStringInList}");
            }
        }

        public static void ListOfTuples_IsImmutableBecauseOfValueTupleIsStruct() {
            List<(int, string)> tupleList = new List<(int, string)>() {
                (1, "een"),
                (2, "twee"),
                (3, "drie"),
            };

            // Following does not compile
            //  Cannot modify the return value of 'List<(int, string)>.this[int]' because it is not a variable 
            //tupleList[0].Item1 = 1;
        }
    }
}
