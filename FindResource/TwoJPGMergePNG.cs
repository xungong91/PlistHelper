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
    public class TwoJPGMergePNGItem
    {
        public string JpgFile;
        public string AJpgFile;
        public string FileName;
    }

    public class TwoJPGMergePNG
    {
        private List<TwoJPGMergePNGItem> mList = new List<TwoJPGMergePNGItem>();

        public TwoJPGMergePNG(string path)
        {
            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i]) == ".jpg")
                {
                    string fileName = Path.GetFileName(files[i]);

                    TwoJPGMergePNGItem temp = new TwoJPGMergePNGItem()
                    {
                        JpgFile = string.Format("{0}/{1}", path, fileName),
                        AJpgFile = string.Format("{0}/{1}/{2}", path, "alpha", fileName),
                        FileName = fileName
                    };
                    mList.Add(temp);
                }
            }
            startImage();
        }

        private void startImage()
        {
            int changeCount = mList.Count;
            Console.WriteLine("-----------准备开始，共{0}个资源等待转换------------", changeCount);
            for (int i = 0; i < changeCount; i++)
            {
                try
                {
                    ChangeAndSaveImage(mList[i].JpgFile, mList[i].AJpgFile, mList[i].FileName);
                    Console.WriteLine("{0}/{1}转换：{2}完成", i + 1, changeCount, mList[i].FileName);
                }
                catch
                {
                    Console.WriteLine("{0}/{1}转换：{2}失败", i + 1, changeCount, mList[i].FileName);
                }
            }
            Console.WriteLine("-----------转换完成------------", changeCount);
            Console.ReadLine();
        }

        public void ChangeAndSaveImage(string jpgFile, string aJpgFile, string fileName)
        {
            Bitmap bitmap = new Bitmap(jpgFile);
            Bitmap aBitmap = new Bitmap(aJpgFile);

            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            for (int i = 0; i < bitmap.Size.Width; i++)
            {
                for (int j = 0; j < bitmap.Size.Height; j++)
                {
                    Color oldColor = bitmap.GetPixel(i, j);
                    Color color = Color.FromArgb(
                        aBitmap.GetPixel(i, j).G,
                        oldColor.R,
                        oldColor.G,
                        oldColor.B);
                    newBitmap.SetPixel(i, j, color);
                }
            }
            newBitmap.Save(string.Format("map/{0}.png", Path.GetFileNameWithoutExtension(fileName)), ImageFormat.Png);
        }
    }
}
