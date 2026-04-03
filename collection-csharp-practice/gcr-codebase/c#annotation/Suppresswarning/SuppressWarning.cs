using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation
{
    public class SuppressWarning
    {
            public static void Main(string[] args)
            {

#pragma warning disable
                ArrayList list = new ArrayList();  
                list.Add(10);
                list.Add("Hello");
#pragma warning restore

                foreach (object item in list)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }

