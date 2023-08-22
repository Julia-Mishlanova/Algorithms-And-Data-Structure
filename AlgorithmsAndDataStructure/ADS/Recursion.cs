using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class Recursion<T>
    {
        public static int Pow(int n, int m)
        {
            if (n == 0) return 1;

            n *= n;
            m -= 1;

            if (m <= 1) return n;
            else return Pow(n, m);
        }

        public static int SumOfNumberDigits(int number)
        {
            if (number == 0) return 0;

            return number % 10 + SumOfNumberDigits(number / 10);
        }

        public static int GetLength(LinkedList<T> values)
        {
            if (values.First == null) return 0;
            values.RemoveFirst();
            return 1 + GetLength(values);
        }

        public static bool IsPalindrome(string str)
        {
            if (str[0] != str[str.Length - 1]) return false;

            str = str.Substring(1);
            if (str.Length <= 1) return true;
            str = str.Substring(0, str.Length - 1);

            return IsPalindrome(str);
        }

        public static List<int> GetEvenValues(List<int> values, int i = 0)
        {
            if (i > values.Count - 1) return values;

            if (values[i] % 2 != 0) values.RemoveAt(i);

            return GetEvenValues(values, i + 1);
        }

        public static List<int> EvenIndexes(List<int> values, int i = 0)
        {
            if (i > values.Count - 1) return values;

            if (i % 2 != 0) values.RemoveAt(i);

            return GetEvenValues(values, i + 1);
        }

        public static int Max(List<int> values, int i = 0, int max = 0)
        {
            if (i > values.Count - 1) return max;

            if (values[i] > max) max = values[i];

            return Max(values, i + 1, max);
        }

        private static List<string> result = new List<string>();
        public static List<string> GetAllFiles(string root)
        {
            result.AddRange(Directory.GetFiles(root));
            return StartGetAllFiles(root);
        }
        private static List<string> StartGetAllFiles(string root)
        {
            foreach (var dir in Directory.GetDirectories(root))
            {
                var files = Directory.GetFiles(dir);

                result.AddRange(files);
                StartGetAllFiles(dir);
            }
            return result;
        }
    }
}
