using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamingConsole
{
    public class Renaming
    {
        private List<KeyData> keyList;

        public List<KeyData> KeyList
        {
            get { return keyList; }
            set { keyList = value; }
        }

        public void setRenaming(string path)
        {
            string filepath = path;
            string[] filenames = Directory.GetFiles(filepath);  //获取该文件夹下面的所有文件名
            for (int i = 0; i < filenames.Length; i++)
            {
                FileInfo fi = new FileInfo(filenames[i]);
                string newFileName = string.Empty;
                for (int j = 0; j < KeyList.Count; j++)
                {
                    if (filenames[i].Contains(KeyList[j].key))
                    {
                        newFileName = filenames[i].Replace(KeyList[j].key, KeyList[j].value);
                        Console.WriteLine(newFileName);
                        fi.MoveTo(newFileName);
                        break;
                    }
                    
                }
            }
        }
    }

    public class KeyData
    {
        public string key{get;set;}

        public string value{get;set;}
    }
}
