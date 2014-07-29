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
            //string plistFile = @"C:\work\gametrayImage.plist";
            //List<PlistData> list = PlistHelper.ReadPlist(plistFile);

            new SeparationPictures().StartCutPanda(@"C:\Users\gx\Desktop\tiantiankupaoxiongmao_81\assets\panda_anim.png", @"C:\Users\gx\Desktop\tiantiankupaoxiongmao_81\assets\panda");

            Console.Read();
        }
    }
}
