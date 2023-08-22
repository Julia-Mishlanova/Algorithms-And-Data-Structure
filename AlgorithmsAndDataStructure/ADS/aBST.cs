using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class aBST
    {
        public int?[] Tree;
        public aBST(int depth)
        {
            int tree_size = CalculateSize(depth);
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }
        private static int CalculateSize(int depth)
        {
            int size = 0;
            int buff = 1;
            for (int i = 0; i < depth - 1; i++)
            {
                var sum = buff += buff;
                size += sum;
            }

            return size + 1;
        }

        public int? FindKeyIndex(int key)
        {
            // 2 * i + 1 LeftChild
            // 2 * i + 2 RightChild
            // (i - 1) / 2 Parent
            for (int i = 0; i < Tree.Length; i++)
            {
                if (key == Tree[i]) return i;

                if (key > Tree[i])
                {
                    if (2 * i + 1 > Tree.Length) return null;

                    if (Tree[2 * i + 2] != null)
                    {
                        i = 2 * i + 1;
                        continue;
                    }
                }

                if (key < Tree[i])
                {
                    if (2 * i > Tree.Length) return null;

                    if (Tree[2 * i + 1] != null)
                    {
                        i = 2 * i;
                        continue;
                    }
                }
            }
            return null;
        }

        public int AddKey(int key)
        {
            if (Tree[0] == null)
            {
                Tree[0] = key;
                return 0;
            }

            for (int i = 0; i < Tree.Length; i++)
            {
                if (key > Tree[i])
                {
                    if (2 * i + 2 > Tree.Length - 1) return -1;

                    if (Tree[2 * i + 2] != null)
                    {
                        i = 2 * i + 1;
                        continue;
                    }

                    Tree[2 * i + 2] = key;
                    return 2 * i + 2;
                }

                if (key < Tree[i])
                {
                    if (2 * i + 1 > Tree.Length - 1) return -1;

                    if (Tree[2 * i + 1] != null)
                    {
                        i = 2 * i;
                        continue;
                    }

                    Tree[2 * i + 1] = key;
                    return 2 * i + 1;
                }
            }
            return -1;
        }

    }
}
