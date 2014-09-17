using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rename
{
    public class ChangeName
    {
        public void start(string path, string oldStr, string newStr)
        {
            Console.WriteLine("准备开始，需要替换的字符串是{0},替换为{1}", oldStr, newStr);
            string[] fileNames = Directory.GetFiles(path);
            for (int i = 0; i < fileNames.Length; i++)
            {
                Console.WriteLine("第{0}个文件，文件名是{1}", i, fileNames[i]);
                string oldName = Path.GetFileName(fileNames[i]);
                string newName = oldName.Replace(oldStr, newStr);
                string newFileName = path + newName;
                Console.WriteLine("第{0}个文件，文件名修改为{1}", i, newFileName);
                File.Move(fileNames[i], newFileName);
            }
        }
    }
}
