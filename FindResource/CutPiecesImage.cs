using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace FindResource
{
    public class ImageIndexItem
    {
        public string ImageName;
        public double x1, y1, x2, y2;
    }

    public class ImageIndex
    {
        public string ImagePathName;
        public List<ImageIndexItem> ImageIndexItems = new List<ImageIndexItem>();
        public Hashtable NameAndBitmap = new Hashtable();
    }

    public class CutPiecesImage
    {
        List<string> mImageIndexFiles = new List<string>();

        List<ImageIndex> mImageIndexList = new List<ImageIndex>();

        public CutPiecesImage(string imagePath)
        {
            string[] imageIndexFiles = Directory.GetFiles(imagePath);
            for (int i = 0; i < imageIndexFiles.Length; i++)
            {
                if (Path.GetExtension(imageIndexFiles[i]) == ".pi_set")
                {
                    mImageIndexFiles.Add(imageIndexFiles[i]);
                }
            }
            createImageIndexList();
        }

        private void createImageIndexList()
        {
            for (int i = 0; i < mImageIndexFiles.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(mImageIndexFiles[i]);

                ImageIndex imageIndex = new ImageIndex();
                imageIndex.ImagePathName = Path.GetFileNameWithoutExtension(mImageIndexFiles[i]);

                ImageIndexItem imageIndexItem = new ImageIndexItem();
                int index = 0;                              //index
                int startIndex = -5;
                while (!sr.EndOfStream)
                {
                    ++index;
                    string temp = sr.ReadLine();
                    temp = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(temp, " ");
                    sb.AppendLine(temp);
                    string[] arr = temp.Split(' ');

                    if (char.IsLower(temp[0]) && arr.Length == 1)
                    {
                        try
                        {
                            startIndex = index;
                            imageIndexItem = new ImageIndexItem();
                            imageIndexItem.ImageName = temp;
                            if (!imageIndex.NameAndBitmap.ContainsKey(temp))
                            {
                                imageIndex.NameAndBitmap.Add(temp, new Bitmap(string.Format("map/{0}.png", temp)));
                            }
                        }
                        catch
                        {
                            startIndex = -5;
                        }
                    }
                    else
                    {
                        if (index == startIndex + 3)
                        {
                            imageIndexItem.x1 = Convert.ToDouble(arr[0]);
                            imageIndexItem.y1 = Convert.ToDouble(arr[1]);
                        }
                        if (index == startIndex + 4)
                        {
                            imageIndexItem.x2 = Convert.ToDouble(arr[0]);
                            imageIndexItem.y2 = Convert.ToDouble(arr[1]);
                            imageIndex.ImageIndexItems.Add(imageIndexItem);
                        }
                        else
                        {

                        }
                    }
                }
                mImageIndexList.Add(imageIndex);
            }
            cut();
        }

        private void cut()
        {
            Console.WriteLine("-----------准备开始，共{0}个文件夹等待转换------------", mImageIndexList);
            for (int i = 0; i < mImageIndexList.Count; i++)
            {
                List<ImageIndexItem> imageIndexItems = mImageIndexList[i].ImageIndexItems;
                for (int j = 0; j < imageIndexItems.Count; j++)
                {
                    try
                    {
                        Bitmap oldBitmap = (Bitmap)(mImageIndexList[i].NameAndBitmap[imageIndexItems[j].ImageName]);
                        Bitmap bitmap = startCut(oldBitmap.Width, oldBitmap.Height
                            , imageIndexItems[j].x1
                            , imageIndexItems[j].y1
                            , imageIndexItems[j].x2
                            , imageIndexItems[j].y2
                            , oldBitmap);
                        string imagePath = string.Format("image/{0}/", mImageIndexList[i].ImagePathName);
                        if (!Directory.Exists(imagePath))
                        {
                            Directory.CreateDirectory(imagePath);
                        }
                        string imageFile = string.Format("image/{0}/{1}.png", mImageIndexList[i].ImagePathName, j);
                        bitmap.Save(imageFile, ImageFormat.Png);
                        Console.Write("[{0}/{1}成功]", j + 1, imageIndexItems.Count);
                    }
                    catch
                    {
                        Console.Write("[{0}/{1}失败]", j + 1, imageIndexItems.Count);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("{0}/{1}转换：成功", i + 1, mImageIndexList.Count);
            }
            Console.WriteLine("-----------转换完成------------");
            Console.ReadLine();
        }

        public Bitmap startCut(int imageWidth, int imageHeight, double x1, double y1, double x2, double y2, Bitmap bitmap)
        {
            double temp = y1;
            y1 = y2;
            y2 = temp;
            y1 = 1 - y1;
            y2 = 1 - y2;

            int width = (int)(imageWidth * (x2 - x1)), height = (int)(imageHeight * (y2 - y1));
            int offsetX = (int)(imageWidth * x1), offsetY = (int)(imageHeight * y1);

            Bitmap createBitmap = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int x = i + offsetX;
                    int y = j + offsetY;
                    createBitmap.SetPixel(i, j, bitmap.GetPixel(x, y));
                }
            }
            return createBitmap;
        }
    }
}
