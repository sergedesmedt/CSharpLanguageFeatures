using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueTuples
{
    static class DoItWithOrdinaryTuples {
        public static void TuplesCreation_ByConstructor() {
            Tuple<int, string> myTuple = new Tuple<int, string>(10, "tien");
        }

        public static void TuplesCreation_ByFactory() {
            var myTuple = Tuple.Create(10, "tien");
        }

        public static void TuplesCreation_NoDefaultConstructor() {

            // Following does not compile
            //Tuple<int, string> myTuple = new Tuple<int, string>();
        }

        public static void TuplesCreation_NoMemberAssignment() {
            Tuple<int, string> myTuple = new Tuple<int, string>(10, "tien");

            // Following does not compile: member assignment is not allowed
            //myTuple.Item1 = 21;
            //myTuple.Item2 = "twinig";
        }

        public static void TuplesCreation_Deconstruction() {
            var (theNumber, theString) = Tuple.Create(11, "elf");
            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
        }

        public static void TuplesCreation_DeconstructionOfReferenceTypes() {
            var (theNumber, theRef) = Tuple.Create(11, new SomeClass() { IntProperty = 100, StringProperty = "honderd" });
            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theRef: {theRef}");
        }

        public static void TuplesCreation_DeconstructionOfReferenceTypes_NoDefaultConstructor() {
            var (theNumber, theRef) = Tuple.Create(11, new SomeClassWithoutDefaultConstructor(100, "honderd"));
            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theRef: {theRef}");
        }

        public static Tuple<int, string> GiveMeTheTuple() {
            return Tuple.Create(11, "elf");
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

        public static void TuplesFromDictionaries() {
            Dictionary<int, string> source = new Dictionary<int, string> { { 1, "één" }, { 2, "twee" }, { 3, "drie" } };

            var listOfTuples = source.Select(kv => Tuple.Create(kv.Key, kv.Value)).ToList();

            foreach(var tuple in listOfTuples) {
                Console.WriteLine($"Iterating Tuple item1: {tuple.Item1} - item2: {tuple.Item2}");

                var (theNumber, theString) = tuple;
                Console.WriteLine($"Iterating Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");

            }
        }

        public static void DecompositionFromTupleList() {
            List<Tuple<int, string>> tupleList = new List<Tuple<int, string>>() {
                Tuple.Create(1, "een"),
                Tuple.Create(2, "twee"),
                Tuple.Create(3, "drie"),
            };

            var decomposedThroughAnonymousTypesList = tupleList.Select(t => new { t.Item1, t.Item2 }).ToList();

            var decomposedThroughDeconstructionListDefaultNames = tupleList.Select(t => (t.Item1, t.Item2)).ToList();
            foreach (var anonymousTuple in decomposedThroughDeconstructionListDefaultNames) {
                Console.WriteLine($"Iterating Tuple item1: {anonymousTuple.Item1} - item2: {anonymousTuple.Item2}");
            }

            var decomposedThroughDeconstructionListSpecifiedNames = tupleList.Select(t => ( theNumber : t.Item1, theString : t.Item2 )).ToList();
            foreach (var namedTuple in decomposedThroughDeconstructionListSpecifiedNames) {
                Console.WriteLine($"Iterating Tuple item1: {namedTuple.theNumber} - item2: {namedTuple.theString}");
            }
            //var decomposedThroughDeconstructionList = tupleList.Select(t => ( theNumber = t.Item1, theString = t.Item2 )).ToList();
        }

        public static List<(int theNumberInList, string theStringInList)> GetDecompositionFromTupleList() {
            List<Tuple<int, string>> tupleList = new List<Tuple<int, string>>() {
                Tuple.Create(1, "een"),
                Tuple.Create(2, "twee"),
                Tuple.Create(3, "drie"),
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
    }
}
