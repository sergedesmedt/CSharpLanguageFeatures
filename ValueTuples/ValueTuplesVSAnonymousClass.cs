using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTuples
{
    static class ValueTuplesVSAnonymousClass
    {
        public static void AnAnonymousClass() {
            var instance = new { TheInteger = 1, TheString = "tien" };
        }

        public static void AValueTuple() {
            var instance = (TheInteger: 1, TheString: "tien");
        }

        //public {TheInteger, TheString} AnAnonymousClass()
        //{
        //    var instance = new { TheInteger = 1, TheString = "tien" };
        //    return instance;
        //}
    }
}
