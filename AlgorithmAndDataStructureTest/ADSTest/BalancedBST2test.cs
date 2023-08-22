using ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joolTest
{
    [TestClass]
    public class BalancedBST2test
    {
        [TestMethod]
        public void TestGenerate()
        {
            BalancedBST2 balancedBST = new BalancedBST2();
            int[] arr = { 8, 4, 12, 2, 6, 10, 14 };
            balancedBST.GenerateTree(arr);

            BalancedBST2 balancedBST2 = new BalancedBST2();
            int[] a = { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 };
            balancedBST2.GenerateTree(a);
        }

        [TestMethod]
        public void IsBalancedTest()
        {
            BalancedBST2 bST = new BalancedBST2();
            int[] arr = { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15 };
            bST.GenerateTree(arr);
            bST.IsBalanced(bST.Root);

            BalancedBST2 bST2 = new BalancedBST2();
            int[] a = { 8 };
            bST2.GenerateTree(a);
            bST2.IsBalanced(bST2.Root);

            BalancedBST2 bST3 = new BalancedBST2();
            int[] arr1 = { 8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13 };
            bST3.GenerateTree(arr1);
            bST3.IsBalanced(bST3.Root);
        }


    }
}
