using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples
{
    public class ClassToExtend
    {

    }

    public static class ExtensionMethods
    {
        public static void ExtensionMethodWithIntParameter(this ClassToExtend extended, int arg1)
        {
            Console.WriteLine($"ExtensionMethodWithIntParameter: {arg1}");
        }

        // Same method signature: this will not compile
        //public static void ExtensionMethodWithIntParameter(this ClassToExtend extended, int arg2)
        //{
        //    Console.WriteLine($"ExtensionMethodWithIntParameter: {arg1}");
        //}

        public static void ExtensionMethodWithValueTupleParameter(this ClassToExtend extended, (int intOnArg1, string stringOnArg1) arg1)
        {
            Console.WriteLine($"ExtensionMethodWithIntParameter: ({arg1.intOnArg1}, {arg1.stringOnArg1})");
        }

        // Although we use other names, this is still the same method signature: this will not compile
        //public static void ExtensionMethodWithValueTupleParameter(this ClassToExtend extended, (int intOnArg2, string stringOnArg2) arg2)
        //{
        //    Console.WriteLine($"ExtensionMethodWithIntParameter: ({arg2.intOnArg2}, {arg2.stringOnArg2})");
        //}

    }

    public static class MoreExtensionMethods
    {
        // Same method signature: when both methods are visible in the using scope then the compiler
        //  does not know whih one to use.
        public static void ExtensionMethodWithIntParameter(this ClassToExtend extended, int arg2)
        {
            Console.WriteLine($"ExtensionMethodWithIntParameter1: {arg2}");
        }

        // Although we use other names, this is still the same method signature: when both methods are visible in the using scope 
        //  then the compiler does not know whih one to use.
        public static void ExtensionMethodWithValueTupleParameter(this ClassToExtend extended, (int intOnArg2, string stringOnArg2) arg2)
        {
            Console.WriteLine($"ExtensionMethodWithIntParameter: ({arg2.intOnArg2}, {arg2.stringOnArg2})");
        }
    }
}
