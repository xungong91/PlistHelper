using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SeparationPictures
    {
        public SeparationPictures()
        {

        }

        private Bitmap mBitMap;

        private string mOutPath;

        public void StartCutPanda(string fileName, string outPath)
        {
            mBitMap = new Bitmap(fileName);
            mOutPath = outPath;
            int run = 93, jump = 185, roll = 278, turn = 372, burn = 462, turn2 = 558, deal = 652, sprint = 743;
            int[] height = { run, jump, roll, turn, burn, turn2, deal, sprint };

            saveActionImages("run", height, 0);
            saveActionImages("jump", height, 1);
            saveActionImages("roll", height, 2);
            saveActionImages("turn", height, 3);
            saveActionImages("burn", height, 4);
            saveActionImages("turn2", height, 5);
            saveActionImages("deal", height, 6);
            saveActionImages("sprint", height, 7);
        }

        private void saveActionImages(string actionName, int[] heights, int index)
        {
            Console.WriteLine("-----------out {0}------------", actionName);
            for (int i = 0; i < 8; i++)
            {
                int heightMax = getHeightMax(heights, index);
                int heightMin = getHeightMin(heights, index);
                int actualHeight = heightMax - heightMin;

                Bitmap temp = new Bitmap(79, actualHeight);
                for (int x = 0; x < 79; x++)
                {
                    for (int y = 0; y < actualHeight; y++)
                    {
                        temp.SetPixel(x, y, mBitMap.GetPixel(i * 79 + x, y + heightMin));
                    }
                }
                string tempName = mOutPath + "\\" + actionName + "Panda" + i.ToString() + ".png";
                temp.Save(tempName, ImageFormat.Png);
                Console.WriteLine("out {0} {1}", actionName, tempName);
            }
        }

        private int getHeightMax(int[] heights, int index)
        {
            return heights[index];
        }
        private int getHeightMin(int[] heights, int index)
        {
            return index == 0 ? 0 : heights[index - 1];
        }
    }
}
