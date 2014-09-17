using System;
using System.Collections.Generic;
using System.Drawing;
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
            //string plistFile = @"C:\work\gametrayImage.plist";
            //List<PlistData> list = PlistHelper.ReadPlist(plistFile);

            new SeparationPictures().StartCutPanda("panda_anim.png",
@"C:\Users\gx\Desktop\PandaRunAssets\panda");

            Console.Read();
        }
    }
}
