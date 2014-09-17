using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindResource
{
    public class IndexAnimationItem
    {
        public int OffsetX;
        public int OffsetY;
        public int Width;
        public int Height;
    }

    public class IndexAnimation
    {
        public string Name = "";
        public float Interval;
        public List<IndexAnimationItem> AnimationList = new List<IndexAnimationItem>();
    }

    public class ReadIndexFile
    {
        public List<IndexAnimation> mIndexAnimationList = new List<IndexAnimation>();

        public string FileName;

        public ReadIndexFile(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(fileName);

            IndexAnimation indexAnimation = new IndexAnimation();
            bool nextInterval = false;          //标记下一个是间隔
            int i = 0;                              //index
            while (!sr.EndOfStream)
            {
                ++i;
                string temp = sr.ReadLine();
                temp = new System.Text.RegularExpressions.Regex("[\\s]+").Replace(temp, " ");
                sb.AppendLine(temp);
                string[] arr = temp.Split(' ');

                if (i < 5)
                {
                    if (i == 2)
                    {
                        FileName = temp;
                    }
                    continue;
                }

                if (arr.Length == 1)
                {
                    if (nextInterval)
                    {
                        indexAnimation.Interval = Convert.ToSingle(temp);
                        nextInterval = false;
                    }
                    if (temp.Length != 0 && !char.IsNumber(temp[0]))
                    {
                        if (indexAnimation.Name != "")
                        {
                            mIndexAnimationList.Add(indexAnimation);
                        }
                        indexAnimation = new IndexAnimation();
                        indexAnimation.Name = temp;
                        nextInterval = true;
                    }
                }
                else
                {
                    if (arr.Length == 2)
                    {
                        
                    }
                    else if (arr.Length > 2)
                    {
                        IndexAnimationItem item = new IndexAnimationItem();
                        item.OffsetX = Convert.ToInt32(arr[0]);
                        item.OffsetY = Convert.ToInt32(arr[1]);
                        item.Width = Convert.ToInt32(arr[2]);
                        item.Height = Convert.ToInt32(arr[3]);
                        indexAnimation.AnimationList.Add(item);
                    }
                }
            }
            if (indexAnimation.Name != "")
            {
                mIndexAnimationList.Add(indexAnimation);
            }
            sr.Close();
        }
    }
}
