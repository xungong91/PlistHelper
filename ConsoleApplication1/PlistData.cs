using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class PlistData
    {
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _imageSize;

        public string ImageSize
        {
            get { return _imageSize; }
            set { _imageSize = value; }
        }

        private bool _rotated;

        public bool Rotated
        {
            get { return _rotated; }
            set { _rotated = value; }
        }

        public ImageSize getSize()
        {
            string s = ImageSize.Replace("{", "").Replace("}", "") ;
            string[] sArray = s.Split(',');
            ImageSize size = null;
            if (Rotated)
            {
                size = new ImageSize()
                {
                    OffsetX = Convert.ToInt32(sArray[0]),
                    OffsetY = Convert.ToInt32(sArray[1]),
                    Width = Convert.ToInt32(sArray[3]),
                    Height = Convert.ToInt32(sArray[2])
                };
            }
            else
            {
                size = new ImageSize()
                {
                    OffsetX = Convert.ToInt32(sArray[0]),
                    OffsetY = Convert.ToInt32(sArray[1]),
                    Width = Convert.ToInt32(sArray[2]),
                    Height = Convert.ToInt32(sArray[3])
                };
            }
            return size;
        }
    }

    public class ImageSize
    {
        private int _offsetX;

        public int OffsetX
        {
            get { return _offsetX; }
            set { _offsetX = value; }
        }
        private int _offsetY;

        public int OffsetY
        {
            get { return _offsetY; }
            set { _offsetY = value; }
        }
        private int _width;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
    }
}
