using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    public class CutImage
    {
        public CutImage(Bitmap bitmap, string imagePath)
        {
            this._mBitmap = bitmap;
            this._mImagePath = imagePath;
        }

        private Bitmap _mBitmap;

        public Bitmap MBitmap
        {
            get { return _mBitmap; }
            set { _mBitmap = value; }
        }

        private string _mImagePath;

        public string MImagePath
        {
            get { return _mImagePath; }
            set { _mImagePath = value; }
        }


        public void TryCutImage(ImageSize size, string name, bool Rotated)
        {
            int offsetX = size.OffsetX;
            int offsetY = size.OffsetY;
            int width = size.Width;
            int height = size.Height;
            Bitmap createBitmap = new Bitmap(width, height);
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int x = i + offsetX;
                    int y = j + offsetY;
                    createBitmap.SetPixel(i, j, _mBitmap.GetPixel(x, y));
                }
            }
            if (Rotated)
            {
                createBitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            createBitmap.Save(_mImagePath + "\\" + name, ImageFormat.Png);
        }
    }
}
