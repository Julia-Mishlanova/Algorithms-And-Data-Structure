using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class BalancedBST
    {
        private int GetTreeDepth(int length)
        {
            int depth = 1;
            for (int i = 2; i < length;)
            {
                i *= 2;
                depth++;
            }
            return depth;
        }
        public int?[] GenerateBBSTArray(int[] a)
        {
            Array.Sort(a);

            int depth = GetTreeDepth(a.Length);
            var aBST = new aBST(depth);

            int[] arr = new int[aBST.Tree.Length];
            Array.Copy(a, 0, arr, 0, a.Length);

            int middle = a.Length / 2;
            int left = middle / 2;
            int right = middle + left + 1;

            aBST.AddKey(arr[middle]);
            aBST.AddKey(arr[left]);
            aBST.AddKey(arr[right]);

            var newMiddle = depth - 1;

            List<int> currLayer = new List<int>() { left, right };
            int i = 0;

            while (i < depth - 1)
            {
                newMiddle--;

                currLayer = Tree(currLayer, arr, newMiddle);
                foreach (int ind in currLayer)
                {
                    aBST.AddKey(arr[ind]);
                }

                i++;
            }
            return aBST.Tree;
        }

        private List<int> Tree(List<int> currLayer, int[] a, int mid)
        {
            List<int> nextLayer = new List<int>();

            for (int i = 0; i < currLayer.Count; i++)
            {
                var right = currLayer[i] + mid;
                var left = currLayer[i] - mid;

                nextLayer.Add(right);
                nextLayer.Add(left);
            }
            return nextLayer;
        }
    }
}
