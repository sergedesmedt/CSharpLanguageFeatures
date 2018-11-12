using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples {
    public class QuickRefresh_Deconstruction {

        public static void ConstructionOfObjectOfType_ClassWithConstructors() {
            var theDefaultConstructedObject = new ClassWithConstructors();
            Console.WriteLine("Default constructed object has values >"+
                $" PropertyOfTypeInt: {theDefaultConstructedObject.PropertyOfTypeInt}" +
                $" PropertyOfTypeString: {theDefaultConstructedObject.PropertyOfTypeString}");

            int externalValueForInt = 10;
            string externalValueForString = "External value for the string property";
            var theCustomConstructedObject = new ClassWithConstructors(externalValueForInt, externalValueForString);
            Console.WriteLine("Object constructed with provided values, has values >" +
                $" PropertyOfTypeInt: {theCustomConstructedObject.PropertyOfTypeInt}" +
                $" PropertyOfTypeString: {theCustomConstructedObject.PropertyOfTypeString}");
        }

        public static void DeconstructionOfObjectOfType_ClassWithDeconstructor() {
            int externalValueForInt = 10;
            string externalValueForString = "External value for the string property";
            var theCustomConstructedObject = new ClassWithDeconstructor(externalValueForInt, externalValueForString);
            Console.WriteLine("Object constructed with provided values, has values >" +
                $" PropertyOfTypeInt: {theCustomConstructedObject.PropertyOfTypeInt}" +
                $" PropertyOfTypeString: {theCustomConstructedObject.PropertyOfTypeString}");

            (var targetForInt, var targetForString) = theCustomConstructedObject;
            Console.WriteLine("The decomposition of the object results in following values >" +
                $" targetForInt: {targetForInt}" +
                $" targetForString: {targetForString}");
        }

        public static void DeconstructionOfObjectOfType_StructWithDeconstructor()
        {
            int externalValueForInt = 10;
            string externalValueForString = "External value for the string property";
            var theCustomConstructedObject = new StructWithDeconstructor(externalValueForInt, externalValueForString);
            Console.WriteLine("Object constructed with provided values, has values >" +
                $" PropertyOfTypeInt: {theCustomConstructedObject.PropertyOfTypeInt}" +
                $" PropertyOfTypeString: {theCustomConstructedObject.PropertyOfTypeString}");

            (var targetForInt, var targetForString) = theCustomConstructedObject;
            Console.WriteLine("The decomposition of the object results in following values >" +
                $" targetForInt: {targetForInt}" +
                $" targetForString: {targetForString}");
        }

    }
}
