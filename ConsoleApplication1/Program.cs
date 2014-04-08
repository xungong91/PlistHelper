using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string plistFile = Console.ReadLine();
            string plistFile = @"E:\imageCreate\TileActionImage2.plist";
            List<PlistData> list = PlistHelper.ReadPlist(plistFile);


            Console.Read();
        }
    }
}
