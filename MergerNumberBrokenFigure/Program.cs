using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergerNumberBrokenFigure
{
    public class Program
    {
        public static string imageString = @"";
        public static string imgaePath
            = @"D:\MyDocuments\Tencent Files\314568735\FileRecv\资源\等待 计时";

        static void Main(string[] args)
        {
            List<string> imageNames = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                imageNames.Add(imgaePath + "\\" + imageString + i.ToString() + ".png");
            }
            ImagesHelper ig = new ImagesHelper(imageNames);
            
        }
    }

    public class ImagesHelper
    {
        public ImagesHelper(List<string> list)
        {
            int imagesX = 0;
            int imagesY = 0;
            List<Bitmap> images = new List<Bitmap>();
            for (int i = 0; i < list.Count; i++)
            {
                Bitmap img = new Bitmap(list[i]);
                if (img.Height > imagesY)
                {
                    imagesY = img.Height;
                }
                if (img.Width > imagesX)
                {
                    imagesX = img.Width;
                }
                images.Add(img);
            }
            int a = imagesX * images.Count;
            Bitmap newimg = new Bitmap(a, imagesY);
            for (int i = 0; i < images.Count; i++)
            {
                Bitmap it = images[i];
                int offx = (imagesX - it.Width) / 2;

                for (int ii = 0; ii < it.Width; ii++)
                {
                    for (int jj = 0; jj < it.Height; jj++)
                    {
                        int x = i*imagesX + ii + offx;
                        int y = jj;
                        newimg.SetPixel(x, y, it.GetPixel(ii, jj));
                    }
                }
            }
            if (Program.imageString == "")
            {
                Program.imageString = "new";
            }
            newimg.Save(Program.imgaePath + "\\" + Program.imageString + ".png", ImageFormat.Png);
        }

    }
}
