using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;

namespace joolTest
{
    [TestClass]
    public class BalancedBSTtest
    {
        [TestMethod]
        public void Test()
        {
            // 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15
            int[] arr = new int[] { 8, 4, 12, 2, 6, 10 };
            int[] arrForSort = new int[] { 8, 4, 12, 2, 6, 10 };

            BalancedBST bST = new BalancedBST();
            var result = bST.GenerateBBSTArray(arrForSort);

            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], result[i]);
            }
        }
    }
}
