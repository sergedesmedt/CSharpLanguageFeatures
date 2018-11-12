using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueTuples
{
    static class DoItWithOrdinaryTuples {

        #region Tuple Creation 

        public static void TuplesCreation_ByConstructor() {
            Tuple<int, string> myTuple = new Tuple<int, string>(10, "tien");
        }

        public static void TuplesCreation_ByFactory() {
            var myTuple = Tuple.Create(10, "tien");
        }

        public static void TuplesWithManyMembers_AtInfinitum() {
            var sevenMemberByConstructor = new Tuple<int, int, int, int, int, int, int>(1, 2, 3, 4, 5, 6, 7);
            var sevenMemberByFactory = Tuple.Create(1, 2, 3, 4, 5, 6, 7);

            // Allthough following will compile, it will not run. An exception will be thrown
            //  System.ArgumentException: 'The last element of an eight element tuple must be a Tuple.'
            //var eightMemberByConstructor = new Tuple<int, int, int, int, int, int, int, int>(1, 2, 3, 4, 5, 6, 7, 8);

            var eightMemberByFactory = Tuple.Create(1, 2, 3, 4, 5, 6, 7, "acht");
            Console.WriteLine($"eightMemberByFactory is of type {eightMemberByFactory.GetType()}"
                + Environment.NewLine + $"Item1 is {eightMemberByFactory.Item1},"
                + Environment.NewLine + $"Item2 is {eightMemberByFactory.Item2},"
                + Environment.NewLine + $"Item3 is {eightMemberByFactory.Item3},"
                + Environment.NewLine + $"Item4 is {eightMemberByFactory.Item4},"
                + Environment.NewLine + $"Item5 is {eightMemberByFactory.Item5},"
                + Environment.NewLine + $"Item6 is {eightMemberByFactory.Item6},"
                + Environment.NewLine + $"Item7 is {eightMemberByFactory.Item7},"
                // There is no Item8 member
                // + Environment.NewLine + $"Item8 is {eightMemberByFactory.Item8},"
                + Environment.NewLine + $"Rest.Item1 has the value of the 8th argument {eightMemberByFactory.Rest.Item1},"
            );

            // There is no old-school tuple with nine or more members
            //var nineMemberTupleAttempt1 = Tuple.Create(1, 2, 3, 4, 5, 6, 7, 8, 9);
            //var nineMemberTupleAttempt2 = new Tuple<int, int, int, int, int, int, int, int, int>(1, 2, 3, 4, 5, 6, 7, 8, 9);

            // To specify more then eight members, we need to use nested tuples
            var tenMemberTupleByConstructor = new Tuple<int, int, int, int, int, int, int, Tuple<string, string, string>>(1, 2, 3, 4, 5, 6, 7, new Tuple<string, string, string>("een", "twee", "drie"));
            Console.WriteLine($"tenMemberTupleByConstructor is of type {tenMemberTupleByConstructor.GetType()}"
               + Environment.NewLine + $"Item1 is {tenMemberTupleByConstructor.Item1},"
               + Environment.NewLine + $"Item2 is {tenMemberTupleByConstructor.Item2},"
               + Environment.NewLine + $"Item3 is {tenMemberTupleByConstructor.Item3},"
               + Environment.NewLine + $"Item4 is {tenMemberTupleByConstructor.Item4},"
               + Environment.NewLine + $"Item5 is {tenMemberTupleByConstructor.Item5},"
               + Environment.NewLine + $"Item6 is {tenMemberTupleByConstructor.Item6},"
               + Environment.NewLine + $"Item7 is {tenMemberTupleByConstructor.Item7},"
               + Environment.NewLine + $"Rest.Item1 is {tenMemberTupleByConstructor.Rest.Item1},"
               + Environment.NewLine + $"Rest.Item2 is {tenMemberTupleByConstructor.Rest.Item2},"
               + Environment.NewLine + $"Rest.Item3 is {tenMemberTupleByConstructor.Rest.Item3},"
           );

            // As seen above, a strange thing happens using the factory method though:
            // The resulting type is Tuple<int, int, int, int, int, int, int, Tuple<Tuple<string, string, string>>>
            var tenMemberTupleByNestedFactory = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create("een", "twee", "drie"));

            // Accessing the 8th, 9th and 10th tuple member is done through the Rest.Item1 member
            Console.WriteLine($"tenMemberTupleByNestedFactory is of type {tenMemberTupleByNestedFactory.GetType()}"
               + Environment.NewLine + $"Item1 is {tenMemberTupleByNestedFactory.Item1},"
               + Environment.NewLine + $"Item2 is {tenMemberTupleByNestedFactory.Item2},"
               + Environment.NewLine + $"Item3 is {tenMemberTupleByNestedFactory.Item3},"
               + Environment.NewLine + $"Item4 is {tenMemberTupleByNestedFactory.Item4},"
               + Environment.NewLine + $"Item5 is {tenMemberTupleByNestedFactory.Item5},"
               + Environment.NewLine + $"Item6 is {tenMemberTupleByNestedFactory.Item6},"
               + Environment.NewLine + $"Item7 is {tenMemberTupleByNestedFactory.Item7},"
               + Environment.NewLine + $"Rest.Item1.Item1 is {tenMemberTupleByNestedFactory.Rest.Item1.Item1},"
               + Environment.NewLine + $"Rest.Item1.Item2 is {tenMemberTupleByNestedFactory.Rest.Item1.Item2},"
               + Environment.NewLine + $"Rest.Item1.Item3 is {tenMemberTupleByNestedFactory.Rest.Item1.Item3},"
           );
        }

        public static void TuplesCreation_NoDefaultConstructor() {
            // Following does not compile
            //Tuple<int, string> myTuple = new Tuple<int, string>();
        }

        #endregion

        #region Immutability

        public static void TuplesCreation_ImmutabilityNoMemberAssignment() {
            Tuple<int, string> myTuple = new Tuple<int, string>(10, "tien");

            // Following does not compile: member assignment is not allowed
            //myTuple.Item1 = 21;
            //myTuple.Item2 = "twinig";
        }

        public static void ListOfTuples_IsImmutableBecauseOfTupleDefinition() {
            List<Tuple<int, string>> tupleList = new List<Tuple<int, string>>() {
                Tuple.Create(1, "een"),
                Tuple.Create(2, "twee"),
                Tuple.Create(3, "drie"),
            };

            // Following does not compile
            //  Property or indexer 'Tuple<int, string>.Item1' cannot be assigned to --it is read only
            //tupleList[0].Item1 = 10;
        }

        public static Tuple<int, string> ActionOnTuple(Tuple<int, string> tuple) {
            // Following does not compile: member assignment is not allowed
            //tuple.Item1 = 12;
            //tuple.Item2 = "twaalf";
            return tuple;
        }

        public static void Execute_ActionOnTuple() {
            var tuple = Tuple.Create(11, "elf");
            var returnTuple = ActionOnTuple(tuple);
            Console.WriteLine($"Tuple item1: {returnTuple.Item1} - item2: {returnTuple.Item2}");
            // Of course, assignment is still not allowed
        }

        #endregion

        #region Identity and Equality

        public static void IdentityandEquality()
        {
            var myTuple1 = new Tuple<int, string>(10, "tien");
            var myTuple2 = new Tuple<int, string>(10, "tien");
            var myTuple3 = myTuple1;

            Console.WriteLine($"myTuple1 equals myTuple2: {Object.Equals(myTuple1, myTuple2)}");
            Console.WriteLine($"myTuple1 equals myTuple2: {Object.ReferenceEquals(myTuple1, myTuple2)}");

            Console.WriteLine($"myTuple1 equals myTuple3: {Object.Equals(myTuple1, myTuple3)}");
            Console.WriteLine($"myTuple1 equals myTuple3: {Object.ReferenceEquals(myTuple1, myTuple3)}");

        }

        #endregion

        #region Tuples and Deconstruction

        public static void TuplesCreation_Deconstruction() {
            var theTuple = Tuple.Create(11, "elf");
            var (theNumber, theString) = theTuple;
            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
        }

        #endregion

        #region Tuples as return values from and arguments to functions and actions

        #region As return values

        public static Tuple<int, string> GiveMeTheTuple() {
            return Tuple.Create(11, "elf");
        }

        public static void CallingTheTuple() {
            var tuple = GiveMeTheTuple();
            Console.WriteLine($"Tuple item1: {tuple.Item1} - item2: {tuple.Item2}");
        }

        public static void CallingTheTuple_Deconstruction() {
            var (theNumber, theString) = GiveMeTheTuple();
            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
        }

        #endregion

        #region As arguments

        public static void AcceptTheTuple(Tuple<int, string> arg) {
            Console.WriteLine($"Tuple item1 through the member: {arg.Item1} - item2 through the member: {arg.Item2}");
        }

        public static void SendingTheTuple() {
            var tuple = Tuple.Create(11, "elf");
            AcceptTheTuple(tuple);
        }

        #endregion

        #endregion

    }
}
