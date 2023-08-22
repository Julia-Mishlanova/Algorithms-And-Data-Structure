using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class Loop<T> : IEnumerable<T>
    {

        public List<T> LoopList;
        public IEnumerator<T> GetEnumerator() => LoopList.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        //System.Collections.IEnumerator

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
        public Loop(IEnumerable<T> sourse)
        {
            LoopList = sourse.ToList();
        }
        public void Add(T item)
        {
            this.LoopList.Add(item);
        }

        public void Left()
        {
            T buff = LoopList[0];
            for (int i = 0; i < this.LoopList.Count - 1; i++)
            {
                LoopList[i] = LoopList[i + 1];
            }
            LoopList[LoopList.Count - 1] = buff;
        }

        public void Rigth()
        {
            T buff = LoopList[LoopList.Count - 1];
            for (int i = LoopList.Count - 1; i > 0; i--)
            {
                LoopList[i] = LoopList[i - 1];
            }
            LoopList[0] = buff;
        }

        public T PopOut()
        {
            T pop = LoopList[0];
            LoopList.RemoveAt(0);
            return pop;
        }

        public T ShowFirst()
        {
            return LoopList[0];
        }
    }
}
