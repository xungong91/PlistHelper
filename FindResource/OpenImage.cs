using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindResource
{
    public class OpenImage
    {
        Bitmap mBitmap;

        ReadIndexFile mReadIndexFile;

        public OpenImage(string fileName, string indexFile)
        {
            mBitmap = new Bitmap(fileName);

            mReadIndexFile = new ReadIndexFile(indexFile);
        }
        public void open()
        {
            for (int i = 0; i < mReadIndexFile.mIndexAnimationList.Count; i++)
            {
                startSaveImage(mReadIndexFile.mIndexAnimationList[i], mReadIndexFile.FileName);
            }
        }
        private void startSaveImage(IndexAnimation indexAnimation, string imageName)
        {
            if (!Directory.Exists(imageName))
            {
                Directory.CreateDirectory(imageName);
            }

            for (int m = 0; m < indexAnimation.AnimationList.Count; m++)
            {
                int width = indexAnimation.AnimationList[m].Width, height = indexAnimation.AnimationList[m].Height;
                int offsetX = indexAnimation.AnimationList[m].OffsetX, offsetY = indexAnimation.AnimationList[m].OffsetY;

                Bitmap createBitmap = new Bitmap(width, height);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        int x = i + offsetX;
                        int y = j + offsetY;
                        createBitmap.SetPixel(i, j, mBitmap.GetPixel(x, y));
                    }
                }
                createBitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                string saveName = string.Format("{0}/{1}{2}.png", imageName, indexAnimation.Name, m);
                createBitmap.Save(saveName, ImageFormat.Png);
            }
        }
    }
}
