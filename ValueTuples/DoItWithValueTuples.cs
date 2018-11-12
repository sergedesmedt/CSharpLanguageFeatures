using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueTuples
{
    static class DoItWithValueTuples {

        #region Tuple Creation

        public static void TuplesCreation_ByConstructor() {
            ValueTuple<int, string> myValueTuple = new ValueTuple<int, string>(10, "tien");
        }

        public static void TuplesCreation_ByFactory() {
            var myValueTuple = ValueTuple.Create(10, "tien");
        }

        public static void TuplesCreation_BySyntaxConvention() {
            var myValueTuple = (10, "tien");
            var myNamedMemberValueTuple = (theNumber: 10, theText: "tien");
            Console.WriteLine($"The number is {myNamedMemberValueTuple.theNumber} and the text is {myNamedMemberValueTuple.theText}");
        }

        public static void TupleCreation_Naming()
        {
            // You do not have to supply new names for all members
            var partialNaming = (theNumber: 10, "tien");
            Console.WriteLine($"The number is {partialNaming.theNumber} and the text is {partialNaming.Item2}");
            // You can re-use the generic names, but only if they are at the correct position
            var atSpecificPosition = (theNumber: 10, Item2: "tien");
            Console.WriteLine($"The number is {atSpecificPosition.theNumber} and the text is {atSpecificPosition.Item2}");
            // Following will not compile: you can only use the ItemX names at the position they are "designed" for.
            //var itemCannotBeUsedAtIllegalPosition = (Item2: 10, "tien");
        }

        public static void TuplesWithManyMembers_AtInfinitum() {

            var sevenMemberByConstructor = new ValueTuple<int, int, int, int, int, int, int>(1, 2, 3, 4, 5, 6, 7);
            var sevenMemberByFactory = ValueTuple.Create(1, 2, 3, 4, 5, 6, 7);
            var sevenMemberTuple = (1, 2, 3, 4, 5, 6, 7);

            // Allthough following will compile, it will not run. An exception will be thrown
            //  System.ArgumentException: 'The last element of an eight element ValueTuple must be a ValueTuple.'
            //var eightMemberByConstructor = new ValueTuple<int, int, int, int, int, int, int, int>(1, 2, 3, 4, 5, 6, 7, 8);

            // Allthough the eight member ValueTuple does not contain an Item8 member, the compiler acts as if it does
            var eightMemberByFactory = ValueTuple.Create(1, 2, 3, 4, 5, 6, 7, "acht");
            Console.
                WriteLine($"eightMemberByFactory is of type {eightMemberByFactory.GetType()}"
                + Environment.NewLine + $"Item1 is {eightMemberByFactory.Item1},"
                + Environment.NewLine + $"Item2 is {eightMemberByFactory.Item2},"
                + Environment.NewLine + $"Item3 is {eightMemberByFactory.Item3},"
                + Environment.NewLine + $"Item4 is {eightMemberByFactory.Item4},"
                + Environment.NewLine + $"Item5 is {eightMemberByFactory.Item5},"
                + Environment.NewLine + $"Item6 is {eightMemberByFactory.Item6},"
                + Environment.NewLine + $"Item7 is {eightMemberByFactory.Item7},"
                + Environment.NewLine + $"Item8 is {eightMemberByFactory.Item8} and of type {eightMemberByFactory.Item8.GetType()}: it is the eighth argument,"
                + Environment.NewLine + $"Argument 8 through the Rest member is {eightMemberByFactory.Rest.Item1},"
                );

            var eightMemberTuple = (1, 2, 3, 4, 5, 6, 7, "acht");
            Console.
                WriteLine($"eightMemberTuple is of type {eightMemberTuple.GetType()}"
                + Environment.NewLine + $"Item1 is {eightMemberTuple.Item1},"
                + Environment.NewLine + $"Item2 is {eightMemberTuple.Item2},"
                + Environment.NewLine + $"Item3 is {eightMemberTuple.Item3},"
                + Environment.NewLine + $"Item4 is {eightMemberTuple.Item4},"
                + Environment.NewLine + $"Item5 is {eightMemberTuple.Item5},"
                + Environment.NewLine + $"Item6 is {eightMemberTuple.Item6},"
                + Environment.NewLine + $"Item7 is {eightMemberTuple.Item7},"
                + Environment.NewLine + $"Item8 is {eightMemberTuple.Item8} and of type {eightMemberTuple.Item8.GetType()}: it is the eighth argument,"
                + Environment.NewLine + $"Item8 through the Rest member is {eightMemberTuple.Rest.Item1},"
                );

            // Following will not compile
            //var nineMemberByConstructor = new ValueTuple<int, int, int, int, int, int, int, int, int>(1, 2, 3, 4, 5, 6, 7, 8, 9);
            //var nineMemberByFactory = ValueTuple.Create(1, 2, 3, 4, 5, 6, 7, 8, 9);

            var nineMemberByNestedFactory = ValueTuple.Create(1, 2, 3, 4, 5, 6, 7, ValueTuple.Create("acht", "negen"));
            Console.WriteLine($"nineMemberByNestedFactory is of type {eightMemberTuple.GetType()}"
                + Environment.NewLine + $"Item1 is {nineMemberByNestedFactory.Item1},"
                + Environment.NewLine + $"Item2 is {nineMemberByNestedFactory.Item2},"
                + Environment.NewLine + $"Item3 is {nineMemberByNestedFactory.Item3},"
                + Environment.NewLine + $"Item4 is {nineMemberByNestedFactory.Item4},"
                + Environment.NewLine + $"Item5 is {nineMemberByNestedFactory.Item5},"
                + Environment.NewLine + $"Item6 is {nineMemberByNestedFactory.Item6},"
                + Environment.NewLine + $"Item7 is {nineMemberByNestedFactory.Item7},"
                // We are accessing the ValueTupe here and NOT the string "acht" !!!!
                + Environment.NewLine + $"Item8 is {nineMemberByNestedFactory.Item8} and of type {nineMemberByNestedFactory.Item8.GetType()},"
                + Environment.NewLine + $"Item8.Item1 is {nineMemberByNestedFactory.Item8.Item1},"
                + Environment.NewLine + $"Item8 through the Rest member is {nineMemberByNestedFactory.Rest.Item1.Item1},"
                //+ $"Item9 is {nineMemberByNestedFactory.Item9},"
                + Environment.NewLine + $"Item8.Item2 is {nineMemberByNestedFactory.Item8.Item2},"
                + Environment.NewLine + $"Item9 through the Rest member is {nineMemberByNestedFactory.Rest.Item1.Item2},"
                );

            // We can proceed adding members, but only using the syntax convention
            var nineMemberTupleBySyntax= (1, 2, 3, 4, 5, 6, 7, "acht", "negen");
            // We can access them all with the regular ItemX syntax
            Console.WriteLine($"nineMemberTupleBySyntax is of type {eightMemberTuple.GetType()}"
                + Environment.NewLine + $"Item1 is {nineMemberTupleBySyntax.Item1},"
                + Environment.NewLine + $"Item2 is {nineMemberTupleBySyntax.Item2},"
                + Environment.NewLine + $"Item3 is {nineMemberTupleBySyntax.Item3},"
                + Environment.NewLine + $"Item4 is {nineMemberTupleBySyntax.Item4},"
                + Environment.NewLine + $"Item5 is {nineMemberTupleBySyntax.Item5},"
                + Environment.NewLine + $"Item6 is {nineMemberTupleBySyntax.Item6},"
                + Environment.NewLine + $"Item7 is {nineMemberTupleBySyntax.Item7},"
                // We are accessing the string "acht" here and NOT the ValueTupe !!!!
                + Environment.NewLine + $"Item8 is {nineMemberTupleBySyntax.Item8},"
                + Environment.NewLine + $"Item8 through the Rest member is {nineMemberTupleBySyntax.Rest.Item1},"
                + Environment.NewLine + $"Item9 is {nineMemberTupleBySyntax.Item9},"
                + Environment.NewLine + $"Item9 through the Rest member is {nineMemberTupleBySyntax.Rest.Item1},"
                );

        }

        public static void TuplesCreation_WithDefaultConstructor() {
            // Following does compile
            ValueTuple<int, string> myTuple = new ValueTuple<int, string>();
        }

        #endregion

        #region Immutability

        public static void TuplesCreation_ImmutabilityWithMemberAssignment() {
            ValueTuple<int, string> myTuple = new ValueTuple<int, string>(10, "tien");

            //Following does compile: member assignment is allowed
            myTuple.Item1 = 21;
            myTuple.Item2 = "twinig";
        }

        public static void ListOfTuples_IsImmutableBecauseOfValueTupleIsStruct() {
            List<(int, string)> myTupleList = new List<(int, string)>() {
                (1, "een"),
                (2, "twee"),
                (3, "drie"),
            };

            // Following does not compile
            //  Cannot modify the return value of 'List<(int, string)>.this[int]' because it is not a variable 
            //tupleList[0].Item1 = 10;

            var temp = myTupleList[0];
            temp.Item1 = 10;
            Console.WriteLine($"IsImmutableBecauseOfValueTupleIsStruct"
                + $" tupleList[0]: {myTupleList[0].Item1}"
                + $" - temp: {temp.Item1}");

            var first = (1, "een");
            List<(int, string)> myOtherTupleList = new List<(int, string)>() {
                first
            };
            first.Item1 = 10;
            var temp2 = myOtherTupleList[0];
            temp2.Item1 = 100;
            Console.WriteLine($"IsImmutableBecauseOfValueTupleIsStruct"
                + $" first: {first.Item1}"
                + $" - tupleList[0]: {myOtherTupleList[0].Item1}"
                + $" - temp: {temp2.Item1}");

        }

        public static ValueTuple<int, string> ActionOnTuple(ValueTuple<int, string> tuple, ref ValueTuple<int, string> refTuple) {
            Console.WriteLine($"ActionOnTuple.ValueTuple - tuple item1: {tuple.Item1} - item2: {tuple.Item2}");
            tuple.Item1 = 12;
            tuple.Item2 = "twaalf";
            Console.WriteLine($"ActionOnTuple.ValueTuple -tuple  item1: {tuple.Item1} - item2: {tuple.Item2}");

            Console.WriteLine($"ActionOnTuple.ValueTuple - refTuple item1: {refTuple.Item1} - item2: {refTuple.Item2}");
            refTuple.Item1 = 22;
            refTuple.Item2 = "tweeentwintig";
            Console.WriteLine($"ActionOnTuple.ValueTuple - refTuple item1: {refTuple.Item1} - item2: {refTuple.Item2}");

            return tuple;
        }

        public static void Execute_ActionOnTuple() {
            var tuple = (11, "elf");
            var byRefTuple = (21, "eenentwintig");
            Console.WriteLine($"Tuple.ValueTuple - tuple item1: {tuple.Item1} - item2: {tuple.Item2}");
            Console.WriteLine($"Tuple.ValueTuple - byRefTuple item1: {byRefTuple.Item1} - item2: {byRefTuple.Item2}");
            var returnTuple = ActionOnTuple(tuple, ref byRefTuple);
            Console.WriteLine($"Tuple.ValueTuple - tuple after item1: {tuple.Item1} - item2: {tuple.Item2}");
            Console.WriteLine($"Tuple.ValueTuple - byRefTuple after item1: {byRefTuple.Item1} - item2: {byRefTuple.Item2}");
            Console.WriteLine($"Return.ValueTuple - returnTuple item1: {returnTuple.Item1} - item2: {returnTuple.Item2}");
        }

        #endregion

        #region Identity and Equality

        public static void IdentityandEquality()
        {
            var myTuple1 = (10, "tien");
            var myTuple2 = (10, "tien");
            var myTuple3 = myTuple1;

            Console.WriteLine($"myTuple1 equals myTuple2: {Object.Equals(myTuple1, myTuple2)}");
            Console.WriteLine($"myTuple1 equals myTuple2: {Object.ReferenceEquals(myTuple1, myTuple2)}");

            Console.WriteLine($"myTuple1 equals myTuple3: {Object.Equals(myTuple1, myTuple3)}");
            Console.WriteLine($"myTuple1 equals myTuple3: {Object.ReferenceEquals(myTuple1, myTuple3)}");

        }

        public static void EqualityAndImmutability()
        {
            var myTuple1 = (10, "tien");
            var myTuple3 = myTuple1;

            Console.WriteLine($"myTuple1 equals myTuple3: {Object.Equals(myTuple1, myTuple3)}");
            Console.WriteLine($"myTuple1 equals myTuple3: {Object.ReferenceEquals(myTuple1, myTuple3)}");

            myTuple3.Item1 = 11;

            Console.WriteLine($"myTuple1 equals myTuple3: {Object.Equals(myTuple1, myTuple3)}");
            Console.WriteLine($"myTuple1 equals myTuple3: {Object.ReferenceEquals(myTuple1, myTuple3)}");
        }

        #endregion

        #region Tuples and Deconstruction

        public static void TuplesCreation_Deconstruction() {
            var theTuple = ValueTuple.Create(11, "elf");
            (var theNumber, var theString) = theTuple;
            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
        }

        #endregion

        #region Tuples as return values from and arguments to functions and actions

        #region As return values

        public static (int, string) GiveMeTheTuple_Anonymous() {
            return (11, "elf");
        }

        public static void CallingTheTuple_Anonymous() {
            var tuple = GiveMeTheTuple_Anonymous();
            Console.WriteLine($"Tuple item1: {tuple.Item1} - item2: {tuple.Item2}");
        }

        public static void CallingTheTuple_Deconstruction() {
            var (theNumber, theString) = GiveMeTheTuple_Anonymous();
            Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
        }

        public static (int theNumber, string theString) GiveMeTheTuple_Named() {
            return (11, "elf");
        }

        public static (int val1, string val2, bool val3, int val4, string val5, bool val6, int val7, string val8, bool val9, int val10, string val11, bool val12) GiveMeTheTuple_MultiNamed()
        {
            return (11, "elf", true, 11, "elf", true, 11, "elf", true, 11, "elf", true);
        }

        public static (int theNumber, string , (bool, bool) theUnnamedBoolTuple, (bool firstBool, bool) someMembersNamedBoolTuple) GiveMeTheTuple_ComplexNamed()
        {
            return (11, "elf", (true, true), (false, false));
        }

        public static (int theNumber, string theString) GiveMeTheTuple_MixedNamed() {
            return (internalInteger: 11, internalString: "elf");
        }

        public static (int, string) GiveMeTheTuple_InternallyNamed() {
            return (internalInteger: 11, internalString: "elf");
        }

        public static void CallingTheTuple_Named() {
            var tuple = GiveMeTheTuple_Named();
            Console.WriteLine($"Tuple item1 through variable theNumber: {tuple.Item1} - item2 through variable theString: {tuple.Item2}");
            Console.WriteLine($"Tuple item1 through variable theNumber: {tuple.theNumber} - item2 through variable theString: {tuple.theString}");

            var tupleMixedNames = GiveMeTheTuple_MixedNamed();
            Console.WriteLine($"Tuple item1 through variable theNumber: {tupleMixedNames.theNumber} - item2 through variable theString: {tupleMixedNames.theString}");
            // Following will not compile !!!
            // The internal used names inside the function are lost
            //Console.WriteLine($"Tuple item1 through variable theNumber: {tupleMixedNames.internalInteger} - item2 through variable theString: {tupleMixedNames.internalString}");
            // The internal used names inside the function are also lost when we do NOT provide explicit names for the return value
            var tupleInternalNames = GiveMeTheTuple_InternallyNamed();
            // Following will not compile !!!
            //Console.WriteLine($"Tuple item1 through variable theNumber: {tupleInternalNames.internalInteger} - item2 through variable theString: {tupleInternalNames.internalString}");
        }

        #endregion

        #region As arguments

        public static void AcceptTheTuple_Anonymous((int, string) arg) {
            Console.WriteLine($"Tuple item1 through the member: {arg.Item1} - item2 through the member: {arg.Item2}");
        }

        public static void AcceptTheTuple_Named((int theNumber, string theString) arg) {
            // Following does not compile: the parameter is a tuple and not two deconstructed values
            //Console.WriteLine($"Tuple item1 through variable theNumber: {theNumber} - item2 through variable theString: {theString}");
            Console.WriteLine($"Tuple item1 through variable theNumber: {arg.theNumber} - item2 through variable theString: {arg.theString}");
        }

        // Following will not compile: providing other names does not create a new type and thus
        //  two methods with the same ValueType only differing by name are considered having the same method definition
        //public static void AcceptTheTuple_Named((int theOtherNumber, string theOtherString) arg) {
        //    Console.WriteLine($"Tuple item1 through variable theNumber: {arg.theOtherNumber} - item2 through variable theString: {arg.theOtherString}");
        //}

        public static void SendingTheTuple_Anonymous() {
            // We do not need to provide names
            var anonymousTuple = (1, "tien");
            AcceptTheTuple_Anonymous(anonymousTuple);

            // We can provide names, but those names or of course unknown inside the method
            var someNamedTupe = (invokerIntName: 1, invokerStringName: "tien");
            AcceptTheTuple_Anonymous(someNamedTupe);

            // Following does not compile: they are not seperate arguments but are part of the same tuple
            //AcceptTheTuple_Anonymous(1, "tien");
        }

        public static void SendingTheTuple_Named() {
            // We do not need to provide names
            var anonymousTuple = (1, "tien");
            AcceptTheTuple_Named(anonymousTuple);

            // We can provide other names, but those names or of course unknown inside the method
            var someNamedTupe = (invokerIntName: 1, invokerStringName: "tien");
            AcceptTheTuple_Named(someNamedTupe);

            // Following does not compile: they are not seperate arguments but are part of the same tuple
            //AcceptTheTuple_Named(1, "tien");
        }

        #endregion

        #endregion

        #region All this also explains

        #region Generics

        public static T DoSomethingWithTheArgument<T>(T arg) {
            return arg;
        }

        public static void CallGenericsWithAnonymousTuple() {
            var anonymousTuple = (1, "een");

            var methodResult = DoSomethingWithTheArgument(anonymousTuple);
            Console.WriteLine($"Iterating Tuple item1: {methodResult.Item1} - item2: {methodResult.Item2}");
        }

        public static void CallGenericsWithNamedTuple() {
            var namedTuple = (theInteger: 1, theString: "een");

            var methodResult = DoSomethingWithTheArgument(namedTuple);
            Console.WriteLine($"Iterating Tuple item1: {methodResult.Item1} - item2: {methodResult.Item2}");
            Console.WriteLine($"Iterating Tuple theInteger: {methodResult.theInteger} - theString: {methodResult.theString}");
        }

        public static (T, V) DoSomeMoreWithTheArguments<T, U, V, W>((T, U) arg1, (V, W) arg2)
        {
            return (arg1.Item1, arg2.Item1);
        }

        public static void CallMoreGenericsWithNamedTuple()
        {
            var namedTuple1 = (theInteger: 1, theString: "een");
            var namedTuple2 = (theInteger: 1, theString: "een");

            var methodResult = DoSomeMoreWithTheArguments(namedTuple1, namedTuple2);
            Console.WriteLine($"Iterating Tuple item1: {methodResult.Item1} - item2: {methodResult.Item2}");
            //Console.WriteLine($"Iterating Tuple theInteger: {methodResult.theInteger} - theString: {methodResult.theString}");
        }

        #endregion

        #region Extension methods

        public static void UseExtensionMethodWithIntParameter()
        {
            var theExtendee = new ClassToExtend();

            // Following won't compile because we have two extension methods 
            //  with the same name and same type of parameters
            //theExtendee.ExtensionMethodWithIntParameter(1);
        }

        public static void UseExtensionMethodWithValueTupleParameter()
        {
            var theExtendee = new ClassToExtend();

            // Following won't compile because we have two extension methods 
            //  with the same name and same type of parameters
            //theExtendee.ExtensionMethodWithValueTupleParameter((1, "een"));
        }

        #endregion

        #endregion

        #region vs Anonymous Types

        public static void ComparativeCreateSyntax()
        {
            var valueTuple = (TheInt: 1, TheString: "een");
            var anonymType = new { TheInt = 1, TheString = "een" };
        }

        public static (int TheInt, string TheString) ValueTypeAsReturnType()
        {
            return (1, "een");
        }

        //http://tomasp.net/blog/cannot-return-anonymous-type-from-method.aspx/
        //https://www.codeproject.com/Articles/477519/Return-Anonymous-type
        public static object AnonymousTypeAsReturnType()
        {
            return new { TheInt = 1, TheString = "een" };
        }

        #endregion

    }
}
