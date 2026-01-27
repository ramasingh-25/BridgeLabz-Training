using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.ObsoleteAttribute
{
    public class LegacyAPI
    {
        [Obsolete("OldFeature is deprecated. Use NewFeature instead.")]
        public void OldFeature()
        {
            Console.WriteLine("This is the old feature");
        }

        public void NewFeature()
        {
            Console.WriteLine("This is the new feature");
        }
    }
}

