using System;

namespace ValueTuples
{
    class Program
    {
        static void Main(string[] args)
        {
            DoItWithOrdinaryTuples.IdentityandEquality();
            DoItWithValueTuples.IdentityandEquality();

            QuickRefresh_Deconstruction.DeconstructionOfObjectOfType_ClassWithDeconstructor();
        }
    }
}
