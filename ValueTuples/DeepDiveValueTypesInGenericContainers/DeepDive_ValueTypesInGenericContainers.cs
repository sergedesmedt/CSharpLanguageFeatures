using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ValueTuples {
    public class DeepDive_ValueTypesInGenericContainers {
        public static void SizeOfTypes() {
            var sizeOfSomeStruct = Marshal.SizeOf(typeof(SomeStruct));
            var sizeOfSomeOtherStruct = Marshal.SizeOf(typeof(SomeOtherStruct));

            Console.WriteLine($"Size of List<SomeStruct>: {sizeOfSomeStruct}");
            Console.WriteLine($"Size of List<SomeOtherStruct>: {sizeOfSomeOtherStruct}");
        }

        public static void SizeOfContainers() {
            List<SomeStruct> listOfSomeStruct = new List<SomeStruct>();
            List<SomeOtherStruct> listOfSomeOtherStruct = new List<SomeOtherStruct>();

            var sizeOfListOfSomeStruct  = Marshal.SizeOf(typeof(List<SomeStruct>));
            var sizeOfListOfSomeOtherStruct = Marshal.SizeOf(typeof(List<SomeOtherStruct>));

            Console.WriteLine($"Size of List<SomeStruct>: {sizeOfListOfSomeStruct}");
            Console.WriteLine($"Size of List<SomeOtherStruct>: {sizeOfListOfSomeOtherStruct}");
        }
    }
}
