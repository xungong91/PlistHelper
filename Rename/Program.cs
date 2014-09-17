using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rename
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangeName cn = new ChangeName();
            //on
            cn.start(System.IO.Directory.GetCurrentDirectory() + "/Talk/Boy0/", "_0_0_1", "");
            //on
            cn.start(System.IO.Directory.GetCurrentDirectory() + "/Talk/Boy1/", "_0_1_1", "");
            //on
            cn.start(System.IO.Directory.GetCurrentDirectory() + "/Talk/Girl0/", "_1_0_1", "");
            //on
            cn.start(System.IO.Directory.GetCurrentDirectory() + "/Talk/Girl1/", "_1_1_1", "");

            Console.ReadLine();
        }
    }
}
