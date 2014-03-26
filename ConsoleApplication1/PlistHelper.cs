using CE.iPhone.PList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    static class PlistHelper
    {
        static public List<PlistData> list;
        public static List<PlistData> ReadPlist(string fileName)
        {
            //create path 
            string namePath = Path.GetDirectoryName(fileName);  
            string nameNullExtension = Path.GetFileNameWithoutExtension(fileName);

            string imagesPath = string.Format("{0}\\{1}", namePath, nameNullExtension);
            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }
            //cut image into path
            list = new List<PlistData>();
            PListRoot root = PListRoot.Load(fileName);

            CutImage cutImage = new CutImage(new Bitmap(fileName.Replace(".plist", ".png")), imagesPath);
            GetPlist((PListDict)root.Root);
            foreach (var item in list)
            {
                Console.WriteLine("{0}的图像是:{1},是否旋转过{2}", item.FileName, item.ImageSize, item.Rotated);
                cutImage.TryCutImage(item.getSize(), item.FileName, item.Rotated);
            }
            return list;
        }

        static void GetPlist(PListDict dict)
        {
            foreach (var item in dict)
            {
                if (item.Key == "frames")
                {
                    foreach (var item1 in (PListDict)(item.Value))
                    {
                        PListDict pdict = (PListDict)item1.Value;

                        string frame = string.Empty;
                        bool rotated = false;

                        var vFrame = from d in pdict
                                     where d.Key == "frame" || d.Key == "textureRect"
                                    select d;
                        if (vFrame.Count() > 0)
                        {
                            frame = vFrame.First().Value as PListString;
                        }

                        var vRotated = from d in pdict
                                       where d.Key == "rotated" || d.Key == "textureRotated"
                                      select d;
                        if (vRotated.Count() > 0)
                        {
                            rotated = vRotated.First().Value as PListBool;
                        }

                        PlistData data = new PlistData() { FileName = item1.Key, ImageSize = frame, Rotated = rotated };
                        list.Add(data);
                    }
                }
            }
        }
    }
}
