using System;
using System.Collections;
using System.Collections.Generic;


namespace Generictest
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList a = new ArrayList();
            List<int> b = new List<int>();
            List<string> c = new List<string>();

            a.Add(4);
            a.Add("test");

            b.Add(4);
            c.Add("test");

            foreach (Object i in a)
            {
                Console.WriteLine(i.ToString());
            }

            foreach (Object i in b)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
