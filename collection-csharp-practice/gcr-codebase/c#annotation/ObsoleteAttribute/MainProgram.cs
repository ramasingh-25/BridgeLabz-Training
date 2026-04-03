using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.ObsoleteAttribute
{
    public class MainProgram
    {
       public static void Main(string[] args)
        {
            LegacyAPI api = new LegacyAPI();

            api.OldFeature(); 

            api.NewFeature();   
        }
    }
}

