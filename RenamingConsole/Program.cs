using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Renaming rm = new Renaming();
            List<KeyData> keyList = new List<KeyData>(){
            new KeyData() { key = "BaiBan_1_0_", value = "7Feng" },
            new KeyData() { key = "BeiFeng_1_0_", value = "4Feng" },
            new KeyData() { key = "DongFeng_1_0_", value = "1Feng" },
            new KeyData() { key = "FaCai_1_0_", value = "6Feng" },
            new KeyData() { key = "HongZhong_1_0_", value = "5Feng" },
            new KeyData() { key = "NanFeng_1_0_", value = "2Feng" },
           new KeyData() { key = "XiFeng_1_0_", value = "3Feng" }
            };
            List<KeyData> keylist1 = new List<KeyData>()
            {
                new KeyData() { key = "_1_1_", value = "" },
            };

            rm.KeyList = keylist1;
            rm.setRenaming(@"D:\MyDocuments\GitHub\mjgame\mobile\MjMobile\Resources\sound\Girl\CaoZuo1");
        }
    }
}
