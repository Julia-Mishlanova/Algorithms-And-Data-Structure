using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_ADS;
using System.Collections;


namespace joolTest
{
    [TestClass]
    public class NativeDictionaryTest
    {
        [TestMethod]
        public void DicTest()
        {
            NativeDictionary<int> dic = new NativeDictionary<int>(10);
            dic.Put("bogdan", 1);
            var val = dic.Get("bogdan");

            dic.Put("bogdan", 2);
            var val1 = dic.Get("bogdan"); // два одинаковых

            dic.Put("kakish", 3);
            var val2 = dic.Get("kakish");

            dic.Put("ishkak", 4);
            var val3 = dic.Get("ishkak"); // два одинаковых по hash

            dic.Put("wave", 5);
            var val4 = dic.Get("wave");

            dic.Put("Jool", 6);
            var val5 = dic.Get("Jool");

            dic.Put("Sas", 7);
            var val6 = dic.Get("Sas");

            dic.Put("u", 8);
            var val7 = dic.Get("u");

            dic.Put("slanec", 9);
            var val8 = dic.Get("slanec");

            dic.Put("i", 10);
            var val9 = dic.Get("i");

            dic.Put("9", 11);
            var val10 = dic.Get("9");

            dic.Put("ooo", 12); // добавление когда место кончилось
            var val11 = dic.Get("ooo");

            var get = dic.Get(" "); // поиск того, чего нет
            var get1 = dic.Get(string.Empty);

        }
    }
}
