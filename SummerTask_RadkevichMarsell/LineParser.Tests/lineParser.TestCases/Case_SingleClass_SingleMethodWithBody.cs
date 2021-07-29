using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineParser.Tests.lineParser.TestCases
{
    class Case_SingleClass_SingleMethodWithBody
    {
        void Compute()
        {
            int a = 5;
            int b = 6;

            if (a > a + b)
            {
                a = -1;
                if (b > a)
                    Console.WriteLine("Lol");
                else
                {

                }

            }

            else
                Console.WriteLine("Meh");

        }
    }
}
